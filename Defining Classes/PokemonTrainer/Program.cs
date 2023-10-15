namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            // List<Pokemon> pokemons = new List<Pokemon>();
            List<Trainer> trainers = new List<Trainer>();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                // pokemons.Add(pokemon);
                if (!trainers.Any(t => t.Name==(trainerName)))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.PokemonColection.Add(pokemon);

                    trainers.Add(newTrainer);
                }
                else
                {
                    Trainer trainer = trainers.First(x => x.Name == trainerName);
                    trainer.PokemonColection.Add(pokemon);
                }



            }
            string elementCommand = string.Empty;
            while ((elementCommand = Console.ReadLine()) != "End")
            {

                foreach (var trainer in trainers)
                {
                    if (trainer.PokemonColection.Any(p => p.Element == elementCommand))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.PokemonColection.ForEach(p => p.Health -= 10);


                    }
                    
                      
                    trainer.PokemonColection.RemoveAll(p => p.Health <= 0);
                      

                }


            }
            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonColection.Count}");
            }
        }
    }
}