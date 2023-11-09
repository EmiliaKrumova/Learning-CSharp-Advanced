
namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
            Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {Name} healed for {Power}";
       
    }
}
