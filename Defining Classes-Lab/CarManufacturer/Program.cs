namespace CarManufacturer
{

    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "Golf";
            car.Year = 2007;
            car.FuelQuantity = 20;
            car.FuelConsumption = 1;
            car.Drive(15);
            Console.WriteLine(car.WhoAmI());

        }
    }


}