namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for(int i = 0; i < countOfEngines; i++)
            {
                //"{model} {power} {displacement} {efficiency}
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                if (engineInfo.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if(engineInfo.Length > 3)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    Engine engine = new Engine(model,power,displacement,efficiency);
                    engines.Add(engine);
                }
                else if(engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int displacement))
                    {
                        
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);

                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        Engine engine = new Engine(model, power,  efficiency);
                        engines.Add(engine);

                    }
                }

            }
            List<Car> cars = new List<Car>();
            int countOfCars = int.Parse(Console.ReadLine());
            for(int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{model} {engine} {weight} {color}

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines.First(e => e.Model == engineModel);

                if (carInfo.Length == 2)
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                    
                }else if(carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);

                    }
                    else
                    {
                        string color = carInfo[2];
                        Car car = new Car(model, engine, color);
                        cars.Add(car);

                    }
                }else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    Car car = new Car(model,engine,weight,color);
                    cars.Add(car);
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, cars));
        }
    }
}