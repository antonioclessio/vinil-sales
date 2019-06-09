using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VinilSales.Application.SpotifyContext
{
    [Serializable]
    public class ArtistStructure
    {
        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalURLs { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string URI { get; set; }
    }
}
