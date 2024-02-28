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


// Autre exemple de requete d'api avec axios

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

// Autre requete

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

class Program
{
    static async Task Main()
    {
        string clientId = "VotreClientID";
        string clientSecret = "VotreClientSecret";
        string grantType = "password"; // Ou "client_credentials" selon le flux OAuth2 que vous utilisez
        string username = "VotreNomUtilisateur";
        string password = "VotreMotDePasse";
        string tokenUrl = "https://sandbox-oauth.piste.gouv.fr/api/oauth/token";

        using (HttpClient client = new HttpClient())
        {
            var requestData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", grantType),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("username", username), // Inclus uniquement pour le flux 'password'
                new KeyValuePair<string, string>("password", password), // Inclus uniquement pour le flux 'password'
            };

            var requestContent = new FormUrlEncodedContent(requestData);

            try
            {
                var response = await client.PostAsync(tokenUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Token d'accès obtenu : " + responseContent);
                }
                else
                {
                    Console.WriteLine("Erreur lors de la demande de token : " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }
    }
}


// API Iban
// https://github.com/skwasjer/IbanNet

using IbanNet;
using IbanNet.DataAnnotations;
using IbanNet.Validation.Results;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Exemple de code IBAN valide
        string iban = "FR1420041010050500013M02606";

        // Valider l'IBAN
        IIbanValidator validator = new IbanValidator();
        ValidationResult validationResult = validator.Validate(iban);

        // Vérifier si l'IBAN est valide
        if (validationResult.IsValid)
        {
            Console.WriteLine($"L'IBAN '{iban}' est valide.");
        }
        else
        {
            Console.WriteLine($"L'IBAN '{iban}' n'est pas valide :");
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine($" - {error.ErrorMessage}");
            }
        }
    }
}
