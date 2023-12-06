﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int defaultBatteryCapacity = 40000;
        private const int defaultConversionIndex = 5000;
        public IndustrialAssistant(string model)
            : base(model, defaultBatteryCapacity, defaultConversionIndex)
        {
        }
    }
}
