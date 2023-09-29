namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            
            for(int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                    
                }
            }
            int countOfEquals = 0;
            for (int row = 0 ; row < rows-1 ; row++)
            {
                for(int col = 0 ; col < cols-1 ; col++)
                {
                    char currChar = matrix[row, col];
                    
                   
                    
                    if (currChar == matrix[row, col + 1] && currChar == matrix[row + 1, col] && currChar == matrix[row + 1, col + 1])
                    {
                        countOfEquals++;
                    }
                    
                }
            }
            Console.WriteLine(countOfEquals);
        }
    }
}