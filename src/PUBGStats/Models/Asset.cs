using System;

namespace PUBGStats.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string TitleId { get; set; }
        public string ShardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
    }
}
