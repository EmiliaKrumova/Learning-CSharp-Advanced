using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine// наследник на интерфейса (за да има метод за стартиране)
    {
        private readonly IReader reader;// променливи от тип четящ
        private readonly IWriter writer;// пишещ
        private readonly IHeroFactory heroFactory;// обект от тип "фабрика"

        private readonly ICollection<IBaseHero> heroes;// басова колекция от най-базовия тип данни, така, че всички създадени типове да могат да бъдат добавени в нея.

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)// констриктор за Енджин-а, за да могат да се преизползват класовете за четене, писане, създаване на обекти и колекцията от обекти
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            this.heroes = new List<IBaseHero>();// !!! задължително инициализиране на тази колекция
        }

        public void Run()// след стартиране на програмата -> тук се описва бизнес логиката на цялата програма
        {
            int num = int.Parse(reader.ReadLine());
            while (num > 0)
            {
                
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();
                try
                {
                    IBaseHero hero = heroFactory.Create(heroType, heroName);// ! по този начин се създава герой от най-базовия тип. Възможно е и с var
                    heroes.Add(hero);// добавяне към колекцията
                    num--;
                }catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(reader.ReadLine());   
            foreach(var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
