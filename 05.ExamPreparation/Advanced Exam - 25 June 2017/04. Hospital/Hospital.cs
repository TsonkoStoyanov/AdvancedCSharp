using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Hospital
    {
        static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departaments = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Output")
            {
                var inputArgs = input.Split();
                string department = inputArgs[0];
                string doctor = inputArgs[1] + " " + inputArgs[2];
                string patient = inputArgs[3];

                if (!departaments.ContainsKey(department))
                {
                    departaments[department] = new List<string>();
                }
                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }
                departaments[department].Add(patient);
                doctors[doctor].Add(patient);
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();
                int room = 0;

                if (inputArgs.Length == 1)
                {
                    foreach (var departament in departaments.Where(x => x.Key == inputArgs[0]))
                    {
                        foreach (var patient in departament.Value)
                        {
                            Console.WriteLine(patient);

                        }
                    }
                }
                else if (int.TryParse(inputArgs[1], out room))
                {

                    int skip = room * 3 - 3;

                    foreach (var departament in departaments.Where(x => x.Key == inputArgs[0]))
                    {
                        foreach (var patient in departament.Value.Skip(skip).Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else
                {
                    var doctorName = inputArgs[0] + " " + inputArgs[1];
                    foreach (var doc in doctors.Where(x => x.Key == doctorName))
                    {
                        foreach (var patient in doc.Value.OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }

            }
        }
    }
}
