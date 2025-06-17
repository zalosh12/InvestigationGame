using InvestigationGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Utiles
{
    internal class AgentFactory
    {
        private static Random random = new Random();

        public static IranianAgent CreateRandomAgent()
        {
            return random.Next(4) switch
            {
                0 => new FootSoldier(),
                1 => new SquadLeader(),
                2 => new SeniorCommander(),
                3 => new OrganizationLeader(),
                _ => new FootSoldier()
            };
        }
    }
}
