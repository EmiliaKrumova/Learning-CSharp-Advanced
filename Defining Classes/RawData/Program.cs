namespace RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // "{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
           // {tire1Pressure} { tire1Age} { tire2Pressure}{ tire2Age} { tire3Pressure} { tire3Age} { tire4Pressure} { tire4Age} "
           List<Car> cars = new List<Car>();
           int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string carTokens = Console.ReadLine();
                string[] carInfo = carTokens.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                float tire1Pressure = float.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                float tire2Pressure = float.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                float tire3Pressure = float.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                float tire4Pressure = float.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire tire1 = new Tire(tire1Age,tire1Pressure);
                Tire tire2 = new Tire(tire2Age,tire2Pressure);
                Tire tire3 = new Tire(tire3Age,tire3Pressure);
                Tire tire4 = new Tire(tire4Age,tire4Pressure);
                Tire[] tires = { tire1, tire2, tire3, tire4, };
                //tires.Append(tire1);
                //tires.Append(tire2);
                //tires.Append(tire3);
                //tires.Append(tire4);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string command = Console.ReadLine();
            if(command == "fragile")
            {
                foreach( Car car in cars
                    .FindAll(c=>c.Cargo.Type== "fragile"&& 
                    c.Tires.Any(p=>p.Pressure<1)))
                {
                    Console.WriteLine(car.Model);
                }

            }else if(command == "flammable")
            {
                foreach(Car car in cars.FindAll(c=>c.Cargo.Type== "flammable" && c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
                //"flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.

            }


        }
    }
}