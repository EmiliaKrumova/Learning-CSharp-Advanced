using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
		//Name, Number of badges, A collection of pokemon

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int badges;

		public int Badges
		{
			get { return badges; }
			set { badges = value; }
		}
		private List<Pokemon> pokemonColection;

		public List<Pokemon> PokemonColection
		{
			get { return pokemonColection; }
			set { pokemonColection = value; }
		}

        public Trainer(string name)
        {
            Name = name;
			Badges = 0;
			PokemonColection = new List<Pokemon>();
        }



    }
}
