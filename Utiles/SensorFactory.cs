using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Models;

namespace InvestigationGame.Utiles
{
    internal class SensorFactory
    {
        public static Sensor CreateSensor(string? input) 
        {
            return input switch
            {
                "1" => new Audio(),
                //"2" => new Thermal(),
                "3" => new Pulse(),
                //"4" => new Motion(),
                //"5" => new Magnetic(),
                "6" => new Signal(),
                "7" => new Light(),
                _ => null!
            };
        }
    }
}

