using ExerciceLectureFichier.Context;
using ExerciceLectureFichier.Context.DbContextFormation;
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
using System.Globalization;
using System.Diagnostics.Metrics;

namespace ExerciceLectureFichier
{
    class Program
    {
        public static IConfigurationRoot IConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).
               AddEnvironmentVariables().Build();
        private static FormationContext Context = new FormationDbContextFactory().CreateDbContext();

        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "";

            // On demande le chemin
            Console.WriteLine("Entrer le chemin du fichier depuis la racine:");

            // On recupere le chemin
            // string path = Console.ReadLine();

            Console.WriteLine("Compilations des données");

            // Le chemin du fichier
            string path = @"C:\git\formation\ExerciceLectureFichier\DossierDesNouvellesDonnees\data.csv";

            // Si le fichier est existant
            if (File.Exists(path))
            {
                int counter = 0;

                // Requete LINQ
                var stuff = from l in File.ReadAllLines(path)
                            // On split notre fichier
                            let data = l.Split(';')
                            select new
                            {
                                // On crée notre object
                                // On lui insert des données
                                Matricule = data[0],
                                Prenom = data[1],
                                Nom = data[2],
                                Date = DateTime.ParseExact(data[3], "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture),
                                Equipe = data[4]
                            };

                foreach ( var l in stuff )
                {
                    Console.WriteLine(l);
                }

                // Autre façon de faire
                // On parcoure les lignes du fichier
                foreach (string line in System.IO.File.ReadLines(path))
                {

                    // On split notre chaine
                    string[] allData = line.Split(';');

                    // On recuperer le matricule
                    var matricule = allData[0];

                    // On recupere le prénom
                    var prenom = allData[1];

                    // On recupere le nom
                    var nom = allData[2];

                    // On recupere la date
                    var date = DateTime.ParseExact(allData[3], "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture);

                    // On recupere l'equipe
                    var equipe = allData[4];

                    // On fait notre requete
                    var item = Context.DonneesDeTest.Where(i => i.Matricule == matricule).FirstOrDefault();

                    // Securiter
                    if (item != null)
                    {
                        if (item.DateMaj < date)
                        {
                            // On remplace les données
                            item.Prenom = prenom;
                            item.Nom = nom;
                            item.DateMaj = date;
                            item.Equipe = equipe;
                        }
                    }
                    // Sinon on créer un nouvelle objet
                    else
                    {

                        var newItem = new DonneesDeTest()
                        {
                            // On lui donne rajoute des valeurs
                            Matricule = matricule,
                            Prenom = prenom,
                            Nom = nom,
                            DateMaj = date,
                            Equipe = equipe
                        };


                        Context.DonneesDeTest.Add(newItem);
                        Context.SaveChanges();

                    }


                }

                // On sauvegarde les changements
                Context.SaveChanges();




            }


            var test = await (from x in Context.DonneesDeTest 
                              orderby x.DateMaj descending 
                              select x).ToListAsync();
            var test2 = await Context.DonneesDeTest.OrderByDescending(x=>x.DateMaj).ToListAsync();



        }


        
    }
}
