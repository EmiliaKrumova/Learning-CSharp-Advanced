using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public const double DefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DefaultFuelConsumption;

    }
}
