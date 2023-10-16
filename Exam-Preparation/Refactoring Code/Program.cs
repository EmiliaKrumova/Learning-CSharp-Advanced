namespace Refactoring_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // чете информация за матрицата и дава начална стойност за доставчика
            int[] matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            char[,] matrix = new char[rows, cols];
            int pizzaBoyStartRowIndex = -1;
            int pizzaBoyStartColumnIndex = -1;

            // пълни матрицата с информация и намира локацията на доставчика
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colsData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colsData[col];
                    if (colsData[col] == 'B')
                    {
                        pizzaBoyStartRowIndex = row;
                        pizzaBoyStartColumnIndex = col;
                    }
                }
            }

            int currentRow = pizzaBoyStartRowIndex;
            int currentColumn = pizzaBoyStartColumnIndex;
            bool orderCancel = false;
            //върти докато не стигне до клиента
            while (matrix[currentRow, currentColumn] != 'A')
            {
                int copyRow = currentRow;
                int copyCol = currentColumn;
                string move = Console.ReadLine();
                // променя индекса спрямо командата
                if (move == "up")
                {
                    currentRow--;
                }
                else if (move == "down")
                {
                    currentRow++;
                }
                else if (move == "left")
                {
                    currentColumn--;
                }
                else if (move == "right")
                {
                    currentColumn++;
                }
                // проверява дали индекса съществува, ако не прекратява цикъла и активира булевата променлива
                if (!IsValidIndex(matrix, currentRow, currentColumn))
                {
                    orderCancel = true;
                    break;
                }
                // ако доставчика срещне препятствие го връща на старото му място
                if (matrix[currentRow, currentColumn] == '*')
                {
                    currentColumn = copyCol;
                    currentRow = copyRow;
                }
                // ако стигне до ресторанта взима пицата
                else if (matrix[currentRow, currentColumn] == 'P')
                {
                    matrix[currentRow, currentColumn] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                //маркира пътя по който минава
                else if (matrix[currentRow, currentColumn] == '-')
                {
                    matrix[currentRow, currentColumn] = '.';
                }



            }
            //ако не е активирана булевата променлива значи е завършена доставката
            if (orderCancel == false)
            {
                matrix[currentRow, currentColumn] = 'P';
                Console.WriteLine("Pizza is delivered on time! Next order...");

            }
            // ако е активирана значи не е
            else if (orderCancel)
            {
                Console.WriteLine("The delivery is late. Order is canceled.");
            }
            // принтиращ метод 
            PrintMatrix(matrix, pizzaBoyStartRowIndex, pizzaBoyStartColumnIndex, orderCancel);

        }

        public static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(1) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
        public static void PrintMatrix(char[,] matrix, int startRowIndex, int startColIndex, bool orderCancel)
        {
            if (orderCancel)
            {
                matrix[startRowIndex, startColIndex] = ' ';
            }
            else
            {
                matrix[startRowIndex, startColIndex] = 'B';

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    
    }
}