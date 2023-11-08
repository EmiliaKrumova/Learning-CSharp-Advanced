
namespace Vehicles.Models
{
    public abstract class Vehicle : IVechicle
    {
        protected double AirConditionConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public virtual void Driving(double km)
        {
            double totalConsumption = km * (FuelConsumption + AirConditionConsumption);
            
            if (totalConsumption <= FuelQuantity)
            {
                FuelQuantity -= totalConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
            else 
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            
        }

        public virtual void Refueling(double liters) => FuelQuantity += liters;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
