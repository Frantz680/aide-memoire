using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string sireneApiBaseUrl = "https://api.insee.fr/entreprises/sirene/V3/";
        string apiKey = "VOTRE_CLE_API"; // Remplacez par votre clé API Sirene

        using (HttpClient client = new HttpClient())
        {
            // Définir l'en-tête d'autorisation avec votre clé API
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Effectuer une requête GET pour obtenir des informations sur une entreprise
            string siret = "SIRET_DE_L_ENTREPRISE"; // Remplacez par le SIRET de l'entreprise que vous recherchez
            string apiUrl = $"{sireneApiBaseUrl}siret/{siret}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Erreur : {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
