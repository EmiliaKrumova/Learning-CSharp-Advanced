namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string,List<decimal>> studentsData = new Dictionary<string,List<decimal>>();
            for(int i = 0; i < countOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = input[0];
                decimal studentGrade = decimal.Parse(input[1]);
                if (!studentsData.ContainsKey(studentName))
                {
                    studentsData[studentName] = new List<decimal>();
                }
                studentsData[studentName].Add(studentGrade);
            }
            foreach(var kvp in studentsData)
            {
                Console.WriteLine($"{kvp.Key} -> {String.Join(" ",kvp.Value.Select(v=>v.ToString("F2")))} (avg: {kvp.Value.Average():f2})");

                // начин да форматираш с два знака, след десетичната при String.Join!!!


                //Console.WriteLine($"{name} -> {string.Join(" ", b[name].Select(n => n.ToString("F2")))} (avg: {b[name].Average():F2})");
            }
        }
    }
}