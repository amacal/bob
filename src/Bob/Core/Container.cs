namespace Bob.Core
{
    public static class Container
    {
        static Container()
        {
            Container.Storage = new StorageService();
            Container.Shell = new ShellService();
            Container.Registry = new RegistryService();
            Container.Network = new NetworkService();
        }

        public static IStorage Storage { get; set; }

        public static IShell Shell { get; set; }

        public static IRegistry Registry { get; set; }

        public static INetwork Network { get; set; }
    }
}