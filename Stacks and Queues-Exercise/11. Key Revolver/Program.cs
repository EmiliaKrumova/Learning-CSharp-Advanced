namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barelSize = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            Queue<int> locs = new Queue<int>(locsArr);
            Stack<int> bullets = new Stack<int>(bulletsArr);
            int currBarelSize = barelSize;
            int shootedBullets = 0;
            while(locs.Count > 0&& bullets.Count>0 && currBarelSize>0)
            {
                int currBullet = bullets.Pop();
                shootedBullets++;
                currBarelSize--;
                int currLock = locs.Peek();
                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locs.Dequeue();
                    

                }
                else 
                {
                    Console.WriteLine("Ping!"); 
                }

                if (currBarelSize == 0 && bullets.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    currBarelSize += barelSize;
                }
                if(bullets.Count == 0 && locs.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locs.Count}");
                }else if(locs.Count==0 && bullets.Count >= 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (shootedBullets * bulletPrice)}");
                }
                

            }

        }
    }
}