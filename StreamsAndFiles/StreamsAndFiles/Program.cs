namespace StreamsAndFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EvenLines();
            //LineNumbers();
            //WordCount();

        }

        private static void WordCount()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            string[] text = File.ReadAllLines(@"..\..\..\text.txt");
            string[] words = File.ReadAllLines(@"..\..\..\words.txt");
            foreach (string word in words)
            {

                if (!output.ContainsKey(word.ToLower()))
                {
                    output.Add(word.ToLower(), 0);
                }


            }
            foreach (var line in text)
            {
                foreach (var word in output)
                {
                    if (line.Contains(word.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        output[word.Key]++;
                    }
                }
            }
            foreach (var word in output.OrderByDescending(x => x.Value))
            {
                string result = $"{word.Key} - {word.Value}{Environment.NewLine}";
                File.AppendAllText(@"..\..\..\actualResults.txt", result);
            }
        }

        private static void LineNumbers()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\text.txt");
            List<string> output = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(letter => char.IsLetter(letter));
                int symbolsCount = lines[i].Count(symbol => char.IsPunctuation(symbol));
                string line = $"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})";
                output.Add(line);
            }
            File.WriteAllLines("output.txt", output);
        }

        private static void EvenLines()
        {
            StreamReader reader = new StreamReader(@"..\..\..\text.txt");
            string[] symbols = new string[] { "-", ",", ".", "!", "?" };


            string resultString = reader.ReadLine();
            int countOfLines = 0;
            while (resultString != null)
            {
                if (countOfLines % 2 == 0)
                {
                    foreach (var symbol in symbols)
                    {
                        resultString = resultString.Replace(symbol, "@");
                    }

                    Console.WriteLine(String.Join(" ", resultString.Split().Reverse()));
                }
                countOfLines++;
                resultString = reader.ReadLine();

            }
        }
    }
}
