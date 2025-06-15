using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    internal class IranianAgent
    {
        
        public int rank { get; set; }
        public Dictionary<SensorType,int> SecretWeaknesses { get; set; }

        private List<Sensor> AttachedSensors;

        public IranianAgent()
        {
            AttachedSensors = new List<Sensor>();
            rank = 2;

            generateSecretWeaknesses();
        }

        public void generateSecretWeaknesses()
        {
            SecretWeaknesses = new Dictionary<SensorType,int>();
            Random random = new Random();

            var sensorTypes = Enum.GetValues<SensorType>();

            for (int i = 0; i < rank; i++)
            {
                var randomSensorType = sensorTypes[random.Next(sensorTypes.Length)];
                if (SecretWeaknesses.ContainsKey(randomSensorType))
                {
                    SecretWeaknesses[randomSensorType]++;
                }
                else
                {
                    SecretWeaknesses[randomSensorType] = 1;
                }

            }

        }
 
        public void AttachSensor(Sensor newSensor)
        {
            AttachedSensors.Add(newSensor);
        }
  
        public int EvaluateSensors()
        {
            int matchCount = 0;

            Dictionary<SensorType, int> attachedSensorsCount = new Dictionary<SensorType, int>();

            foreach(var sensor in AttachedSensors)
            {
                sensor.Activate();
                if (!sensor.IsActive)
                    continue;
                SensorType type = (SensorType)Enum.Parse(typeof(SensorType), sensor.Type);
                attachedSensorsCount[type] =
                            attachedSensorsCount.GetValueOrDefault(type) + 1;

                //{
                //    SensorType type = (SensorType)Enum.Parse(typeof(SensorType),sensor.Type);

                //    //if (attachedSensorsCount.ContainsKey(type))
                //    //{
                //    //    attachedSensorsCount[type]++;
                //    //}
                //    //else
                //    //{
                //    //    attachedSensorsCount[type] = 1;
                //    //}
                //}
            }

            foreach(var weakness in SecretWeaknesses)
            {
                SensorType type = weakness.Key;
                int amount = weakness.Value;
                if (attachedSensorsCount.ContainsKey(type))
                {
                    int attachedAmount = attachedSensorsCount[type];
                    matchCount += Math.Min(amount, attachedAmount);
                }
            }
            return matchCount;
        }




    }
}
