namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            for(int row = 0;row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for(int col = 0;col < cols; col++)
                {
                    matrix[row,col] = currRow[col];
                }
            }
            int maxSum = int.MinValue;
            int startRow = 0; int startCol = 0;
            for(int row = 0; row < rows-2; row++)
            {
                for(int col = 0; col < cols-2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row+2,col]+ matrix[row + 2, col+1]+ matrix[row + 2, col+2];
                    if(currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for(int row =  startRow; row <= startRow+2; row++)
            {
                for(int col = startCol; col <= startCol+2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}