using System.Collections.Generic;

namespace PUBGStats.Models
{
    public class Roster
    {
        public string Id { get; set; }
        public Team Team { get; set; }
        public List<Participant> Participants { get; set; }
        public Stats Stats { get; set; }
        public string Won { get; set; }
        public string ShardId { get; set; }
    }
}
