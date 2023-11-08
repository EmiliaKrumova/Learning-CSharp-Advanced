
namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            base.AirConditionConsumption = 1.6;
        }

        public override void Refueling(double liters) => FuelQuantity += liters * 0.95;
    }
}
