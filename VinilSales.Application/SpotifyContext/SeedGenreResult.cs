using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VinilSales.Application.SpotifyContext
{
    [Serializable]
    public class SeedGenreResult
    {
        [JsonProperty("tracks")]
        public List<TrackStructure> Tracks { get; set; }

        [JsonProperty("seeds")]
        public List<SeedStructure> Seeds { get; set; }
    }
}
