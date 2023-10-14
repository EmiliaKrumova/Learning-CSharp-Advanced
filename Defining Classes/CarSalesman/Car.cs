using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarSalesman
{
    public class Car
    {
        // Model: a string property
        // Engine: a property holding the engine object
        // Weight: an int property, it is optional
        // Color: a string property, it is optiona

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            
        }
        public Car(string model, Engine engine, int weight):this(model, engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color):this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine,int weight, string color):this(model,engine)
        {
            Weight=weight;
            Color = color;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"{Engine}");
            string weight = Weight != 0 ? Weight.ToString() : "n/a";
            sb.AppendLine($"  Weight: {weight}");
            string color = Color != null ? Color : "n/a";
            sb.Append($"  Color: {color}");
            return sb.ToString();

        }



    }
}
