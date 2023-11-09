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
        public double Capacity { get; set; }
        public bool IsEmpty { get; set; }
        public bool CanDrive(double km);

        public void Drive(double km);
        public void Refuel(double liters);
    }
}
