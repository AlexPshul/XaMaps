using System;
using System.Net.Http;

namespace XaMaps.Services
{
    public static class MapsConsts
    {
        private const string MapsKey = @"f7H-NrSmB0Sjau25gKw2K2JmGeP0hQ6YlfRnhyvBU5U";
        public static readonly string RequiredParameters = $"json?subscription-key={MapsKey}&api-version=1.0";
    }
}