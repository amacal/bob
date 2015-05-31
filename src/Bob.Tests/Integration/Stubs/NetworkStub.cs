using Bob.Core;

namespace Bob.Tests.Integration.Stubs
{
    public class NetworkStub : INetwork
    {
        public byte[] Get(string url)
        {
            return new byte[0];
        }
    }
}
