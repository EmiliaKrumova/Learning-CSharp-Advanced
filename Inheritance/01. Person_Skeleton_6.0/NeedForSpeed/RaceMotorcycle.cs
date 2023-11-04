using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public const double DefaultFuelConsumption = 8;// set default value for fuelConsumption
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;

    }
}
