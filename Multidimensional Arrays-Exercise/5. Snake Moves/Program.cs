namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            string word = Console.ReadLine();// текст, с който ще запълвам матрицата
            int currIndex = 0;// пазя индекса на символа в думата
            for(int row = 0;row < rows;row++)
            {
                if(row%2==0)// ако съм на четен ред, попълвам от ляво на дясно
                {
                    for(int col = 0; col < cols; col++)
                    {
                        if (currIndex == word.Length)// ако достигна последния символ в думата, започвам я отначало
                        {
                            currIndex = 0;
                        }
                        matrix[row, col] = word[currIndex];// матрицата на съответните координати е равна на символа от думата на текущия индекс
                        currIndex++;// инкрементирам индекса, за да отида на следвашия символ

                    }
                }
                else // ако реда, на който се намирам е нечетен
                {
                    for (int col = cols-1; col >= 0; col--)// запълвам матрицата наобратно, от дясно на ляво
                    {
                        if (currIndex == word.Length)
                        {
                            currIndex = 0;
                        }
                        matrix[row, col] = word[currIndex];
                        currIndex++;
                    }

                }
            }
            for(int row = 0; row < rows;row++)// отпечатвам запълнената матрица
            {
                for(int column = 0; column < cols; column++)
                {
                    Console.Write(matrix[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}