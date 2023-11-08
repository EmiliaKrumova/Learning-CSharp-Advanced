namespace CollectionHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<int>> addedIndexes = new Dictionary<string, List<int>> ()
            {
                { "AddCollection", new List<int>() },

                { "AddRemoveCollection", new List<int>() },

                { "MyList", new List<int>() }
            };

            Dictionary<string, List<string>> removedItems = new Dictionary<string, List<string>>()
            {
                //{ "AddCollection", new List<string>() },

                { "AddRemoveCollection", new List<string>() },

                { "MyList", new List<string>() }
            };
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            for (int i = 0; i < input.Length; i++)
            {
               int addCollect =  addCollection.Add(input[i]);
                addedIndexes["AddCollection"].Add(addCollect);
               int removeCollect =  removeCollection.Add(input[i]);
                addedIndexes["AddRemoveCollection"].Add(removeCollect);
                int myListCollect = myList.Add(input[i]);
                addedIndexes["MyList"].Add(myListCollect);
                
            }

            int removeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < removeCount; i++)
            {
                string removed = removeCollection.Remove();
                removedItems["AddRemoveCollection"].Add(removed);
                string removedInList = myList.Remove();
                removedItems["MyList"].Add(removedInList);
            }

            Console.WriteLine(String.Join(" ", addedIndexes[ "AddCollection"]));
            Console.WriteLine(String.Join(" ", addedIndexes["AddRemoveCollection"]));
            Console.WriteLine(String.Join(" ", addedIndexes["MyList"]));

            Console.WriteLine(String.Join(" ", removedItems["AddRemoveCollection"]));
            Console.WriteLine(String.Join(" ", removedItems["MyList"]));
           


        }
    }
}