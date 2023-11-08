using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;

        public AddCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
            data.Add(item);
            return this.data.Count - 1;
        }
    }
}
