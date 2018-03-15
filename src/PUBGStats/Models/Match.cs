using System;
using System.Collections.Generic;

namespace PUBGStats.Models
{
    public class Match
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Duration { get; set; }
        public List<Roster> Rosters { get; set; }
        public Rounds Rounds { get; set; }
        public List<Asset> Assets { get; set; }
        public Spectator Spectators { get; set; }
        public Stats Stats { get; set; }
        public string GameMode { get; set; }
        public string PatchVersion { get; set; }
        public string TitleId { get; set; }
        public string ShardId { get; set; }

    }
}
