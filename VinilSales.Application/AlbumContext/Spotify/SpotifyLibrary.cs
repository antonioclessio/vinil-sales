using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VinilSales.Application.AlbumContext.Spotify
{
    public class SpotifyLibrary
    {
        private static SpotifyLibrary _instance;
        public static SpotifyLibrary Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpotifyLibrary();
                }

                return _instance;
            }
        }

        public string AccessToken
        {
            get
            {
                if (_Token == null)
                {
                    obterAuthToken();
                }

                return _Token.AccessToken;
            }
        }

        public void ObterCatalogoPop()
        {

        }

        public void ObterCatalogoRock()
        {

        }

        public void ObterCatalogoClassic()
        {

        }

        public void ObterCatalogoMPB()
        {

        }

        private TokenStructure _Token { get; set; }

        private HttpClient criarClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://accounts.spotify.com/api/");

            return client;
        }

        private async void obterAuthToken()
        {
            var client = criarClient();
            var clientID = "0bc559c060fe4eb2b0bc99e109528566";
            var clientSecret = "ced17a7405f9472f8ab4d663cb8bd479";

            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{clientID}:{clientSecret}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            var requestResult = await client.PostAsync("token", new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded"));
            if (requestResult.IsSuccessStatusCode)
            {
                _Token = JsonConvert.DeserializeObject<TokenStructure>(await requestResult.Content.ReadAsStringAsync());
            }
        }

        sealed class TokenStructure
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; private set; }

            [JsonProperty("token_type")]
            public string TokenType { get; private set; }

            [JsonProperty("expires_in")]
            public int ExpireMinutes { get; private set; }

            [JsonProperty("scope")]
            public string Scope { get; private set; }
        }

        sealed class CatalogoResult
        {
            public 
        }
    }
}
