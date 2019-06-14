namespace VinilSales.Application.SpotifyContext
{
    public static class EndpointsConst
    {
        public static string Token = "https://accounts.spotify.com/api/token";
        public static string ClientID = "0bc559c060fe4eb2b0bc99e109528566";
        public static string SecretKey = "ced17a7405f9472f8ab4d663cb8bd479";
        public static string GrantType = "grant_type=client_credentials";

        public static int TotalRegistros = 50;
        public static string BaseURL = "https://api.spotify.com/v1/";
        public static string Albuns_Classic = $"recommendations?seed_genres=classical&limit={TotalRegistros}";
        public static string Albuns_POP = $"recommendations?seed_genres=pop&limit={TotalRegistros}";
        public static string Albuns_ROCK = $"recommendations?seed_genres=rock&limit={TotalRegistros}";
        public static string Albuns_MPB = $"recommendations?seed_genres=mpb&limit={TotalRegistros}";
    }
}
