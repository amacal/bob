using Bob.Core;
using Bob.Tests.Integration.Stubs;

namespace Bob.Tests.Integration.Steps
{
    public class Core
    {
        private readonly ShellStub shell;
        private readonly RegistryStub registry;
        private readonly StorageStub storage;
        private readonly NetworkStub network;

        public Core()
        {
            this.shell = new ShellStub();
            this.registry = new RegistryStub();
            this.storage = new StorageStub();
            this.network = new NetworkStub();

            Container.Shell = this.shell;
            Container.Registry = this.registry;
            Container.Storage = this.storage;
            Container.Network = this.network;
        }

        public ShellStub Shell
        {
            get { return this.shell; }
        }

        public RegistryStub Registry
        {
            get { return this.registry; }
        }

        public StorageStub Storage
        {
            get { return this.storage; }
        }

        public NetworkStub Network
        {
            get { return this.network; }
        }
    }
}