using Newtonsoft.Json;
using System.Collections.Generic;

namespace VinilSales.Application.SpotifyContext
{
    public class AlbumStructure
    {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        [JsonProperty("artists")]
        public IEnumerable<ArtistStructure> Artists { get; set; }

        [JsonProperty("available_markets")]
        public IEnumerable<string> AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public Dictionary<string, string> ExternalURLs { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public IEnumerable<ImageStructure> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public int ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
