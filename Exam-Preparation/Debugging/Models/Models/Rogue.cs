
namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
            Power = 80;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
