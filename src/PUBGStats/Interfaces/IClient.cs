using System.Net.Http;

namespace PUBGStats.Interfaces
{
    public interface IClient
    {
        HttpClient PrepareRequest(string resource);
    }
}
