using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{

    public class StartUp
    {
        static void Main()
        {

            List<List<Tire>> tireComplects = new List<List<Tire>>();// списък от списъци с гуми (например зимни - 4 броя и летни - 4 броя)

            string command = string.Empty;
            while((command = Console.ReadLine()) != "No more tires")
            {
                string[] comArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Tire>currComplectOfTires = new List<Tire>();//инициализирам  текущ списък с гуми

                for(int i = 0; i < comArgs.Length; i+=2)// през 2 въртя цикъла -  докато свърши списъка, като първата стойност е годината, а втората - налагянето
                {
                    int year = int.Parse(comArgs[i]);
                    double pressure = double.Parse(comArgs[i+1]);
                    Tire tire = new Tire(year, pressure);// създавам нова гума
                    currComplectOfTires.Add(tire);// добавям я в текущия комплект
                }
                tireComplects.Add(currComplectOfTires);// добавям текущия комплект гуми, към другите комплекти
                
               
                
            }

            string engineCommand = string.Empty;
            List<Engine> engines = new List<Engine>();
            while((engineCommand = Console.ReadLine())!= "Engines done")
            {
                string[] engineArgs = engineCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower =int.Parse(engineArgs[0]);
                double cubicCapacity = double.Parse(engineArgs[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);


            }
            List<Car>cars = new List<Car>();

            string carCommand = string.Empty;
            while((carCommand = Console.ReadLine())!= "Show special")
            {
                string[] carInfo = carCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                Engine engine = engines[engineIndex];
                Tire[] tires = tireComplects[tiresIndex].ToArray();
                Car currCar = new Car(make,model,year,fuelQuantity,fuelConsumption,engine,tires);
                cars.Add(currCar);
            }

            List<Car> specialCars = 
                cars.FindAll(c => c.Year >= 2017// намери всички коли с година над 2017
                && c.Engine.HorsePower > 330 // и двигател с конски сили над 330
                && c.Tires.Select(t => t.Pressure).Sum() >= 9// сумата от налягането в гумите е над 9 и под 10
                && c.Tires.Select(t => t.Pressure).Sum() <= 10);

            foreach(Car car in specialCars )
            {
                car.Drive(20);
                Console.WriteLine(car);

            }
          


          
        }
    }


}