using System;


namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;// set default value for fuelConsumption

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        
       
        
        public virtual double FuelConsumption => DefaultFuelConsumption; // "virtual" every child clas can override this property

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
       public virtual void Drive(double kilometers)=> Fuel -= kilometers * FuelConsumption;
       



    }
}
