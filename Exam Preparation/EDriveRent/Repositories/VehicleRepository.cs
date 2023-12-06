using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;
        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            IVehicle vehicle = vehicles.FirstOrDefault(v=>v.LicensePlateNumber == identifier);
            return vehicle;
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            IVehicle vehicleToRemove = vehicles.FirstOrDefault(v=>v.LicensePlateNumber== identifier);
            if(vehicleToRemove!=null)
            {
                vehicles.Remove(vehicleToRemove);
                return true;
            }
            return false;
        }
    }
}
