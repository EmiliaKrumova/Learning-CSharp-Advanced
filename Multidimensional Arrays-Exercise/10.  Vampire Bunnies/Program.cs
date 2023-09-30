using System.Data;

namespace _10.__Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            int playerRow = 0;
            int playerCol = 0;
            for(int row = 0; row < rows; row++)
            {
                string data = Console.ReadLine();
                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '.';// махам играча от това поле -> той се движи!!!
                    }
                }
            }//  до тук пълня матрицата и намирам стартовата позиция на играча


            string directions = Console.ReadLine();// посоки на движение на играча
            
            for (int i = 0;i<directions.Length;i++)// докато свършат посоките
            {
                char currDirection = directions[i];
                int oldRow = playerRow;// запазвам координатите на играча
                int oldCol = playerCol;

                if (currDirection == 'L')// наляво
                {
                    playerCol--;

                }else if(currDirection == 'R')//надясно
                {
                    playerCol++;

                }else if(currDirection == 'U')
                {
                    playerRow--;

                }else if (currDirection == 'D')
                {
                    playerRow++;
                }

                matrix = SpreadBunnies();// метод с огледална матрица, с която разпространявам зайчетата
                if (playerRow < 0 || playerRow >= rows || playerCol < 0 || playerCol >= cols)// ако играча е вън от матрицата
                {
                    PrintResult(oldRow, oldCol, "won");// печели
                    break;
                }
                if (matrix[playerRow, playerCol] == 'B')
                {
                    PrintResult(playerRow, playerCol, "dead");// ако срещне зайче -> губи играта
                    break;
                }

            }

            

            void PrintResult(int playerRow,int playerCol, string result)
            { 
                for(int row = 0; row < rows;row++)
                {
                    for(int col = 0;col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"{result}: {playerRow} {playerCol}");

            }


            char[,] SpreadBunnies()
            {
                char[,] newMatrix = new char[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        newMatrix[row, col] = matrix[row, col];// правя огледално копие на матрицата
                    }

                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')// ако в оригиналната матрица на това поле има зайче -> го разпространявам в четирите посоки
                        {
                            if (row > 0)// зайче нагоре
                            {
                                newMatrix[row - 1, col] = 'B';
                            }
                            if (row < rows - 1)// зайче надолу
                            {
                                newMatrix[row + 1, col] = 'B';
                            }
                            if (col > 0)// зайче наляво
                            {
                                newMatrix[row, col - 1] = 'B';
                            }
                            if (col < cols - 1)// зайче надясно
                            {
                                newMatrix[row, col + 1] = 'B';
                            }
                        }
                        

                    }

                }
                return newMatrix;// връщам копието, за да стане оригиналната матрица с разпространените зайчета

            }
        }

       
    }
}