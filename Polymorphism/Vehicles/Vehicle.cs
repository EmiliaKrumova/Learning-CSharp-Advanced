using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle : IVehicles
    {
        protected Vehicle(double fuelQuantity, double consumptionPerKM)
        {
            FuelQuantity = fuelQuantity;
            ConsumptionPerKM = consumptionPerKM;
        }

        public double FuelQuantity { get;set; }
        public double ConsumptionPerKM { get; set; }

        public abstract string Drive(double km);


        public abstract void Refuel(double liters);
        
    }
}
