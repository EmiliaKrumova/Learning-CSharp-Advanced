using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle 
    {
        

        public Car(double fuelQuantity, double consumptionPerKM, double capacity) 
            : base(fuelQuantity, consumptionPerKM, capacity)
        {
            Capacity = capacity;
            ConsumptionPerKM = consumptionPerKM;
            FuelQuantity = fuelQuantity;
            
            
        }


        public override double ConsumptionPerKM  => base.ConsumptionPerKM+0.9; // override property from base class Vehicle      

        

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";

        }
    }
}
