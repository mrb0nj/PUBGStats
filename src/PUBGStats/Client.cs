using PUBGStats.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PUBGStats
{
    public class Client : IClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public Client(string baseUrl, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("BaseUrl is reqired.");

            _baseUrl = baseUrl;

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("APIKey is required.");

            _apiKey = apiKey;
        }

        public HttpClient PrepareRequest(string resource)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            return client;
        }
    }
}
