using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKM, double capacity)
            : base(fuelQuantity, consumptionPerKM, capacity)
        {
            Capacity = capacity;
            FuelQuantity = fuelQuantity;
            ConsumptionPerKM = consumptionPerKM;
            
        }

        public override double ConsumptionPerKM
            => this.IsEmpty ? base.ConsumptionPerKM : base.ConsumptionPerKM + 1.4;
        // override property
        // if(bus IsEmpty -> set this. Consumption)
        // else(set this.Consumption+1.4;

       
       


       
        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";

        }
    }
}
