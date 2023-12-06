using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private readonly IList<int> interfaceStandards;

        //ctor
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.BatteryLevel = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            interfaceStandards = new List<int>();
            this.InterfaceStandards = new ReadOnlyCollection<int>(interfaceStandards);

        }
        public string Model 
        {  get => model;
           private set
           {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;

           } 
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;

            }
        }

        public int BatteryLevel {get;private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards { get; }

        public void Eating(int minutes)
        {
            for(int i = 0; i < minutes; i++)
            {
                this.BatteryLevel += this.ConvertionCapacityIndex;
                if(BatteryLevel >= this.batteryCapacity)
                {
                    BatteryLevel = batteryCapacity;
                    break;
                }
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                BatteryLevel-= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {this.Model}:");
            sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
            sb.Append("--Supplements installed: ");
            if(this.interfaceStandards.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
               sb.AppendLine(string.Join(" ", this.interfaceStandards));
            }
            return sb.ToString().Trim();
        }
    }
}
