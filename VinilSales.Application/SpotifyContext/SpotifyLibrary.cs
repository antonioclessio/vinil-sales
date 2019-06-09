using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public Task<SeedGenreResult> ObterCatalogoPop()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_POP);
            return albuns;
        }

        public Task<SeedGenreResult> ObterCatalogoRock()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_ROCK);
            return albuns;
        }

        public Task<SeedGenreResult> ObterCatalogoClassic()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_Classic);
            return albuns;
        }

        public Task<SeedGenreResult> ObterCatalogoMPB()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_MPB);
            return albuns;
        }

        private TokenStructure _Token { get; set; }

        private async void obterAuthToken()
        {
            var client = new HttpClient();
            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{EndpointsConst.ClientID}:{EndpointsConst.SecretKey}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            var requestResult = await client.PostAsync(EndpointsConst.Token, new StringContent(EndpointsConst.GrantType, Encoding.UTF8, "application/x-www-form-urlencoded"));
            if (requestResult.IsSuccessStatusCode)
            {
                _Token = JsonConvert.DeserializeObject<TokenStructure>(await requestResult.Content.ReadAsStringAsync());
            }
        }

        private async Task<SeedGenreResult> obterAlbuns(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(EndpointsConst.BaseURL);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            var requestResult = await client.GetAsync(url);
            if (requestResult.IsSuccessStatusCode)
            {
                var content = await requestResult.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SeedGenreResult>(content);
                return result;
            }

            return null;
        }
    }
}
