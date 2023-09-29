namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int row = 0; row < size; row++)
            {
                int[] currRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for(int col = 0; col < size; col++)
                {
                    matrix[row,col] = currRow[col];
                    if(row == col)
                    {
                        primaryDiagonal += matrix[row, col];
                    }
                    if(col== size - 1 - row)
                    {
                        secondaryDiagonal += matrix[row, col];
                    }
                }
            }
            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}