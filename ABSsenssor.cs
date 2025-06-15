using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    internal abstract class Sensor
    {
        //public int Id { get;}
        public string Type { get; protected set; }
        public bool IsActive { get; set; }
        public abstract void Activate();

        public Sensor()
        {

        }
       
    }

    internal class Audio : Sensor
    {
        public Audio()
        {
            Type = "Audio";
        }

        public override void Activate()
        {
            IsActive = true;
        }
    }

    internal class Thermal : Sensor
    {
        public Thermal()
        {
            Type = "Thermal";
        }

        public override void Activate()
        {
            IsActive = true;
        }
    }

    internal class Pulse : Sensor
    {
        public Pulse()
        {
            Type = "Pulse";
        }

        public override void Activate()
        {
            IsActive = true;
        }
    }

    internal class Motion : Sensor
    {
        public Motion()
        {
            Type = "Motion";
        }

        public override void Activate()
        {
            IsActive = true;
        }
    }
}
