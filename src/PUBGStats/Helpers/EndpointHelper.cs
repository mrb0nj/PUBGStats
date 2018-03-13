using PUBGStats.Enums;
using PUBGStats.Extensions;
using System;

namespace PUBGStats.Helpers
{
    internal class EndpointHelper
    {
        internal string GetUrl(string resource, Platform platform = Platform.PC, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Resource is required");

            if (!resource.StartsWith("/"))
                resource = string.Format("/{0}", resource);

            if (platform == Platform.Xbox && (region != Region.Asia && region != Region.Europe && region != Region.NorthAmerica && region != Region.Oceania))
                throw new ArgumentException(string.Format("Region '{0}' is invalid for Xbox platform", region));
            
            return string.Format("{0}-{1}{2}", platform.GetDescription(), region.GetDescription(), resource);
        }
    }
}
