namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];

                }
            }
            string[] coordinates = Console.ReadLine().Split(" ");
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentBomb = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int rowOfBomb = currentBomb[0];
                int colOfBomb = currentBomb[1];
                int valueOfBomb = matrix[rowOfBomb, colOfBomb];
                if (valueOfBomb <= 0)
                {
                    continue;
                }

                ExplodeOfBomb(size, matrix, rowOfBomb, colOfBomb, valueOfBomb);
            }
            int countOfAlive = 0;
            int sumOfAlive = 0;
            for(int row = 0;row<size;row++)
            {
                for(int col = 0; col < size; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        countOfAlive++;
                        sumOfAlive += matrix[row,col];
                    }

                }
            }
            Console.WriteLine($"Alive cells: {countOfAlive}");
            Console.WriteLine($"Sum: {sumOfAlive}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                                      
                        Console.Write($"{matrix[row, col]} ");                    

                }
                Console.WriteLine();
            }

            bool IsCellValid(int row, int col)// валидиращ метод за рамките на масива
            {
                return (row >= 0 && row < size && col >= 0 && col < size);
            }
            bool IsAliveCell(int row, int col, int[,] matrix)
            {
                return (matrix[row, col] > 0);
            }

            void ExplodeOfBomb(int size, int[,] matrix, int rowOfBomb, int colOfBomb, int valueOfBomb)
            {
                if (IsCellValid(rowOfBomb - 1, colOfBomb - 1) && IsAliveCell(rowOfBomb - 1, colOfBomb - 1, matrix))
                {

                    matrix[rowOfBomb - 1, colOfBomb - 1] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb - 1, colOfBomb) && IsAliveCell(rowOfBomb - 1, colOfBomb, matrix))
                {
                    matrix[rowOfBomb - 1, colOfBomb] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb - 1, colOfBomb + 1) && IsAliveCell(rowOfBomb - 1, colOfBomb + 1, matrix))
                {
                    matrix[rowOfBomb - 1, colOfBomb + 1] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb, colOfBomb - 1) && IsAliveCell(rowOfBomb, colOfBomb - 1, matrix))
                {
                    matrix[rowOfBomb, colOfBomb - 1] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb, colOfBomb + 1) && IsAliveCell(rowOfBomb, colOfBomb + 1, matrix))
                {
                    matrix[rowOfBomb, colOfBomb + 1] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb + 1, colOfBomb - 1) && IsAliveCell(rowOfBomb + 1, colOfBomb - 1, matrix))
                {
                    matrix[rowOfBomb + 1, colOfBomb - 1] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb + 1, colOfBomb) && IsAliveCell(rowOfBomb + 1, colOfBomb, matrix))
                {
                    matrix[rowOfBomb + 1, colOfBomb] -= valueOfBomb;
                }
                if (IsCellValid(rowOfBomb + 1, colOfBomb + 1) && IsAliveCell(rowOfBomb + 1, colOfBomb + 1, matrix))
                {
                    matrix[rowOfBomb + 1, colOfBomb + 1] -= valueOfBomb;
                }
                matrix[rowOfBomb, colOfBomb] = 0;
            }
        }
    }
}