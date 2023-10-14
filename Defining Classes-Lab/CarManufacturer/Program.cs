using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{

    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            

            Car firstCar = new Car();
            Car secondCar = new Car(make,model,year);
            Car thirdCar = new Car(make, model,year,fuelQuantity, fuelConsumption);
            var engine = new Engine(560,  6300);
            var tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire (1,2.1),
                new Tire (2, 0.5),
                new Tire (2, 2.3)
            };
            var car = new Car("Lamborghini","Urus", 2010,250,9,engine,tires);


            //thirdCar.Drive(double.Parse(Console.ReadLine()));
            //Console.WriteLine(thirdCar.FuelQuantity);
            //thirdCar.Drive(double.Parse(Console.ReadLine()));
            //Console.WriteLine(thirdCar.FuelQuantity);
            //thirdCar.Drive(double.Parse(Console.ReadLine()));
            //Console.WriteLine(thirdCar.FuelQuantity);
            //thirdCar.Drive(double.Parse(Console.ReadLine()));
            //Console.WriteLine(thirdCar.FuelQuantity);
            //thirdCar.Drive(double.Parse(Console.ReadLine()));
            //Console.WriteLine(thirdCar.FuelQuantity);



            //Console.WriteLine($"{firstCar.Make}, {firstCar.Model},{firstCar.Year},{firstCar.FuelQuantity},{firstCar.FuelConsumption}");
            //Console.WriteLine($"{secondCar.Make}, {secondCar.Model},{secondCar.Year},{secondCar.FuelQuantity},{ secondCar.FuelConsumption}");
            //Console.WriteLine($"{thirdCar.Make}, {thirdCar.Model},{thirdCar.Year},{thirdCar.FuelQuantity},{thirdCar.FuelConsumption}");
        }
    }


}