using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKM) 
            : base(fuelQuantity, consumptionPerKM)
        {
            this.FuelQuantity = fuelQuantity;
            this.ConsumptionPerKM = consumptionPerKM + 1.6;
        }

        public override string Drive(double km)
        {
            double neededFuelToDrive = km * this.ConsumptionPerKM;
            string stringToReturn = string.Empty;
            if (neededFuelToDrive <= FuelQuantity)
            {
                stringToReturn = $"Truck travelled {km} km";
                this.FuelQuantity -= neededFuelToDrive;
                //succes
                return stringToReturn;
            }
            else
            {
                stringToReturn = $"Truck needs refueling";
                return stringToReturn;

            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters*0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
