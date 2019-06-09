using Newtonsoft.Json;

namespace VinilSales.Application.SpotifyContext
{
    public class TokenStructure
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
}
