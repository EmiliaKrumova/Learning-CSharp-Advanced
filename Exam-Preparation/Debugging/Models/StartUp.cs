using Raiding.Models;
namespace Raiding
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfRaidMembers = int.Parse(Console.ReadLine());

            List<IBaseHero>raidGroup = new List<IBaseHero>();

            for (int i = 0; i < numberOfRaidMembers; i++) 
            {
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();

                if (heroClass != "Paladin" && heroClass != "Druid" && heroClass != "Warrior" && heroClass != "Rogue")
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                else if (heroClass == "Paladin")
                {
                    var newPaladin = new Paladin(name);
                    raidGroup.Add(newPaladin);
                }
                else if (heroClass == "Druid")
                {
                    var newDruid = new Druid(name);
                    raidGroup.Add(newDruid);
                }
                else if (heroClass == "Warrior")
                {
                    var newWarrior = new Warrior(name);
                    raidGroup.Add(newWarrior);
                }
                else if (heroClass == "Rogue") 
                {
                    var newRogue = new Rogue(name);
                    raidGroup.Add(newRogue);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = raidGroup.Sum(hero => hero.Power);

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else 
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}