using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine().Split()
                    .Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(pump);
            }

            for (int start = 0; start < n-1; start++)
            {
                int fuel = 0;
                bool isCircle = true;

                for (int passed = 0; passed < n; passed++)
                {
                    var current = pumps.Dequeue();
                    int nextPumpDis = current[1];
                    int currentFuel = current[0];

                    fuel += currentFuel - nextPumpDis;

                    pumps.Enqueue(current);
                    if (fuel < 0)
                    {
                        start += passed;
                        isCircle = false;
                        break;
                    }
                }
                if (isCircle)
                {
                    Console.WriteLine(start);
                    return;
                }

            }
        }
    }
}
