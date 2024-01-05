using System.IO;

using System.IO.Compression;

namespace ZipАndExtract

{
    public class ZipAndExtract
    
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\copyMe.png";// входен файл(пътя)
            string zipArchiveFile = @"..\..\..\archive.zip";// името и пътя на зип файла
            string extractedFile = @"..\..\..\extracted.png";// името и пътя на финалния екстрактнат файл

            ZipFileToArchive(inputFile, zipArchiveFile);

            string fileNameOnly = Path.GetFileName(inputFile);// взимаме само името на файла(отделно от целия път)
           ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }
        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
          using  ZipArchive archive =  ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create); //"Отваряме" празен зип файл
            string fileName = Path.GetFileName(inputFilePath);// взимаме чисто името на файла, който ще зипнем
            archive.CreateEntryFromFile(inputFilePath, fileName);// "вкарай" в зипа с параметри (пътя до файла, името на самия файл)
        }
        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive zip = ZipFile.OpenRead(zipArchiveFilePath);
            // Клас ЗипАрхив "Отвори и Прочети" с параметър пътя до зипа
            ZipArchiveEntry fileToExtract =  zip.GetEntry(fileName);// Клас ЗипАрхивЕнтри - това е самият файл, намиращ се в зипа
            fileToExtract.ExtractToFile(outputFilePath);// екстракт с ново име на екстрактнатия файл
        }

    }
}
