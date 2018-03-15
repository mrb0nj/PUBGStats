using PUBGStats.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace PUBGStats.Interfaces
{
    public interface IClient
    {
        HttpClient PrepareRequest(string resource);
        Status GetStatus();
        IEnumerable<Match> GetMatches();
        Match GetMatch(string id);
        string GetJson();
    }
}
