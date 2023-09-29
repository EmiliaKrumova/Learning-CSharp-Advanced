namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];
            for(int row =  0; row < rows; row++)
            {
                int[]currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArr[row] = new int[currRow.Length];// tuk ne sym sigurna
                for(int col = 0; col < currRow.Length; col++)
                {
                    jaggedArr[row][col] = currRow[col];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string realCom = commandArgs[0];
                int rowToManipulate = int.Parse(commandArgs[1]);
                int colToManipulate = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);
                bool isValid = false;
                isValid = Validation(rows, jaggedArr, rowToManipulate, colToManipulate, isValid);
                if (isValid)
                {
                    if (realCom == "Add")
                    {
                        jaggedArr[rowToManipulate][colToManipulate] += value;
                    }
                    if (realCom == "Subtract")
                    {
                        jaggedArr[rowToManipulate][colToManipulate] -= value;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
            }
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < jaggedArr[row].Length;col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool Validation(int rows, int[][] jaggedArr, int rowToManipulate, int colToManipulate, bool isValid)
        {
            if (rowToManipulate >= 0 && rowToManipulate < rows && colToManipulate >= 0 && colToManipulate < jaggedArr[rowToManipulate].Length)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}