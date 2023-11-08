
namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            base.AirConditionConsumption = 0.9;
        }

        
    }
}
