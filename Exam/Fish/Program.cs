namespace Fish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,]matrix = new char [size,size];
            int startRow = -1;
            int startCol = -1;
            int quota = 20;
            int colectedFish = 0;
            for (int i = 0; i < size; i++)
            {
                string currRowAsString = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = currRowAsString[j];
                    if (matrix[i, j] == 'S')
                    {
                        startRow = i;
                        startCol = j;
                        matrix[startRow, startCol] = '-';
                    }
                }
            }
            string command = string.Empty;
            int currRow = startRow;
            int currCol = startCol;
            while((command = Console.ReadLine()) != "collect the nets")
            {
                
                if(command == "up")
                {
                    currRow--;
                    if(currRow<0)
                    {
                        currRow = currRow + size;

                    }
                    char currChar = matrix[currRow,currCol];
                    if (char.IsDigit(currChar))
                    {
                        string currFish = currChar.ToString();
                        colectedFish += int.Parse(currFish);
                        matrix[currRow, currCol] = '-';

                    }else if (currChar == 'W')
                    {
                        colectedFish = 0;
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currRow},{currCol}]");
                        return;// VNIMANIE
                    }else if(currChar == '-')
                    {
                        continue;
                    }

                }
                else if(command == "down")
                {
                    currRow++;
                    if(currRow>=size)
                    {
                        currRow=0;
                    }
                    char currChar = matrix[currRow, currCol];
                    if (char.IsDigit(currChar))
                    {
                        string currFish = currChar.ToString();
                        colectedFish += int.Parse(currFish);
                        matrix[currRow, currCol] = '-';

                    }
                    else if (currChar == 'W')
                    {
                        colectedFish = 0;
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currRow},{currCol}]");
                        return;// VNIMANIE
                    }
                    else if (currChar == '-')
                    {
                        continue;
                    }


                }
                else if(command == "left")
                {
                    currCol--;
                    if (currCol<0)
                    {
                        currCol = currCol + size;
                        
                    }
                    char currChar = matrix[currRow, currCol];
                    if (char.IsDigit(currChar))
                    {
                        string currFish = currChar.ToString();
                        colectedFish += int.Parse(currFish);
                        matrix[currRow, currCol] = '-';

                    }
                    else if (currChar == 'W')
                    {
                        colectedFish = 0;
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currRow},{currCol}]");
                        return;// VNIMANIE
                    }
                    else if (currChar == '-')
                    {
                        continue;
                    }

                }
                else if(command == "right")
                {
                    currCol++;
                    if(currCol>=size)
                    {
                        currCol=0;
                    }
                    char currChar = matrix[currRow, currCol];
                    if (char.IsDigit(currChar))
                    {
                        string currFish = currChar.ToString();
                        colectedFish += int.Parse(currFish);
                        matrix[currRow, currCol] = '-';

                    }
                    else if (currChar == 'W')
                    {
                        colectedFish = 0;
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currRow},{currCol}]");
                        return;// VNIMANIE
                    }
                    else if (currChar == '-')
                    {
                        continue;
                    }

                }

            }
            matrix[currRow, currCol] = 'S';
            if (colectedFish >= quota)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {quota - colectedFish} tons of fish more.");
            }
            if (colectedFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {colectedFish} tons.");
            }
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}