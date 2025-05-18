using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the max battery cap percentage (e.g., 80):");
        int maxCap = int.Parse(Console.ReadLine());

        int minCap = 40; // low threshold for recharging
        int battery = minCap;
        bool charging = true;

        while (true)
        {
            if (charging)
            {
                battery++;
                Console.WriteLine($"Charging... Battery at {battery}%");

                if (battery >= maxCap)
                {
                    Console.WriteLine("Max battery reached. Stopping charge.");
                    charging = false;
                }
            }
            else
            {
                battery--;
                Console.WriteLine($"Discharging... Battery at {battery}%");

                if (battery <= minCap)
                {
                    Console.WriteLine("Battery low. Starting charge.");
                    charging = true;
                }
            }

            Thread.Sleep(1000); // wait 1 second
        }
    }
}

