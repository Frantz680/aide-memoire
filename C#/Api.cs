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


// Autre exemple de requete d'api

const axios = require('axios');

const clientId = 'VotreClientID';
const clientSecret = 'VotreClientSecret';
const grantType = 'password'; // Ou 'client_credentials' selon le flux OAuth2 que vous utilisez
const username = 'VotreNomUtilisateur';
const password = 'VotreMotDePasse';

const tokenUrl = 'https://sandbox-oauth.piste.gouv.fr/api/oauth/token';

// Les données à inclure dans la demande
const data = {
  grant_type: grantType,
  client_id: clientId,
  client_secret: clientSecret,
  username: username, // Inclus uniquement pour le flux 'password'
  password: password, // Inclus uniquement pour le flux 'password'
};

// En-tête de la demande
const config = {
  headers: {
    'Content-Type': 'application/x-www-form-urlencoded',
  },
};

axios.post(tokenUrl, data, config)
  .then((response) => {
    // Traitement de la réponse
    console.log('Token d\'accès obtenu :', response.data.access_token);
  })
  .catch((error) => {
    // Gestion des erreurs
    console.error('Erreur lors de la demande de token :', error);
  });
