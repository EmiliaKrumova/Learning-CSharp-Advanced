namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            long[][] pascal = new long[rows][];// инициализираме назъбен масив с броя на редовете
            pascal[0] = new long[1]// инициализираме нулевия ред със стойност 1(единица)
            {1};
            for(long row = 1; row < rows; row++)// цикъл от първия ред до броя на редовете
            {
                pascal[row] = new long[row + 1];// за всеки нов ред, инициализираме нов масив с дължина номера на реда +1 (първи ред е с 2 колони, втори ред е с 3 колони...)
                for(long col = 0; col < pascal[row].Length; col++)
                {
                    if (col < pascal[row-1].Length)// проверка дали не е на последната колона
                    {
                        pascal[row][col] += pascal[row - 1][col];// добавяме горното число
                    }
                    
                    if(col>0)// проверка да не е на първата колона
                    {
                        pascal[row][col] += pascal[row - 1][col - 1];// прибавяме числото в ляво от горното
                    }
                   
                }
            }

            // Отпечатване на назъбен масив
            for (long row = 0; row < rows; row++)
            {
                for (long col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}