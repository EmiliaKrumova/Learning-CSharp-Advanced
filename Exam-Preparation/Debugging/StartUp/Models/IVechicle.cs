
namespace Vehicles.Models
{
    public interface IVechicle
    {
        public double FuelQuantity { get; set; }
        public double  FuelConsumption { get; set; }

        public void Driving(double km);

        public void Refueling(double liters);
    }
}
