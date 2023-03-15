using AppliConsole.Context;
using AppliConsole.Context.DbContextSpvPaie;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Task = System.Threading.Tasks.Task;
using System.Xml.Linq;
using AppliConsole.Context.DbContextLogs;

namespace AppliConsole
{
    class Program
    {
        public static IConfigurationRoot IConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).
               AddEnvironmentVariables().Build();
        private static PaieContext ContextSpvPaie = new PaieDbContextFactory().CreateDbContext();
        private static LogsContext ContextLogs = new LogsDbContextFactory().CreateDbContext();
        private static readonly string Environnement = IConfiguration.GetSection("Environnement").Value.ToString();
        //private static readonly string SendInBlueAPIkey = IConfiguration.GetSection("SendInBlueApiKey").Value.ToString();

        public static LogWriter Logs = new("Démarrage", "logs");
        private static readonly string SlackURL = IConfiguration.GetSection("SlackURL").Value.ToString();

        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "";

            // On recupere la date d'aujourd'hui avec l'heure
            var dateToday = DateTime.Now;

            // On recupere toute les applications actives
            var listApp = await (from e in ContextLogs.LogConsoleApp
                              where e.Actif == true
                              select e).ToListAsync();

            // On parcoure la liste
            foreach (var app in listApp)
            {
                Logs.LogWrite(app.Actif.ToString());

                // On compare la date d'aujourd'hui avec la date d'execution
                int differenceMins = (int)dateToday.Subtract((DateTime)app.DateExecution).TotalMinutes;

                // Voir 
                double delta = Convert.ToDouble(app.Delta);
                DateTime test = dateToday.AddMinutes(-1.00 * delta);

                // On recherche l'appChangementEtat 
                var appChangEtat = await (from e in ContextLogs.LogConsoleAppChangementEtat
                                          where e.IdLogConsoleApp == app.Id
                                          orderby e.DateChangementEtat descending
                                          select e).FirstOrDefaultAsync();

                // Si la difference est supérieux ou égal par rapport au delta
                if (differenceMins >= app.Delta)
                {

                    // Sécuriter
                    if (appChangEtat != null)
                    {

                        // On regarde si l'app est en service
                        if (appChangEtat.IsOk == true)
                        {

                            // On créer un nouvelle object
                            var appChange = new LogConsoleAppChangementEtat
                            {
                                IdLogConsoleApp = app.Id,
                                IsOk = false,
                                DateChangementEtat = dateToday
                            };

                            // On ajoute l'objet a la base de donéees
                            ContextLogs.LogConsoleAppChangementEtat.Add(appChange);

                            // On sauvegarde dans la Base de données
                            ContextLogs.SaveChanges();

                            SendSlackMessage("L'appication " + app.Application +" est hors service.");
                        }
                    }
                    else
                    {
                        // On créer un nouvelle object
                        var appChange = new LogConsoleAppChangementEtat
                        {
                            IdLogConsoleApp = app.Id,
                            IsOk = false,
                            DateChangementEtat = dateToday
                        };

                        // On ajoute l'objet a la base de donéees
                        ContextLogs.LogConsoleAppChangementEtat.Add(appChange);

                        // On sauvegarde dans la Base de données
                        ContextLogs.SaveChanges();

                        SendSlackMessage("L'appication " + app.Application + " est hors service.");
                    }
                }
                // Sinon l'application est en service
                else
                {
                    // Sécuriter
                    if (appChangEtat != null)
                    {

                        // On regarde su l'app n'est pas en service
                        if (!(appChangEtat.IsOk == true))
                        {

                            // On créer un nouvelle object
                            var appChange = new LogConsoleAppChangementEtat
                            {
                                IdLogConsoleApp = app.Id,
                                IsOk = true,
                                DateChangementEtat = dateToday
                            };

                            // On ajoute l'objet a la base de donéees
                            ContextLogs.LogConsoleAppChangementEtat.Add(appChange);

                            // On sauvegarde dans la Base de données
                            ContextLogs.SaveChanges();

                            SendSlackMessage("L'appication " + app.Application + " est à nouveau en service.");
                        }

                    }
                    else
                    {
                        // On créer un nouvelle object
                        var appChange = new LogConsoleAppChangementEtat
                        {
                            IdLogConsoleApp = app.Id,
                            IsOk = true,
                            DateChangementEtat = dateToday
                        };

                        // On ajoute l'objet a la base de donéees
                        ContextLogs.LogConsoleAppChangementEtat.Add(appChange);

                        // On sauvegarde dans la Base de données
                        ContextLogs.SaveChanges();

                        SendSlackMessage("L'appication " + app.Application + " est à nouveau en service.");
                    }
                }
            }

            // SendSlackMessage("ok");
        }

        /// <summary>
        /// Envoi de notification Slack
        /// </summary>
        /// <param name="texte"></param>
        private static void SendSlackMessage(string texte)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string message = "[App "+ nameof(Main) + "] [" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] : " + texte;
            Payload payload = new Payload()
            {
                Channel = "",
                Text = message,
                As_user = "false"
            };
            Uri uri = new Uri(SlackURL);
            string payloadJson = JsonConvert.SerializeObject(payload);
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;
                var response = client.UploadValues(uri, "POST", data);

                //The response text is usually "ok"
                Encoding encoding = new UTF8Encoding();
                string responseText = encoding.GetString(response);
            }
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}

