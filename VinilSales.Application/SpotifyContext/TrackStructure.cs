using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VinilSales.Application.SpotifyContext
{
    [Serializable]
    public class TrackStructure
    {

        [JsonProperty("album")]
        public AlbumStructure Album { get; set; }

        [JsonProperty("artists")]
        public IEnumerable<ArtistStructure> Artists { get; set; }

        [JsonProperty("available_markets")]
        public IEnumerable<string> AvaliableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public int Duration { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        [JsonProperty("external_ids")]
        public Dictionary<string, string> ExternalIds { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalURLs { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewURL { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string URI { get; set; }
    }
}
