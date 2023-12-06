using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;
        //ctor
        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int routeId = this.routes.GetAll().Count() + 1;
            IRoute existingRoute = this.routes
                .GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint);

            if (existingRoute != null)
            {
                if (existingRoute.Length == length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
                else if (existingRoute.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
                else if (existingRoute.Length > length)
                {
                    existingRoute.LockRoute();
                }
            }
            IRoute route = new Route(startPoint, endPoint, length, routeId);
           
            routes.AddModel(route);
            return string.Format(OutputMessages.NewRouteAdded,startPoint,endPoint,length);  
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            IRoute route = routes.FindById(routeId);
            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }
            vehicle.Drive(route.Length);
            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }
            return vehicle.ToString();

        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
           
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded,firstName,lastName,drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            var orderedVehicles = vehicles.GetAll().Where(v => v.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model);
            int countToRepair = 0;
            if (orderedVehicles.Count() < count)
            {
                countToRepair = orderedVehicles.Count();
            }
            else
            {
                countToRepair = count;
            }
            var vehiclesToRepair = orderedVehicles.ToArray().Take(countToRepair);
            foreach (var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, countToRepair);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if(vehicleType!=nameof(CargoVan)&& vehicleType != nameof(PassengerCar))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible,vehicleType);
            }
            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            IVehicle vehicle = null;
            if(vehicleType==nameof(PassengerCar))
            {
                 vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }else if (vehicleType == nameof(CargoVan))
            {
                 vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully,brand,model,licensePlateNumber);
        }

        public string UsersReport()
        {
            var orderedUsers = users.GetAll().OrderByDescending(u=>u.Rating).ThenBy(u=>u.LastName).ThenBy(u=>u.FirstName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach(var user in orderedUsers)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
