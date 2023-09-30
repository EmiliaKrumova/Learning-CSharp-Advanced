namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if(size<3) // проверка дали шахматната дъска е достатъчно голяма, за да се движи коня
            {
                Console.WriteLine("0");
                return;
            }
            char[,] matrix = new char[size,size];// матрица от символи 'К' и '0'
            for(int row=0; row<size; row++)
            {
                string currRow = Console.ReadLine();
                for(int col=0; col<size; col++)
                {
                    matrix[row,col] = currRow[col];
                }
            }
            int removedKnights = 0;// премахнати атакуващи коне
            while(true)
            {
                int badKnights = 0;// брой на атакуваните коне за съответния кон
                int rowBadKnight = 0;// координатите на "най-лошия кон" до момента
                int colBadKnight = 0; 
                for(int row=0; row<size;row++)
                {
                    for(int col=0; col<size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row,col);// метод, който ни казва, конят на съответното поле, колко евентуално други коне, би атакувал
                            if(badKnights<attackedKnights)// ако това е най-атакуващия кон
                            {
                                badKnights=attackedKnights;
                                rowBadKnight = row;// присвояваме неговите координати
                                colBadKnight=col;
                            }
                        }
                    }
                }
                if(badKnights==0)
                {
                    break;
                }
                else
                {
                    matrix[rowBadKnight, colBadKnight] = '0';// премахваме "най-лошия" кон
                    removedKnights++;// броим колко коня сме премахнали от дъската
                }

            }
            Console.WriteLine(removedKnights);

            int CountAttackedKnights(int row, int col)// метод, който проверява в 8 направления дали клетката, на която ще стъпи коня е валидна и има друг кон на нея и брои атакуваните коне, съответно ги връща като резултат в променливата attackedKnights
            {
                int attackedKnight = 0;
                if (IsCellValid(row - 1, col - 2))
                {
                    if (matrix[row - 1, col - 2] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row - 1, col + 2))
                {
                    if (matrix[row - 1, col + 2] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row + 1, col + 2))
                {
                    if (matrix[row + 1, col + 2] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row + 1, col - 2))
                {
                    if (matrix[row + 1, col - 2] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row - 2, col + 1))
                {
                    if (matrix[row - 2, col +1] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row - 2, col - 1))
                {
                    if (matrix[row - 2, col - 1] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row + 2, col - 1))
                {
                    if (matrix[row + 2, col - 1] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                if (IsCellValid(row + 2, col + 1))
                {
                    if (matrix[row + 2, col + 1] == 'K')
                    {
                        attackedKnight++;
                    }
                }
                return (attackedKnight);
            }
            bool IsCellValid(int row, int col)// валидиращ метод за рамките на масива
            {
                return (row >= 0 && row < size && col >= 0 && col < size);
            }




        }

       
    }
}