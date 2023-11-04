using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("user", 9);
            Console.WriteLine(hero.ToString());
        }
    }
}