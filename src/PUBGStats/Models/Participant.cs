using System.Collections.Generic;

namespace PUBGStats.Models
{
    public class Participant
    {
        public string Id { get; set; }
        public Stats Stats { get; set; }
        public string Actor { get; set; }
        public string ShardId { get; set; }
    }
}
