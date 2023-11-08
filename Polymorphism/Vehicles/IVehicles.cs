using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IVehicles
    {
        public double FuelQuantity { get; set; }
        public double ConsumptionPerKM { get; set; }

        public string Drive(double km);
        public void Refuel(double liters);
    }
}
