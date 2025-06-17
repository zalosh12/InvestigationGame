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
        public bool IsActive { get; private set; }

        public void Activate(IranianAgent agent)
        {
            IsActive = true;
            OnActivate(agent); 
        }
        protected virtual void OnActivate(IranianAgent agent) { }
        public virtual bool IsBroken => false;
    }

    class Audio : Sensor
    {
        public Audio()
        {
            Type = SensorType.Audio;
        }
        protected override void OnActivate(IranianAgent agent)
        {

        }
    }

    class Pulse : Sensor
    {
        private int usesLeft = 3;

        public Pulse()
        {
            Type = SensorType.Pulse;
        }
        protected override void OnActivate(IranianAgent agent)
        {
            usesLeft--;
        }
        public override bool IsBroken => usesLeft <= 0;
    }

    class Light : Sensor
    {
        public Light()
        {
            Type = SensorType.Light;
        }
        protected override void OnActivate(IranianAgent agent)
        {
            agent.RevealRandomInfo(2);
        }

    }

    class Signal : Sensor
    {
        public Signal()
        {
            Type = SensorType.Signal;
        }
        protected override void OnActivate(IranianAgent agent)
        {
            agent.RevealRandomInfo(1);
        }
    }


}

