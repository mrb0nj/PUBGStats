using NUnit.Framework;
using PUBGStats.Enums;
using PUBGStats.Helpers;

namespace PUBGStats.Tests
{
    [TestFixture]
    public class EndpointHelperTests
    {
        //EndpointHelperAcceptsResource
        [Test]
        public void EndpointHelperAcceptsResource()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("/status");

            //Then
            Assert.True(url.EndsWith("/status"));
        }

        //EndpointHelperRequiresResource
        [Test]
        public void EndpointHelperRequiresResource()
        {
            //Given
            var helper = new EndpointHelper();
            
            //When
            Assert.Throws<System.ArgumentException>( delegate { helper.GetUrl(string.Empty); });
        }

        //EndpointHelperAddsLeadingSlashIfMissing
        [Test]
        public void EndpointHelperAddsLeadingSlashIfMissing()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("status");

            //Then
            Assert.True(url.Contains("/status"));
        }

        //EndpointHelperAcceptsPlatformArgument
        [Test]
        public void EndpointHelperAcceptsPlatformArgument()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("/status", Platform.Xbox);

            //Then
            Assert.True(url.Contains("xbox"));
        }

        //EndpointHelperProvidesDefaultPlatform
        [Test]
        public void EndpointHelperProvidesDefaultPlatform()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("/status");

            //Then
            Assert.True(url.Contains("pc"));
        }

        //EndpointHelperProvidesDefaultPlatform
        [Test]
        public void EndpointHelperAcceptsRegionArgument()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("/status", region: Region.NorthAmerica);

            //Then
            Assert.True(url.Contains("na"), "url does not contain 'na': {0}", url);
        }

        //EndpointHelperProvidesDefaultPlatform
        [Test]
        public void EndpointHelperProvidesDefaultRegion()
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl("/status");

            //Then
            Assert.True(url.Contains("eu"), "url does not contain 'eu': {0}", url);
        }

        //HelperFormatsUrl - iterate all possibilities
        [TestCase("/status", Platform.PC, Region.KoreaAndJapan, "pc-krjp/status")]
        [TestCase("/status", Platform.PC, Region.Europe, "pc-eu/status")]
        [TestCase("/status", Platform.PC, Region.NorthAmerica, "pc-na/status")]
        [TestCase("/status", Platform.PC, Region.Oceania, "pc-oc/status")]
        [TestCase("/status", Platform.PC, Region.Kakao, "pc-kakao/status")]
        [TestCase("/status", Platform.PC, Region.SouthEastAsia, "pc-sea/status")]
        [TestCase("/status", Platform.PC, Region.SouthAndCentralAmerica, "pc-sa/status")]
        [TestCase("/status", Platform.PC, Region.Asia, "pc-as/status")]
        [TestCase("/status", Platform.Xbox, Region.Asia, "xbox-as/status")]
        [TestCase("/status", Platform.Xbox, Region.Europe, "xbox-eu/status")]
        [TestCase("/status", Platform.Xbox, Region.NorthAmerica, "xbox-na/status")]
        [TestCase("/status", Platform.Xbox, Region.Oceania, "xbox-oc/status")]
        public void EndpointHelperFormatsUrl(string resource, Platform platform, Region region, string expected)
        {
            //Given
            var helper = new EndpointHelper();

            //When
            var url = helper.GetUrl(resource, platform, region);

            //Then
            Assert.AreEqual(expected, url);
        }

        //EndpointHelperThrowsErrorWithInvalidPlatformRegionCombination
        [TestCase(Platform.Xbox, Region.KoreaAndJapan)]
        [TestCase(Platform.Xbox, Region.Kakao)]
        [TestCase(Platform.Xbox, Region.SouthEastAsia)]
        [TestCase(Platform.Xbox, Region.SouthAndCentralAmerica)]
        public void EndpointHelperThrowsErrorWithInvalidPlatformRegionCombination(Platform platform, Region region)
        {
            //Given
            var helper = new EndpointHelper();

            //When/Then
            Assert.Throws<System.ArgumentException>(delegate { helper.GetUrl("/status", platform, region); });
        }

        //EndpointHelperThrowsErrorWithInvalidPlatformRegionCombination
        [TestCase(Platform.Xbox, Region.Asia)]
        [TestCase(Platform.Xbox, Region.Europe)]
        [TestCase(Platform.Xbox, Region.NorthAmerica)]
        [TestCase(Platform.Xbox, Region.Oceania)]
        public void EndpointHelperDoesNotThrowsErrorWithValidPlatformRegionCombination(Platform platform, Region region)
        {
            //Given
            var helper = new EndpointHelper();

            //When/Then
            Assert.DoesNotThrow(delegate { helper.GetUrl("/status", platform, region); });
        }
    }
}
