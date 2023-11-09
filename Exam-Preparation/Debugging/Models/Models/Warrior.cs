
namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name)
        {
            Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
