using System.Security.Cryptography.X509Certificates;

namespace The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size,size];

            string[] directions = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            int startRow = -1;
            int startCol = -1;
            int hazelCount = 0;
            bool squirresIsGone = false;

            

            for(int i = 0;i<size;i++)
            {
                string data = Console.ReadLine();
                for(int j = 0;j < size; j++)
                {
                    matrix[i, j] = data[j];
                    if (matrix[i, j] == 's')
                    {
                        startRow = i; 
                        startCol = j;
                        matrix[i, j] = '*';//??????
                    }
                }
            }
            int currRow = startRow;
            int currCol = startCol;

            for(int i = 0; i < directions.Length; i++)
            {
                string command = directions[i];
                if(command == "up")
                {
                    currRow--;
                    if (IsValid(size,currRow,currCol))
                    {
                        if (matrix[currRow, currCol] == 'h')
                        {
                            hazelCount++;
                            matrix[currRow, currCol] = '*';
                            if (hazelCount == 3)
                            {
                                matrix[currRow, currCol] = 's';
                                break;
                            }
                        }else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }else if (matrix[currRow, currCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            squirresIsGone = true;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        squirresIsGone = true;
                        break;
                    }

                }
                else if(command == "down")
                {
                    currRow++;
                    if (IsValid(size, currRow, currCol))
                    {
                        if (matrix[currRow, currCol] == 'h')
                        {
                            hazelCount++;
                            matrix[currRow, currCol] = '*';
                            if (hazelCount == 3)
                            {
                                matrix[currRow, currCol] = 's';
                                break;
                            }
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            squirresIsGone = true;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        squirresIsGone= true;
                        break;
                    }

                }
                else if (command == "left")
                {
                    currCol--;
                    if (IsValid(size, currRow, currCol))
                    {
                        if (matrix[currRow, currCol] == 'h')
                        {
                            hazelCount++;
                            matrix[currRow, currCol] = '*';
                            if (hazelCount == 3)
                            {
                                matrix[currRow, currCol] = 's';
                                break;
                            }
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            squirresIsGone = true;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        squirresIsGone=! true;
                        break;
                    }

                }
                else if(command == "right")
                {
                    currCol++;
                    if (IsValid(size, currRow, currCol))
                    {
                        if (matrix[currRow, currCol] == 'h')
                        {
                            hazelCount++;
                            matrix[currRow, currCol] = '*';
                            if (hazelCount == 3)
                            {
                                matrix[currRow, currCol] = 's';
                                break;
                            }
                        }
                        else if (matrix[currRow, currCol] == '*')
                        {
                            continue;
                        }
                        else if (matrix[currRow, currCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            squirresIsGone= true;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        squirresIsGone = true;
                        break;
                    }

                }
            }
            if(hazelCount==3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
            }

            if(!squirresIsGone && hazelCount<3)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
            Console.WriteLine($"Hazelnuts collected: {hazelCount}");



        } public static bool IsValid(int size, int currRow, int currCol)
        {
            if(currCol>=0 && currRow>=0 && currRow<size&& currCol < size)
            {
                return true;

            }
            return false;
        }
    }
}