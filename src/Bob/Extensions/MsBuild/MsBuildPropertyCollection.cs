using System.Collections.Generic;

namespace Bob.Extensions.MsBuild
{
    public class MsBuildPropertyCollection
    {
        private readonly Dictionary<string, MsBuildProperty> items;

        public MsBuildPropertyCollection()
        {
            this.items = new Dictionary<string, MsBuildProperty>();
        }

        public IEnumerable<MsBuildProperty> Items
        {
            get { return this.items.Values; }
        }

        public void Add(MsBuildProperty property)
        {
            this.items.Add(property.Name, property);
        }
    }
}