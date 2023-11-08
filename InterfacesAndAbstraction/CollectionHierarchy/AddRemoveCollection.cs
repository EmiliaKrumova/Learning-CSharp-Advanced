using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> data;
        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
            data.Insert(0, item);
            return 0;
        }

        public  string Remove()
        {
            string stringToRemove = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return stringToRemove;
        }
    }
}
