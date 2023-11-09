
namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get;}
        public int Power { get; set; }

        public abstract string CastAbility(); 
       
    }
}
