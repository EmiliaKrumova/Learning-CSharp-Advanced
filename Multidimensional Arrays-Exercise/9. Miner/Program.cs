namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];
            string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int initialCountOfCoals = 0;
            for(int row = 0; row < size; row++)
            {
                char[] currRowArray = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for(int col = 0; col < size; col++)
                {
                    matrix[row,col] = currRowArray[col];
                    if (matrix[row,col] == 'c')
                    {
                        initialCountOfCoals++;
                    }
                }
            }
            int startRow = 0;
            int startCol = 0;
            for(int row = 0; row < size;row++)
            {
                for(int col = 0;col < size;col++)
                {
                    if (matrix[row,col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            int currRow = startRow;
            int currCol = startCol;
            int countColectedCoals = 0;
            for(int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    if (IsCellValid(currRow - 1, currCol))
                    {
                        currRow = currRow- 1;
                        if (matrix[currRow, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            return;
                        }else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }else if (matrix[currRow, currCol] == 'c')
                        {
                            countColectedCoals++;
                            matrix[currRow, currCol] = '*';
                            if(initialCountOfCoals==countColectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                return;
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }

                }else if (commands[i] == "down")
                {
                    if (IsCellValid(currRow + 1, currCol))
                    {
                        currRow = currRow + 1;
                        if (matrix[currRow, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            return;
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 'c')
                        {
                            countColectedCoals++;
                            matrix[currRow, currCol] = '*';
                            if (initialCountOfCoals == countColectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                return;
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }

                }
                else if (commands[i] == "left")
                {
                    if (IsCellValid(currRow, currCol-1))
                    {
                        currCol = currCol - 1;
                        if (matrix[currRow, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            return;
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 'c')
                        {
                            countColectedCoals++;
                            matrix[currRow, currCol] = '*';
                            if (initialCountOfCoals == countColectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                return;
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }

                }
                else if (commands[i] == "right")
                {
                    if (IsCellValid(currRow, currCol+1))
                    {
                        currCol = currCol + 1;
                        if (matrix[currRow, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            return;
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 'c')
                        {
                            countColectedCoals++;
                            matrix[currRow, currCol] = '*';
                            if (initialCountOfCoals == countColectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                return;
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }

                }

            }
            Console.WriteLine($"{initialCountOfCoals - countColectedCoals} coals left. ({currRow}, {currCol})");

            bool IsCellValid(int row, int col)// валидиращ метод за рамките на масива
            {
                return (row >= 0 && row < size && col >= 0 && col < size);
            }
        }
    }
}