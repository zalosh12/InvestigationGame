using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Models
{
    internal abstract class IranianAgent
    {
        protected static Random random = new Random();
        public int SensorNum { get; protected set; }
        public Dictionary<SensorType, int> SecretWeaknesses { get; protected set; }

        protected List<Sensor> AttachedSensors;

        private List<string> HiddenInfo;
        public List<string> RevealedInfo { get; private set; } = new();

        public IranianAgent(int sensorsNum)
        {
            AttachedSensors = new List<Sensor>();
            SensorNum = sensorsNum;

            GenerateSecretWeaknesses();
            GenerateHiddenInfo();
        }

        public void GenerateSecretWeaknesses()
        {
            SecretWeaknesses = new Dictionary<SensorType, int>();

            var sensorTypes = Enum.GetValues<SensorType>();

            for (int i = 0; i < SensorNum; i++)
            {
                var randomSensorType = sensorTypes[random.Next(sensorTypes.Length)];
                SecretWeaknesses[randomSensorType] =
                    SecretWeaknesses.GetValueOrDefault(randomSensorType) + 1;

            }

        }

        protected virtual void GenerateHiddenInfo()
        {
            HiddenInfo = new List<string>();

            HiddenInfo.Add($"Rank: {this.GetType().Name}");

            string[] affiliations = { "Hezbollah", "IRGC", "Quds Force", "Unknown" };
            string affiliation = affiliations[random.Next(affiliations.Length)];
            HiddenInfo.Add($"Affiliation: {affiliation}");

            string codename = $"Codename: Agent-{random.Next(100, 999)}";
            HiddenInfo.Add(codename);
        }


        public void RevealRandomInfo(int amount)
        {
            for (int i = 0; i < amount && HiddenInfo.Count > 0; i++)
            {
                int index = random.Next(HiddenInfo.Count);
                var info = HiddenInfo[index];
                HiddenInfo.RemoveAt(index);
                RevealedInfo.Add(info);
            }
        }


        public void AttachedSensor(Sensor newSensor)
        {
            AttachedSensors.Add(newSensor);
        }


        public int EvaluateSensors()
        {
            int matchCount = 0;

            Dictionary<SensorType, int> attachedSensorsCount = new Dictionary<SensorType, int>();

            foreach (var sensor in AttachedSensors)
            {
                sensor.Activate(this);
                if (!sensor.IsActive)
                    continue;
                SensorType type = sensor.Type;
                attachedSensorsCount[type] =
                            attachedSensorsCount.GetValueOrDefault(type) + 1;
            }

            foreach (var weakness in SecretWeaknesses)
            {
                SensorType type = weakness.Key;
                int amount = weakness.Value;
                if (attachedSensorsCount.ContainsKey(type))
                {
                    int attachedAmount = attachedSensorsCount[type];
                    matchCount += Math.Min(amount, attachedAmount);
                }
            }

            AttachedSensors.RemoveAll(sensor => sensor.IsBroken);
            return matchCount;
        }






    }
    internal class FootSoldier : IranianAgent
    {
        public FootSoldier() : base(2) { }
    }

    internal class SquadLeader : IranianAgent
    {
        public SquadLeader() : base(4) { }
    }

    internal class SeniorCommander : IranianAgent
    {
        public SeniorCommander() : base(6) { }
    }

    internal class OrganizationLeader : IranianAgent
    {
        public OrganizationLeader() : base(8) { }
    }
}
