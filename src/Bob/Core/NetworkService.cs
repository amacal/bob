using System.Net;

namespace Bob.Core
{
    public class NetworkService : INetwork
    {
        public byte[] Get(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }
    }
}