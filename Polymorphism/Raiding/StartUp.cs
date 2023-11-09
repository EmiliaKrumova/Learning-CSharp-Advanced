using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();// инстанцираме рийдер - за да чете
            IWriter writer = new ConsoleWriter();// инстанцираме райтер - за да пише
            IHeroFactory heroFactory = new HeroFactory();// инстанцираме нова фабрика за герои

            IEngine engine = new Engine(reader, writer, heroFactory);// инстанцираме двигател за програмата

            engine.Run();// стартираме
        }
    }
}