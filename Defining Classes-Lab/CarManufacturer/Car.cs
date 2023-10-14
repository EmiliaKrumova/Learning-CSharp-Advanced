using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car// клас кола
    {
		private string make;// поле "марка на колата"

		public string Make// конструктор за марката на колата
		{
			get { return make; }
			set { make = value; }
		}
		private string model;// поле модел

		public string Model// конструктор за модел
		{
			get { return model; }
			set { model = value; }
		}
		private int year;// поле година на колата

		public int Year// конструктор за годината
		{
			get { return year; }
			set { year = value; }
		}
		private double fuelQuantity;// поле обем на резервоара

		public double FuelQuantity// конструктор за обем на резервоара
        {
			get { return fuelQuantity; }
			set { fuelQuantity = value; }
		}

		private double fuelConsumption;// поле разход на гориво

		public double FuelConsumption// конструктор за разхода
        {
			get { return fuelConsumption; }
			set { fuelConsumption = value; }
		}

		private Engine engine;// поле за двигателя (водещо към друг клас "Двигател"

		public Engine Engine
		{
			get { return engine; }
			set { engine = value; }
		}
		private Tire[] tires;// поле за гуми (водещо към клас "Гуми") масив е , тъй като колата има повече от един комплект гуми

		public Tire[] Tires
		{
			get { return tires; }
			set { tires = value; }
		}



		public void Drive(double distance)// метод "Шофирам", който изчислява разхода и дали има достатъчно гориво в резервоара
		{

			//if ((distance / 100) * FuelConsumption <= FuelQuantity)
			//{
			//    FuelQuantity -= (distance / 100) * FuelConsumption;

			//}
			double neededfuel = (distance * fuelConsumption) / 100;
			if (neededfuel <= fuelQuantity)
			{
				fuelQuantity -= neededfuel;

			}
			else
			{
				Console.WriteLine("Not enough fuel to perform this trip!");
			}
		}
		public string WhoAmI()// метод "Описание на КОЛАТА"
		{
			StringBuilder result = new StringBuilder();// стринг билдер

			result.AppendLine($"Make: {this.Make}");// на нов ред - марката
            result.AppendLine($"Model: {this.Model}");// модела
            result.AppendLine($"Year: {this.Year}");// годината
            result.AppendLine($"Fuel: {this.FuelQuantity:F2}");// горивото в резервоара


            return result.ToString().Trim();
		}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();// стринг билдер

            sb.AppendLine($"Make: {this.Make}");// на нов ред - марката
            sb.AppendLine($"Model: {this.Model}");// модела
            sb.AppendLine($"Year: {this.Year}");// годината
			sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.AppendLine($"FuelQuantity: {this.FuelQuantity}");// горивото в резервоара
            return sb.ToString().Trim();
        }
        // default constructor
        public Car()
        {
			Make = "VW";
			Model = "Golf";
			Year = 2025;
			FuelQuantity = 200;
			FuelConsumption = 10;
        }

		//chained constructors
		public Car(string make, string model, int year) : this()
        {
			Make = make;
			Model = model;
			Year = year;
			
            
        }
        public Car(string make, string model, int year, double fuelQuantity , double fuelConsumption) : this(make,model,year) 
        { 
			
			FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : 
			this( make,  model,  year,  fuelQuantity,  fuelConsumption)
		{
			Engine = engine;
			Tires = tires;
		}
        




    }
}
