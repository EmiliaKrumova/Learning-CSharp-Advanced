namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
           
            for(int col = 0; col < cols; col++)
            {
                int sum = 0;
                for (int row = 0;row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}