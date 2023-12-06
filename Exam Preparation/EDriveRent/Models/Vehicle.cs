using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;
        private double maxMileage;
        private int batteryLevel;
        private bool isDamaged;
        //ctor
        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            LicensePlateNumber = licensePlateNumber;
            MaxMileage = maxMileage;
            BatteryLevel = 100;
            IsDamaged = false;
        }
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage
        {
            get { return maxMileage; }
            private set { maxMileage = value; }
        }
        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }

        public bool IsDamaged
        {
            get { return isDamaged; }
            private set { isDamaged = value; }
        }

        public void ChangeStatus()
        {
            if(IsDamaged==false)
            {
                isDamaged = true;
            }
            else
            {
                isDamaged = false;
            }
        }

        public void Drive(double mileage)
        {
            double percentage = mileage / this.MaxMileage * 100;//дали е възможно деление на 0???
            int finalPercentage = (int)Math.Round(percentage);
            this.BatteryLevel -= finalPercentage;
            if(this.GetType().Name== nameof(CargoVan))
            {
                this.BatteryLevel -= 5;
            }


        }

        public void Recharge()
        {
            this.BatteryLevel = 100;
        }
        public override string ToString()
        {
            string vehicleCondition;

            if (isDamaged)
            {
                vehicleCondition = "damaged";
            }
            else
            {
                vehicleCondition = "OK";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {vehicleCondition}";
        }
    }
}
