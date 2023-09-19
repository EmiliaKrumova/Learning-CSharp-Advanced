namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            for(int row = 0; row < size; row++)
            {
                string currRow = Console.ReadLine();
                for(int col = 0; col < size; col++)
                {
                    matrix[row,col] = currRow[col];
                }
            }
            char symbolToLook = char.Parse(Console.ReadLine());
            int charRow = 0;
            int charCol = 0;
            bool isFind = false;
            for (int row = 0;row < size; row++)
            {
                for(int col = 0;col < size; col++)
                {
                    if (matrix[row,col] == symbolToLook)
                    {
                        charRow = row;
                        charCol = col;
                        Console.WriteLine($"({charRow}, {charCol})");
                        isFind = true;
                        return;
                    }
                }
            }
            if (!isFind)
            {
                Console.WriteLine($"{symbolToLook} does not occur in the matrix");
            }
        }
    }
}