using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
		private Dictionary<string  ,Car> cars;		

		private int capacity;

		public int Count => cars.Count();// пропърти, което трябва да връща нещо конкретно, в случая броя на колите, останали в речника

        
        public Parking(int capacity)
        {
			this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }
		public string AddCar(Car car)
		{
			if (cars.ContainsKey(car.RegistrationNumber))
			{
				return "Car with that registration number, already exists!";

            }
			if(cars.Count>=capacity)
			{
				return "Parking is full!";

            }
			cars.Add(car.RegistrationNumber, car);
			return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }
		public string RemoveCar(string registrationNumber)
		{
			if(!cars.ContainsKey(registrationNumber))
			{
				return "Car with that registration number, doesn't exist!";

            }
			cars.Remove(registrationNumber);
			return $"Successfully removed {registrationNumber}";

        }
		public Car GetCar(string registrationNumber)
		{
			if(cars.ContainsKey(registrationNumber))
			{
                return cars[registrationNumber];
			}
			else
			{
				return null;
			}
			
		}
		public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
		{
			foreach (string registrationNumber in RegistrationNumbers)
			{
				if(cars.ContainsKey(registrationNumber))
				{
					cars.Remove(registrationNumber);
				}
			}
		}

    }
}
