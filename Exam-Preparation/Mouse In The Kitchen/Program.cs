namespace Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];
            char[,] matrix = new char[row,col];
            int startRow = -1;
            int startCol = -1;
            int countOfCheese = 0;
            bool mouseGone = false;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                string currRowAsSting = Console.ReadLine();
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRowAsSting[j];
                    if (matrix[i, j] == 'M')
                    {
                        startRow = i; startCol = j;
                    }
                    if (matrix[i, j] == 'C')
                    {
                        countOfCheese++;
                    }
                }
            }
            string command;
            int currRow = startRow;
            int currCol = startCol;
            while((command = Console.ReadLine()) != "danger")
            {
                if(command == "up")
                {
                    currRow--;
                    if(currRow < 0|| currRow >= row)
                    {
                        currRow++;
                        Console.WriteLine("No more cheese for tonight!");
                        mouseGone = true;
                        break;
                    }
                    if (matrix[currRow, currCol] == '*')///!!!!!!!
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[currRow + 1, currCol] = '*';
                    }
                    if (matrix[currRow, currCol] == 'C')
                    {
                        matrix[currRow, currCol] = '*';
                        matrix[currRow+1, currCol] = '*';
                        countOfCheese--;
                        if(countOfCheese == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            matrix[currRow, currCol] = 'M';
                            matrix[startRow, startCol] = '*';
                            mouseGone = true;
                            break;
                        }
                        
                        
                    }
                    if (matrix[currRow, currCol] == 'T')
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[startRow, startCol] = '*';
                        matrix[currRow+1, currCol] = '*';
                        Console.WriteLine("Mouse is trapped!");
                        mouseGone = true;
                        break;


                    }
                    if (matrix[currRow, currCol] == '@')
                    {
                        currRow++;
                        continue;


                    }

                }

                if (command == "down")
                {
                    currRow++;
                    if (currRow < 0 || currRow >= row)
                    {
                        currRow--;
                        Console.WriteLine("No more cheese for tonight!");
                        mouseGone = true;
                        break;
                    }
                    if (matrix[currRow, currCol] == '*')///!!!!!!!
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[currRow-1, currCol] = '*';
                    }
                    if (matrix[currRow, currCol] == 'C')
                    {
                        matrix[currRow, currCol] = '*';
                        matrix[currRow - 1, currCol] = '*';
                        countOfCheese--;
                        if (countOfCheese == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            matrix[currRow, currCol] = 'M';
                            matrix[startRow, startCol] = '*';
                            mouseGone = true;
                            break;
                        }


                    }
                    if (matrix[currRow, currCol] == 'T')
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[startRow, startCol] = '*';
                        matrix[currRow - 1, currCol] = '*';
                        Console.WriteLine("Mouse is trapped!");
                        mouseGone = true;
                        break;


                    }
                    if (matrix[currRow, currCol] == '@')
                    {
                        currRow--;
                        continue;


                    }
                }
                if (command == "left")
                {
                    currCol--;
                    if (currCol < 0 || currCol >= col)
                    {
                        currCol++;
                        Console.WriteLine("No more cheese for tonight!");
                        mouseGone = true;
                        break;
                    }
                    if (matrix[currRow, currCol] == '*')///!!!!!!!
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[currRow, currCol+1] = '*';
                    }
                    if (matrix[currRow, currCol] == 'C')
                    {
                        matrix[currRow, currCol] = '*';
                        matrix[currRow, currCol+1] = '*';
                        countOfCheese--;
                        if (countOfCheese == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            mouseGone = true;
                            matrix[currRow, currCol] = 'M';
                            matrix[startRow, startCol] = '*';
                            break;
                        }


                    }
                    if (matrix[currRow, currCol] == 'T')
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[startRow, startCol] = '*';
                        matrix[currRow , currCol+1] = '*';
                        Console.WriteLine("Mouse is trapped!");
                        mouseGone = true;
                        break;


                    }
                    if (matrix[currRow, currCol] == '@')
                    {
                        currCol++;
                        continue;


                    }
                }
                if (command == "right")
                {
                    currCol++;
                    if (currCol < 0 || currCol >= col)
                    {
                        currCol--;
                        Console.WriteLine("No more cheese for tonight!");
                        mouseGone = true;
                        break;
                    }
                    if (matrix[currRow, currCol] == '*')///!!!!!!!
                    {
                        matrix[currRow, currCol] = 'M';
                        matrix[currRow , currCol-1] = '*';
                    }
                    if (matrix[currRow, currCol] == 'C')
                    {
                        matrix[currRow, currCol] = '*';
                        matrix[currRow, currCol - 1] = '*';
                        countOfCheese--;
                        if (countOfCheese == 0)
                        {
                            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                            mouseGone = true;
                            matrix[currRow, currCol] = 'M';
                            matrix[startRow, startCol] = '*';
                            break;
                        }


                    }
                    if (matrix[currRow, currCol] == 'T')
                    {
                        matrix[currRow, currCol] = 'M';
                        Console.WriteLine("Mouse is trapped!");
                        mouseGone = true;
                        matrix[startRow, startCol] = '*';
                        matrix[currRow, currCol - 1] = '*';
                        break;


                    }
                    if (matrix[currRow, currCol] == '@')
                    {
                        currCol--;
                        continue;


                    }
                }
            }
            if(countOfCheese > 0&& !mouseGone)
            {
                Console.WriteLine("Mouse will come back later!");

                matrix[currRow, currCol] = 'M';
            }
            for (int i = 0;i<row; i++)
            {
                for(int j = 0;j<col;j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}