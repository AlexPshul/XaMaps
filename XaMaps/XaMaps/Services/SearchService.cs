using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XaMaps.Models;

namespace XaMaps.Services
{
    public static class SearchService
    {
        private const string MapsKey = @"AZURE MAPS KEY";
        private static readonly string RequiredParameters = $"json?subscription-key={MapsKey}&api-version=1.0";

        private static readonly HttpClient MapsHttpClient;

        static SearchService()
        {
            MapsHttpClient = new HttpClient { BaseAddress = new Uri("https://atlas.microsoft.com/") };
        }

        public static async Task<FuzzyResults> FuzzySearch(string searchQuery)
        {
            HttpResponseMessage response = await MapsHttpClient.GetAsync($"search/fuzzy/{RequiredParameters}&query={searchQuery}");

            return await ConvertResponseToObject<FuzzyResults>(response);
        }

        public static async Task<RouteDirectionsResult> GetDirections(Position startPosition, params Position[] positions)
        {
            string PositionToString(Position position) => $"{position.Lat},{position.Lon}";

            if (positions == null)
                return null;

            string initialLocationString = PositionToString(startPosition);
            string combinedDestinations = string.Join(":",positions.Select(PositionToString));

            string queryString = $"{initialLocationString}:{combinedDestinations}";
            HttpResponseMessage response = await MapsHttpClient.GetAsync($"route/directions/{RequiredParameters}&instructionsType=text&routeType=fastest&query={queryString}");

            return await ConvertResponseToObject<RouteDirectionsResult>(response);
        }

        private static async Task<T> ConvertResponseToObject<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return default(T);

            string jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
    }
}