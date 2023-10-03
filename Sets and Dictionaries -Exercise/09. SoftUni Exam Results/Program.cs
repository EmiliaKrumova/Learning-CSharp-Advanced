namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            SortedDictionary<string,int> students = new SortedDictionary<string,int>();
            SortedDictionary<string, int> languages = new SortedDictionary<string,int>();
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                if(tokens.Length == 2)// user banned!
                {
                    if ((students.ContainsKey(username)))
                    {
                        students.Remove(username);
                    }
                }
                else
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);
                    if(!students.ContainsKey(username) )
                    {
                        students[username] = 0;
                    }
                    if (students[username] < points)
                    {
                        students[username] = points;
                    }
                    
                    if(!languages.ContainsKey(language) )
                    {
                        languages[language] = 0;
                    }
                    
                    languages[language]++;
                }
            }
            Console.WriteLine("Results:");
            foreach(var student in students.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach( var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}