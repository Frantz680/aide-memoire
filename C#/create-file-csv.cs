using ExportEntreprise.Context;
using ExportEntreprise.Context.DbContextSpvPaie;
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
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace ExportEntreprise
{
    class Program
    {
        public static IConfigurationRoot IConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).
               AddEnvironmentVariables().Build();
        private static PaieContext ContextSpvPaie = new PaieDbContextFactory().CreateDbContext();
        private static LogsContext ContextLogs = new LogsDbContextFactory().CreateDbContext();
        private static readonly string Environnement = IConfiguration.GetSection("Environnement").Value.ToString();
        private static readonly string SendInBlueAPIkey = IConfiguration.GetSection("SendInBlueApiKey").Value.ToString();

        public static LogWriter Logs = new("Démarrage", "logs");
        private static readonly string SlackURL = IConfiguration.GetSection("SlackURL").Value.ToString();

        public static IConfiguration _configuration;



        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "";
            var test = await (from e in ContextSpvPaie.Entreprise
                              where e.CodeEntreprise == "T010"
                              select e).FirstOrDefaultAsync();

            Console.WriteLine(test);

            // On recupere toutes les conventions
            var dictConvention = ContextPaie.ConventionCollective.ToDictionary(c => c.CodeConventionCollective, c => c.LibelleConventionCollective);


            // On recupere la liste avec une requete des conventions avant
            var listEntrepriseConvention = await (from e in ContextPaie.Entreprise
                                                  where e.Actif
                                                  join ea in ContextPaie.EntrepriseAlias on e.Alias equals ea.Alias
                                                  where ea.Actif
                                                  select new
                                                  {
                                                      Alias = e.Alias,
                                                      Code_Entreprise = e.CodeEntreprise,
                                                      Raison_Social = e.RaisonSociale,
                                                      Siret = e.Siret,
                                                      CC1 = e.ConventionCollective1,
                                                      // Si le dict contient la clée alors on lui affiche la valeur du dict sinon c'est null
                                                      Libelle_CC1 = dictConvention.ContainsKey(e.ConventionCollective1) ? dictConvention[e.ConventionCollective1] : null,
                                                      CC2 = e.ConventionCollective2,
                                                      Libelle_CC2 = dictConvention.ContainsKey(e.ConventionCollective2) ? dictConvention[e.ConventionCollective1] : null,
                                                      CC3 = e.ConventionCollective3,
                                                      Libelle_CC3 = dictConvention.ContainsKey(e.ConventionCollective3) ? dictConvention[e.ConventionCollective1] : null,
                                                  }).ToListAsync();

            // On recupere la liste avec une sous requete 
            /* var listEntrepriseConvention = await (from e in ContextSpvPaie.Entreprise
                                                  where e.Actif 
                                                  join ea in ContextPaie.EntrepriseAlias on e.Alias equals ea.Alias
                                                  where ea.Actif
                                                  select new
                                                  {
                                                      Alias = e.Alias,
                                                      Code_Entreprise = e.CodeEntreprise,
                                                      Raison_Social = e.RaisonSociale,
                                                      Siret = e.Siret,
                                                      CC1 = e.ConventionCollective1,
                                                      Libelle_CC1 = (from x in ContextPaie.ConventionCollective where x.CodeConventionCollective == e.ConventionCollective1 select x.LibelleConventionCollective).FirstOrDefault(),
                                                      CC2 = e.ConventionCollective2,
                                                      Libelle_CC2 = (from x in ContextPaie.ConventionCollective where x.CodeConventionCollective == e.ConventionCollective2 select x.LibelleConventionCollective).FirstOrDefault(),
                                                      CC3 = e.ConventionCollective3,
                                                      Libelle_CC3 = (from x in ContextPaie.ConventionCollective where x.CodeConventionCollective == e.ConventionCollective3 select x.LibelleConventionCollective).FirstOrDefault(),
                                                  }).ToListAsync();
            */

            string path = "C:/Users/fd/Downloads/";
            string nomFichier = "Export_Conventions_Collectives";
            string extension = ".xlsx";
            FileInfo fileInfo = new FileInfo(path + nomFichier + extension);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                fileInfo = new FileInfo(path + nomFichier + extension);
            }

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Export des conventions collectives");
                worksheet.Cells.LoadFromCollection(listEntrepriseConvention);
                worksheet.InsertRow(1, 1);
                worksheet.Cells[1, 1].Value = "Alias";
                worksheet.Cells[1, 2].Value = "Code entreprise";
                worksheet.Cells[1, 3].Value = "Raison social";
                worksheet.Cells[1, 4].Value = "Siret";
                worksheet.Cells[1, 5].Value = "Code convention 1";
                worksheet.Cells[1, 6].Value = "Libelle cc1";
                worksheet.Cells[1, 7].Value = "Code convention 2";
                worksheet.Cells[1, 8].Value = "Libelle cc2";
                worksheet.Cells[1, 9].Value = "Code convention 3";
                worksheet.Cells[1, 10].Value = "Libelle cc3";

                int totalRows = worksheet.Dimension.End.Row;
                int totalCols = worksheet.Dimension.End.Column;

                var headerCells = worksheet.Cells[1, 1, 1, totalCols];
                var headerFont = headerCells.Style.Font;
                headerFont.Bold = true;

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // Ajuste la largeur des colonnes
                worksheet.PrinterSettings.RepeatRows = new ExcelAddress("1:1"); //Répète la 1ère ligne (entête)
                excelPackage.SaveAs(fileInfo);
            }
        }
    }
}

https://riptutorial.com/epplus => doc
https://riptutorial.com/epplus/example/26413/complete-example-with-all-styles => doc pour le style
