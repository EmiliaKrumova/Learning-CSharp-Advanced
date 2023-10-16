using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        //•	Capacity – int•	Vehicles – List<Vehicle>

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        //•	Method AddVehicle(Vehicle vehicle) – adds an entity to the collection of Vehicles, if the Capacity allows it

        public void AddVehicle(Vehicle vehicle)
        {
            if (Capacity > Vehicles.Count)
            {
                Vehicles.Add(vehicle);
            }
        }
        //•	Method RemoveVehicle(string vin) – removes a vehicle by given vin, if such exists, and returns boolean (true if it is removed, otherwise – false)

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicleToRemove = Vehicles.FirstOrDefault(v => v.VIN == vin);
            if (vehicleToRemove != null)
            {
                Vehicles.Remove(vehicleToRemove);
                return true;
            }

            return false;
               
        }
        //•	Method GetCount() – returns the number of vehicles, registered in the RepairShop

        public int GetCount()
        {
            return Vehicles.Count;
        }
        //•	Method GetLowestMileage() – returns the Vehicle with the lowest value of Mileage property.
        public Vehicle GetLowestMileage()
        {
            Vehicle lowestMileage = Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
            if (lowestMileage != null)
            {
                return lowestMileage;
            }
            return null;
        }
        //•	Method Report() – returns a string in the following format:
        //o	"Vehicles in the preparatory:
        //{Vehicle1   }{Vehicle2
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach(Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
