
namespace Raiding.Models
{
    public class Druid : BaseHero

    {
        public Druid(string name) 
            : base(name)
        {
            Power = 80;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
