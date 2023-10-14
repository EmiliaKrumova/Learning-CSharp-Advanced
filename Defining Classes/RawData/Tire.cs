using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
		//Tires: a collection of exactly 4 tires. Each tire should have two properties: age and pressure.
		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		private float pressure;

		public float Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}
        public Tire(int age, float pressure)
        {
            Age = age;
			Pressure = pressure;
        }


    }
}
