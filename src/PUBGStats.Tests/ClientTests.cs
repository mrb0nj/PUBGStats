using NUnit.Framework;

namespace PUBGStats.Tests
{
    [TestFixture]
    public class ClientTests
    {
        //ClientRequiresABaseUrl
        [Test]
        public void ClientRequiresABaseUrl()
        {
            //Given/When/Then
            Assert.Throws<System.ArgumentException>(delegate { new Client(string.Empty, "AN_API_KEY"); });
        }

        //ClientRequiresAnAPIKey
        [Test]
        public void ClientRequiresAnAPIKey()
        {
            //Given/When/Then
            Assert.Throws<System.ArgumentException>(delegate { new Client("https://api.host.com/", string.Empty); });
        }

        //ClientAddsBearerHeader
        [Test]
        public void ClientAddsBearerHeader()
        {
            //Given
            var client = new Client("https://api.host.com/", "AN_API_KEY");

            //When
            var httpClient = client.PrepareRequest("/status");

            //Then
            Assert.NotNull(httpClient.DefaultRequestHeaders.Authorization);
            Assert.AreEqual("Bearer", httpClient.DefaultRequestHeaders.Authorization.Scheme);
            Assert.AreEqual("AN_API_KEY", httpClient.DefaultRequestHeaders.Authorization.Parameter);
        }

        //ClientAddsAcceptHeader
        [Test]
        public void ClientAddsAcceptHeader()
        {
            //Given
            var client = new Client("https://api.host.com/", "AN_API_KEY");

            //When
            var httpClient = client.PrepareRequest("/status");

            //Then
            Assert.NotNull(httpClient.DefaultRequestHeaders.Accept);
            Assert.True(httpClient.DefaultRequestHeaders.Accept.Contains(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.api+json")));
        }

        //ClientAddsAcceptEncodingHeader
        [Test]
        public void ClientAddsAcceptEncodingHeader()
        {
            //Given
            var client = new Client("https://api.host.com/", "AN_API_KEY");

            //When
            var httpClient = client.PrepareRequest("/status");

            //Then
            Assert.NotNull(httpClient.DefaultRequestHeaders.Accept);
            Assert.True(httpClient.DefaultRequestHeaders.AcceptEncoding.Contains(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip")));
        }
    }
}
