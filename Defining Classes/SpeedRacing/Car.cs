using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    internal class Car
    {
		private string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		private double fuelAmount;

		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}
		private  double fuelConsumptionPerKilometer;

		public double FuelConsumptionPerKilometer
        {
			get { return  fuelConsumptionPerKilometer; }
			set { fuelConsumptionPerKilometer = value; }
		}
		private double travelledDistance;

		public double TravelledDistance
		{
			get { return travelledDistance; }
			set { travelledDistance = value; }
		}


        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
			Model = model;
			FuelAmount = fuelAmount;
			FuelConsumptionPerKilometer= fuelConsumptionPerKm;
			TravelledDistance = 0;
			
        }
		public void Drive(double distance)
		{
            double neededfuel = (distance * fuelConsumptionPerKilometer);
            if (neededfuel <= fuelAmount)
            {
                fuelAmount -= neededfuel;
				TravelledDistance += distance;

            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
