namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();//входни данни

            Action<List<string>> printList = list => list.ForEach(x => Console.WriteLine($"Sir {x}"));
            // войд функция с име "принтЛист", която е равна на входния лист,
            // всеки елемент от който го принтираме по модела "Сър (елемента)"


            printList(list);// извикване на функцията, чрез нейното име и й подаваме входни данни
        }
    }
}