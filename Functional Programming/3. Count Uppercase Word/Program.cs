namespace _3._Count_Uppercase_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = word => word[0] == word.ToUpper()[0];// първата буква да е главна

            //n => n[0] == n.ToUpper()[0];
            string[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(word=>predicate(word))
                .ToArray();
            foreach(string word in input)
            {
                Console.WriteLine(word);
            }

            
        }
    }
}