using Newtonsoft.Json;

namespace VinilSales.Application.SpotifyContext
{
    public class ImageStructure
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
