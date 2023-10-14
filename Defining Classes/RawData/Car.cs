using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
		private string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}
        private Engine engine;// поле за двигателя (водещо към друг клас "Двигател"

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        private Cargo cargo;

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        private Tire[] tires;// поле за гуми (водещо към клас "Гуми") масив е , тъй като колата има повече от един комплект гуми

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

    }
}
