using System;

namespace _8._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string,string> contests = new Dictionary<string,string>();
            SortedDictionary<string,Dictionary<string,int>> students = new SortedDictionary<string,Dictionary<string,int>>();
            while((command = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }
            string data;
            while((data = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = data.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                if (!contests.ContainsKey(contest))
                {
                    continue;
                }
                if (contests[contest] != password)
                {
                    continue;
                }
                if (!students.ContainsKey(username))
                {
                    students[username] = new Dictionary<string,int>();
                }
                if (!students[username].ContainsKey(contest))
                {
                    students[username].Add(contest, points);
                }
                if (students[username][contest] < points)
                {
                    students[username][contest] = points;
                }
               
            }
            string bestStudent = "";
            int bestPoints = 0;

            //string bestCandidate = candidates
            //   .OrderByDescending(c => c.Value.Values.Sum())
            //   .First().Key;

            //int bestCandidateTotalPoints = candidates[bestCandidate].Values.Sum();

            foreach ( var student in students)
            {
                int sum = 0;
                foreach (var contest in student.Value)
                {
                    sum += contest.Value;
                }
                if(sum > bestPoints)
                {
                    bestPoints = sum;
                    bestStudent = student.Key;
                    
                }

            }
            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
          
            foreach ( var student in students)
            {
                Console.WriteLine(student.Key);
                Dictionary<string,int> sorted = new Dictionary<string,int>();
                
                foreach(var contest in student.Value)
                {
                    if (!sorted.ContainsKey(contest.Key))
                    {
                        sorted[contest.Key] = contest.Value;
                    }
                    //
                }
                foreach( var contest in sorted.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
                
            }
        }
    }
}