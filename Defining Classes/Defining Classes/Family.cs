using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> persons;

		public List<Person> Persons
		{
			get { return persons; }
			set { persons = value; }
        }

        public Family()
        {
			Persons = new List<Person>();
        }

        //public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : 
        //this(make, model, year, fuelQuantity, fuelConsumption)

        public void AddMember(Person person)
		{
			//family.Add(person);
			Persons.Add(person);
		}
       public Person GetOldestMember()
		{
			Person oldest = Persons.OrderByDescending(p => p.Age).First();
			return oldest;
		}


    }
}
