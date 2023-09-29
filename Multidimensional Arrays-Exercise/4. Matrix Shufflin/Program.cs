namespace _4._Matrix_Shufflin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[]comAgrs = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string realCom = comAgrs[0];
                if(realCom != "swap"|| comAgrs.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                 
                    continue;
                }
                int firstRow = int.Parse(comAgrs[1]);
                int firstCol = int.Parse(comAgrs[2]);
                int secondRow = int.Parse(comAgrs[3]);
                int secondCol = int.Parse(comAgrs[4]);
                if(firstRow <0||firstRow>=rows|| secondRow < 0 || secondRow >= rows|| firstCol < 0 || firstCol >= cols || secondCol < 0 || secondCol >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string stringToSwap = matrix[firstRow, firstCol];
                    matrix[firstRow,firstCol] = matrix[secondRow,secondCol];
                    matrix[secondRow, secondCol] = stringToSwap;
                }
                for(int i = 0; i < rows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}