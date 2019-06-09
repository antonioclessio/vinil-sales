using Newtonsoft.Json;
using System;

namespace VinilSales.Application.SpotifyContext
{
    [Serializable]
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
