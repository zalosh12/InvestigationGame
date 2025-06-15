using System;
using System.Collections.Generic;
using System.Data;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Investigation Game!");
            Console.WriteLine("Your goal: Expose the secret Iranian agent.");
            Console.WriteLine();

         
            IranianAgent agent = new IranianAgent();
            bool IsRevealead = false;

            while (!IsRevealead)
            {
                Console.WriteLine("\nChoose a sensor to attach:");
                Console.WriteLine("1. Audio");
                Console.WriteLine("2. Thermal");
                Console.WriteLine("3. Pulse");
                Console.WriteLine("4. Motion");
                Console.Write("Enter option number (1-4): ");

                string? input = Console.ReadLine();
                Sensor sensor = input switch
                {
                    "1" => new Audio(),
                    "2" => new Thermal(),
                    "3" => new Pulse(),
                    "4" => new Motion(),
                    _ => null!
                };

                if (sensor == null)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                agent.AttachSensor(sensor);
                int correct = agent.EvaluateSensors();

                if (correct == agent.rank)
                {
                    Console.WriteLine("\nAgent revealed! Mission accomplished.");
                    IsRevealead = true;
                }
                else
                {
                    Console.WriteLine($"You attached a {sensor.Type} sensor.");
                    Console.WriteLine($"Correct sensors so far: {correct}/{agent.SecretWeaknesses.Count}");
                }

            }

        }
    }
}

