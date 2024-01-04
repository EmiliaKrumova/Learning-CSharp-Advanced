namespace CopyDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if(Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, recursive: true);
                // изтрива директорията, дори и когато в нея има файлове (ако няма тази булева хвърля грешка, ако директорията не е празна)
            }
            Directory.CreateDirectory(outputPath);// създава нова директория
            string[] files = Directory.GetFiles(inputPath);// взима пълният път на всички файлове в директорията и ги връща като стринг масив
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);// връща името и разширението на файла като стринг
                string pathToCopy = Path.Combine(outputPath, fileName);// за всички платформи обединява пътя+ името на файла, така че да се запише в правилната директория с правилен адрес
                File.Copy(file, pathToCopy);// копира файл с параметри - самият файл за копиране и целият път (заедно с името на файла), където искам да копирам
            }
        }
    }
}
