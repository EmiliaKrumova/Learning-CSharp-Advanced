using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];
            char[,] matrix = new char[row, col];
            int startRow = 0;
            int startCol = 0;
            for (int i = 0; i < row; i++)
            {
                string currLine = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = (currLine[j]);
                    if (matrix[i, j] == 'B')
                    {
                        startRow = i;
                        startCol = j;

                    }
                }

            }
            string command = Console.ReadLine();
            int currRow = startRow;
            int currCol = startCol;
            while (true)
            {
                if (command == "up")
                {
                    currRow--;
                    if (currRow < 0 || currRow >= row)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[startRow, startCol] = ' ';
                        break;
                    }
                    else if (matrix[currRow, currCol] == 'A')
                    {
                        Console.WriteLine("Pizza is delivered on time! Next order...");
                        matrix[currRow, currCol] = 'P';
                        break;
                    }
                    else if (matrix[currRow, currCol] == '*')
                    {
                        currRow++;
                        //continue;
                    }
                    else if (matrix[currRow, currCol] == 'P')
                    {
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        matrix[currRow, currCol] = 'R';
                        // continue;
                    }
                    else if (matrix[currRow, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '.';
                        // continue;
                        //}else if(matrix[currRow, currCol] == '.')
                        //{
                        //    continue;
                        //}
                    }
                }
                else if (command == "down")
                {
                    currRow++;
                    if (currRow < 0 || currRow >= row)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[startRow, startCol] = ' ';
                        break;
                    }
                    else if (matrix[currRow, currCol] == 'A')
                    {
                        Console.WriteLine("Pizza is delivered on time! Next order...");
                        matrix[currRow, currCol] = 'P';
                        break;
                    }
                    else if (matrix[currRow, currCol] == '*')
                    {
                        currRow--;
                        //continue;
                    }
                    else if (matrix[currRow, currCol] == 'P')
                    {
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        matrix[currRow, currCol] = 'R';
                        //continue;
                    }
                    else if (matrix[currRow, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '.';
                        // continue;
                    }
                    //else if (matrix[currRow, currCol] == '.')
                    //{
                    //    //continue;
                    //}
                }
                else if (command == "left")
                {
                    currCol--;
                    if (currCol < 0 || currCol >= col)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[startRow, startCol] = ' ';
                        break;
                    }
                    else if (matrix[currRow, currCol] == 'A')
                    {
                        Console.WriteLine("Pizza is delivered on time! Next order...");
                        matrix[currRow, currCol] = 'P';
                        break;
                    }
                    else if (matrix[currRow, currCol] == '*')
                    {
                        currCol++;
                        //continue;
                    }
                    else if (matrix[currRow, currCol] == 'P')
                    {
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        matrix[currRow, currCol] = 'R';
                        // continue;
                    }
                    else if (matrix[currRow, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '.';
                        // continue;
                    }
                    //else if (matrix[currRow, currCol] == '.')
                    //{
                    //    continue;
                    //}
                }
                else if (command == "right")
                {
                    currCol++;
                    if (currCol < 0 || currCol >= col)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[startRow, startCol] = ' ';
                        break;
                    }
                    else if (matrix[currRow, currCol] == 'A')
                    {
                        Console.WriteLine("Pizza is delivered on time! Next order...");
                        matrix[currRow, currCol] = 'P';
                        break;
                    }
                    else if (matrix[currRow, currCol] == '*')
                    {
                        currCol--;
                        //continue;
                    }
                    else if (matrix[currRow, currCol] == 'P')
                    {
                        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                        matrix[currRow, currCol] = 'R';
                        // continue;
                    }
                    else if (matrix[currRow, currCol] == '-')
                    {
                        matrix[currRow, currCol] = '.';
                        // continue;
                    }
                    //else if (matrix[currRow, currCol] == '.')
                    //{
                    //    continue;
                    //}
                }


                command = Console.ReadLine();

            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
