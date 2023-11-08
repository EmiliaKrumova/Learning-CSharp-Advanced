using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle, IVehicles
    {
        public Car(double fuelQuantity, double consumptionPerKM) 
            : base(fuelQuantity, consumptionPerKM)
        {
            this.ConsumptionPerKM = consumptionPerKM + 0.9;
            this.FuelQuantity = fuelQuantity;
            
        }

        public override string Drive(double km)
        {
            double neededFuelToDrive = km * this.ConsumptionPerKM;
            string stringToReturn = string.Empty;
            if(neededFuelToDrive<=FuelQuantity)
            {
                stringToReturn = $"Car travelled {km} km";
                this.FuelQuantity-= neededFuelToDrive;
                //succes
                return stringToReturn ;
            }
            else
            {
                stringToReturn = $"Car needs refueling";
                return stringToReturn ;

            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity+= liters;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";

        }
    }
}
