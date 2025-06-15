using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Models
{
    internal abstract class Sensor
    {
        public SensorType Type { get; protected set; }
        public bool IsActive { get; set; }
        public abstract void Activate();


    }

    internal class Audio: Sensor
    {
        public Audio() 
        {
            Type = SensorType.Audio;
        }

        public override void Activate()
        {
            IsActive = true;
        }
    }




}
