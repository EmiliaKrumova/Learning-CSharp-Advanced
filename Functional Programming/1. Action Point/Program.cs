namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printCollection =input=> Console.WriteLine(String.Join(Environment.NewLine,input));

            // Action<типа на данните> име на тази войд функция = входните данни, които отиват в => това, каквото искаме програмата да направи (в случая да отпечата входния масив на нов ред всеки елемент)


            string[] input = Console.ReadLine().Split();// входни данни


           // List<string> input2 = Console.ReadLine().Split().ToList();

            printCollection(input);// извикване на фунцията, чрез нейното име и подаване на колекцията, която искаме да обработи
        }
    }
}