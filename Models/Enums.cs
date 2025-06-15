using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Models
{
    internal class Enums
    {
        public enum SensorType
        {
            Audio,
            Thermal,
            Pulse,
            Motion,
            Magnetic,
            Signal,
            Light
        }

        public enum AgentRank
        {
            FootSoldier,
            SquadLeader,
            SeniorCommander,
            OrganizationLeader
        }
    }
}
