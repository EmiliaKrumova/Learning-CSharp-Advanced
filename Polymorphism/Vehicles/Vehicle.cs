using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle : IVehicles
    {
        private double fuelQuantity;
        private double consumptionPerKM;
        private double capacity;
        protected Vehicle(double fuelQuantity, double consumptionPerKM, double capacity)
        {
            Capacity = capacity;
            FuelQuantity = fuelQuantity;
            ConsumptionPerKM = consumptionPerKM;

        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > this.Capacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public virtual double ConsumptionPerKM
        {
            get { return consumptionPerKM; }
            set { consumptionPerKM = value; }
        }

        public double Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km)
        {
            if (this.FuelQuantity >= this.ConsumptionPerKM * km)
            {
                return true;
            }
            return false;
        }
        public virtual void Drive(double km)
        {
            if (!this.CanDrive(km))
            {
                return;
            }
            double neededFuelToDrive = km * this.ConsumptionPerKM;

            FuelQuantity -= neededFuelToDrive;




        }


        public virtual void Refuel(double liters)
        {
            ValidateLiters(liters);
            ValidateQuantity(liters);

            FuelQuantity += liters;




        }

        protected void ValidateQuantity(double liters)
        {
            if (FuelQuantity + liters > Capacity)

            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
        }

        protected static void ValidateLiters(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";

        }

    }
}
