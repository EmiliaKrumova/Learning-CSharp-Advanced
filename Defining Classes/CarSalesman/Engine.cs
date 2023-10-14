using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        //        Model: a string property
        // Power: an int property
        // Displacement: an int property, it is optional
        // Efficiency: a string property, it is optional
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        private int displacement;

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        private string efficiency;

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            
        }
        public Engine(string model, int power, int displacement):this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency):this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, int power,int displacement,string efficiency):this(model,power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            string displacement = Displacement != 0 ? Displacement.ToString() : "n/a";
            sb.AppendLine($"    Displacement: {displacement}");
            string efficiency = Efficiency != null ? Efficiency.ToString() : "n/a";
            sb.Append($"    Efficiency: {efficiency}");
            return sb.ToString();
        }







    }
}
