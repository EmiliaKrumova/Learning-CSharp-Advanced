namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            int sumOfDiagonal = 0;
            for (int row = 0; row < size; row++)
            {
                int[] currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                for(int col = 0; col < size; col++)
                {
                    matrix[row,col] = currRow[col];
                    if (row == col)
                    {
                        sumOfDiagonal += currRow[col];
                    }
                }

            }
            Console.WriteLine(sumOfDiagonal);
        }
    }
}