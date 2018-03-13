using Moq;
using NUnit.Framework;
using PUBGStats.Interfaces;
using System;

namespace PUBGStats.Tests
{
    [TestFixture]
    public class ClientStatusTests
    {
        private const string _statusJson = @"{
  ""data"": {
    ""type"": ""status"",
    ""id"": ""pubg-api"",
    ""attributes"": {
      ""releasedAt"": ""2018-03-12T14:08:16Z"",
      ""version"": ""master""
    }
  }
}";
        //ClientGetsStatus
        [Test]
        public void ClientGetsStatus()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(_statusJson);
            var client = clientMock.Object;

            //When
            var status = client.GetStatus();

            //Then
            Assert.IsNotNull(status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(status.Version));
            Assert.AreNotEqual(DateTime.MinValue, status.ReleasedAt);
        }

        //ClientReturnsNullWhenJsonIsEmpty
        [Test]
        public void ClientReturnsNullWhenJsonIsEmpty()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(string.Empty);
            var client = clientMock.Object;

            //When
            var status = client.GetStatus();

            //Then
            Assert.IsNull(status);
        }

        //ClientReturnsNullWhenGetJsonFails
        [Test]
        public void ClientReturnsNullWhenGetJsonFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Throws(new Exception());
            var client = clientMock.Object;

            //When
            var status = client.GetStatus();

            //Then
            Assert.IsNull(status);
        }

        //ClientReturnsNullWhenDeseializationFails
        [Test]
        public void ClientReturnsNullWhenDeseializationFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns("|INVALID|JSON|");
            var client = clientMock.Object;

            //When
            var status = client.GetStatus();

            //Then
            Assert.IsNull(status);
        }
    }
}
