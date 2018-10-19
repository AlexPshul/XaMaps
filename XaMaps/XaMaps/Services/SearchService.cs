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
            return await Task.FromResult(new FuzzyResults());
        }

        public static async Task<RouteDirectionsResult> GetDirections(Position startPosition, params Position[] positions)
        {
            return await Task.FromResult<RouteDirectionsResult>(new RouteDirectionsResult());
        }

        private static async Task<T> ConvertResponseToObject<T>(HttpResponseMessage response)
        {
            return await Task.FromResult(default(T));
        }
    }
}