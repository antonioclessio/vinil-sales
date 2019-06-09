using Newtonsoft.Json;
using System;
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

        public SeedGenreResult ObterCatalogoPop()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_POP);
            return albuns;
        }

        public SeedGenreResult ObterCatalogoRock()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_ROCK);
            return albuns;
        }

        public SeedGenreResult ObterCatalogoClassic()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_Classic);
            return albuns;
        }

        public SeedGenreResult ObterCatalogoMPB()
        {
            var albuns = obterAlbuns(EndpointsConst.Albuns_MPB);
            return albuns;
        }

        private TokenStructure _Token { get; set; }

        private void obterAuthToken()
        {
            var client = new HttpClient();
            var basicKey = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{EndpointsConst.ClientID}:{EndpointsConst.SecretKey}"));
            var basicAuthHeader = new AuthenticationHeaderValue("Basic", basicKey);
            client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            var requestResult = client.PostAsync(EndpointsConst.Token, new StringContent(EndpointsConst.GrantType, Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
            if (requestResult.IsSuccessStatusCode)
            {
                _Token = JsonConvert.DeserializeObject<TokenStructure>(requestResult.Content.ReadAsStringAsync().Result);
            }
        }

        private SeedGenreResult obterAlbuns(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(EndpointsConst.BaseURL);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            var requestResult = client.GetAsync(url).Result;
            if (requestResult.IsSuccessStatusCode)
            {
                var content = requestResult.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<SeedGenreResult>(content);
                return result;
            }

            return null;
        }
    }
}
