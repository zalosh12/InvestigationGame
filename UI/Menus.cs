using InvestigationGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.UI
{
    public static class Menus
    {
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Investigation Game!");
            Console.WriteLine("Your goal: Expose the secret Iranian agent.");
            Console.WriteLine();
        }

        public static void ShowSensorSelectionMenu()
        {
            Console.WriteLine("Select a sensor to attach:");
            Console.WriteLine("1. Audio");
            Console.WriteLine("2. Thermal");
            Console.WriteLine("3. Pulse");
            Console.WriteLine("4. Motion");
            Console.WriteLine("5. Magnetic");
            Console.WriteLine("6. Signal");
            Console.WriteLine("7. Light");
            Console.Write("Enter a number (1-7): ");
        }

    }
}
