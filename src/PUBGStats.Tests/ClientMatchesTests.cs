using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace PUBGStats.Tests
{
    [TestFixture]
    public class ClientMatchesTests
    {
        private const string _matchJson = @"{
  ""id"": ""a-match-id"",
  ""createdAt"": ""2018-03-12T14:08:16Z"",
  ""duration"": 0,
  ""rosters"": [
    {
      ""id"": ""string"",
      ""team"": {},
      ""participants"": [
        {
          ""id"": ""string"",
          ""stats"": {},
          ""actor"": ""string"",
          ""shardId"": ""string""
        }
      ],
      ""stats"": {},
      ""won"": ""string"",
      ""shardId"": ""string""
    }
  ],
  ""rounds"": {},
  ""assets"": [
    {
      ""id"": ""string"",
      ""titleId"": ""string"",
      ""shardId"": ""string"",
      ""name"": ""string"",
      ""description"": ""string"",
      ""createdAt"": ""2018-03-12T14:08:16Z"",
      ""filename"": ""string"",
      ""contentType"": ""string"",
      ""URL"": ""string""
    }
  ],
  ""spectators"": {},
  ""stats"": {},
  ""gameMode"": ""string"",
  ""patchVersion"": ""string"",
  ""titleId"": ""string"",
  ""shardId"": ""string"",
  ""tags"": {}
}";
        private readonly string _matchesJson = string.Format("[{0}]", _matchJson);
        //ClientGetsMatches
        [Test]
        public void ClientGetsMatches()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(_matchesJson);
            var client = clientMock.Object;

            //When
            var matches = client.GetMatches();

            //Then
            Assert.IsNotNull(matches);
            Assert.AreEqual(1, matches.Count());

            var match = matches.First();
            Assert.AreEqual("a-match-id", match.Id);
        }

        //ClientGetsMatch
        [Test]
        public void ClientGetsMatch()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(_matchJson);
            var client = clientMock.Object;

            //When
            var match = client.GetMatch("a-match-id");

            //Then
            Assert.IsNotNull(match);
            Assert.AreEqual("a-match-id", match.Id);
        }

        //ClientReturnsNullWhenGetMatchesJsonIsEmpty
        [Test]
        public void ClientReturnsNullWhenGetMatchesJsonIsEmpty()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(string.Empty);
            var client = clientMock.Object;

            //When
            var matches = client.GetMatches();

            //Then
            Assert.IsNull(matches);
        }

        //ClientReturnsNullWhenGetMatchesFails
        [Test]
        public void ClientReturnsNullWhenGetMatchesFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Throws(new Exception());
            var client = clientMock.Object;

            //When
            var matches = client.GetMatches();

            //Then
            Assert.IsNull(matches);
        }

        //ClientReturnsNullWhenGetMatchesDeseializationFails
        [Test]
        public void ClientReturnsNullWhenGetMatchesDeseializationFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns("|INVALID|JSON|");
            var client = clientMock.Object;

            //When
            var matches = client.GetMatches();

            //Then
            Assert.IsNull(matches);
        }

        //ClientReturnsNullWhenGetMatchJsonIsEmpty
        [Test]
        public void ClientReturnsNullWhenGetMatchJsonIsEmpty()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns(string.Empty);
            var client = clientMock.Object;

            //When
            var match = client.GetMatch("a-match-id");

            //Then
            Assert.IsNull(match);
        }

        //ClientReturnsNullWhenGetMatchFails
        [Test]
        public void ClientReturnsNullWhenGetMatchFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Throws(new Exception());
            var client = clientMock.Object;

            //When
            var match = client.GetMatch("a-match-id");

            //Then
            Assert.IsNull(match);
        }

        //ClientReturnsNullWhenGetMatchDeseializationFails
        [Test]
        public void ClientReturnsNullWhenGetMatchDeseializationFails()
        {
            //Given
            var clientMock = new Mock<Client>("https://api.host.com", "AN_API_KEY");
            clientMock.Setup(c => c.GetJson()).Returns("|INVALID|JSON|");
            var client = clientMock.Object;

            //When
            var match = client.GetMatch("a-match-id");

            //Then
            Assert.IsNull(match);
        }
    }
}
