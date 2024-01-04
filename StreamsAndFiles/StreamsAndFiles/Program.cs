using System.Text;

namespace StreamsAndFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TraverseDirectory();

        }

        private static void TraverseDirectory()
        {
            string path = @"..\..\..\";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            //to do
            SortedDictionary<string,List<FileInfo>> extentionDictionary = new SortedDictionary<string,List<FileInfo>>();
            string[] filesInDirectory = Directory.GetFiles(inputFolderPath);
            foreach (string file in filesInDirectory)
            {
               FileInfo fileInfo = new FileInfo(file);
                if(!extentionDictionary.ContainsKey(fileInfo.Extension))
                {
                    extentionDictionary.Add(fileInfo.Extension, new List<FileInfo>());


                }
                extentionDictionary[fileInfo.Extension].Add(fileInfo);
            }
            StringBuilder sb = new StringBuilder();

            foreach(var kvp in  extentionDictionary.OrderByDescending(ex=>ex.Value.Count))
            {
                sb.AppendLine(kvp.Key);
                foreach(var info in kvp.Value.OrderBy(f=>f.Length))
                {
                    sb.AppendLine($"--{info.Name} - {(double)info.Length / 1024:f3}kb");
                }
            }
            
            return sb.ToString().TrimEnd();
        }
        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+reportFileName;
            File.WriteAllText(path, textContent);
        }

        private static void CopyBinaryFile()
        {
            FileStream reader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open);
            FileStream writer = new FileStream(@"..\..\..\copyMeCopy.png", FileMode.Create);
            byte[] buffer = new byte[1024];
            while (true)
            {
                int currentBytes = reader.Read(buffer, 0, buffer.Length);
                if (currentBytes == 0)
                {
                    writer.Flush();
                    break;
                }
                writer.Write(buffer, 0, currentBytes);
            }
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
