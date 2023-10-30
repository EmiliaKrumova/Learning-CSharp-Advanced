namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Predicate<string> isShortEnough = name => name.Length <= lenght;
            names = names.Where(w=>isShortEnough(w)).ToArray();


            Action < string[]> printNames = names => Console.WriteLine(String.Join(Environment.NewLine, names));
            printNames(names);
        }
    }
}