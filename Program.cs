using System;
using System.Threading;

class Program
{
    static int chargeLevel = 0;
    static int chargeLimit = 80; // customizable max charge %

    static void Main(string[] args)
    {
        Console.WriteLine("Universal Battery Limiter");
        Console.Write("Set max charge limit (default 80): ");
        
        string input = Console.ReadLine();
        if (int.TryParse(input, out int limit) && limit > 0 && limit <= 100)
        {
            chargeLimit = limit;
        }
        
        Console.WriteLine($"Charging will stop at {chargeLimit}% and resume below 40%.");
        Console.WriteLine("Press Ctrl+C to exit.");

        while (true)
        {
            SimulateBatteryCharge();
            Thread.Sleep(1000); // wait 1 second per cycle
        }
    }

    static void SimulateBatteryCharge()
    {
        // This simulates battery charging behavior:
        if (chargeLevel >= chargeLimit)
        {
            Console.WriteLine($"Charge at {chargeLevel}%, stopping charge...");
            // simulate unplugging charger (pause charge)
            while (chargeLevel > 40)
            {
                chargeLevel--; // battery discharging slowly
                Console.WriteLine($"Discharging... Battery at {chargeLevel}%");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Charge below 40%, resuming charge...");
        }
        else
        {
            chargeLevel++;
            Console.WriteLine($"Charging... Battery at {chargeLevel}%");
        }
    }
}
