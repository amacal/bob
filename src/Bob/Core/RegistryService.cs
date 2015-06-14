using Microsoft.Win32;
using System;

namespace Bob.Core
{
    public class RegistryService : IRegistry
    {
        public string[] Keys(string path)
        {
            using (RegistryKey registry = this.Open(path))
            {
                return registry.GetSubKeyNames();
            }
        }

        public string Value(string path)
        {
            int index = path.LastIndexOf('\\');
            string key = path.Substring(0, index);
            string name = path.Substring(index + 1);

            return Convert.ToString(Registry.GetValue(key, name, null));
        }

        private RegistryKey Open(string path)
        {
            int index = path.IndexOf('\\');
            string name = path.Substring(0, index);
            string rest = path.Substring(index + 1);

            if (name == Registry.LocalMachine.Name)
                return Registry.LocalMachine.OpenSubKey(rest);

            return null;
        }
    }
}