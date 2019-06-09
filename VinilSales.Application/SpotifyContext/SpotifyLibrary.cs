using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VinilSales.Application.SpotifyContext
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
            client.BaseAddress = new Uri(EndpointsConst.BaseURL);

            return client;
        }

        private async void obterAuthToken()
        {
            var client = criarClient();
            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{EndpointsConst.ClientID}:{EndpointsConst.SecretKey}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            var requestResult = await client.PostAsync(EndpointsConst.Token, new StringContent(EndpointsConst.GrantType, Encoding.UTF8, "application/x-www-form-urlencoded"));
            if (requestResult.IsSuccessStatusCode)
            {
                _Token = JsonConvert.DeserializeObject<TokenStructure>(await requestResult.Content.ReadAsStringAsync());
            }
        }
    }
}
