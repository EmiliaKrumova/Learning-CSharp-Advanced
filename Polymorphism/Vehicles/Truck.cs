using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKM, double capacity)
            : base(fuelQuantity, consumptionPerKM, capacity)
        {
            Capacity = capacity;
            FuelQuantity = fuelQuantity;
            ConsumptionPerKM = consumptionPerKM;
            
        }

        public override double ConsumptionPerKM => base.ConsumptionPerKM + 1.6; 



        public override void Refuel(double liters)
        {
            ValidateLiters(liters);
            ValidateQuantity(liters);
            
            liters *= 0.95;
            base.Refuel(liters);// викаме базовия метод с подменената стойност за литрите

        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
