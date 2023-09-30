namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double [][] jagged = new double[rows][];
            for (int row = 0;row < rows; row++)
            {
                double[] currRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[row] = currRow;
            }
            for(int row = 0; row < jagged.Length-1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for(int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] *= 2;
                        jagged[row + 1][i] *= 2;
                    }
                    
                }
                else
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] /= 2;
                    }
                    for (int i = 0; i < jagged[row+1].Length; i++)
                    {
                        jagged[row + 1][i] /= 2;
                    }

                }
            }
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] commArgs = command.Split().ToArray();
                string realCommand = commArgs[0];
                int rowCoordinate = int.Parse(commArgs[1]);
                int colCoordinate = int.Parse(commArgs[2]);
                double value = double.Parse(commArgs[3]);
                if(rowCoordinate < 0 || colCoordinate < 0|| rowCoordinate >= rows || colCoordinate >= jagged[rowCoordinate].Length)
                {
                    continue;
                }
                if (realCommand == "Add")
                {
                    jagged[rowCoordinate][colCoordinate] += value;
                }
                if(realCommand == "Subtract")
                {
                    jagged[rowCoordinate][colCoordinate] -= value;
                }

            }
            for(int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(" ", jagged[row]));
            }
        }
    }
}