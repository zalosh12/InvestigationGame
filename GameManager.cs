using InvestigationGame.UI;
using InvestigationGame.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Models;

namespace InvestigationGame
{
    internal class GameManager
    {
        public static void StartGame()
        {
            Menus.ShowWelcomeMessage();

            var curAgent = AgentFactory.CreateRandomAgent();

            bool IsExposed = false;

            while (!IsExposed)
            {
                Menus.ShowSensorSelectionMenu();
                Sensor? sensor = null;

                while (sensor == null)
                {
                    string? input = Console.ReadLine();
                    sensor = SensorFactory.CreateSensor(input);

                    if(sensor == null)
                    {
                        Console.WriteLine("Invalid Input Try again!");
                    }
                }

                curAgent.AttachedSensor(sensor);

                int matched = curAgent.EvaluateSensors();

                Console.WriteLine($"Correct sensors so far: {matched}/{curAgent.SensorNum}");

                if(matched >= curAgent.SensorNum)
                {
                    Console.WriteLine("\nAgent revealed! Mission accomplished.");
                    IsExposed = true;
                }









            }
        }
    }
}
