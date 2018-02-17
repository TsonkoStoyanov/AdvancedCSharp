using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class MaximumElement
    {
        static void Main()
        {
            var times = int.Parse(Console.ReadLine());

            Stack<int> numbersStack = new Stack<int>();
            var max = 0;

            for (int i = 0; i < times; i++)
            {
                var input = Console.ReadLine().Split();
                var inputArgs = input[0];

                switch (inputArgs)
                {
                    case "1":

                        var number = int.Parse(input[1]);

                        numbersStack.Push(number);

                        if (number > max)
                        {
                            max = number;
                        }
                        break;

                    case "2":

                        var popNumber = numbersStack.Pop();

                        if (popNumber == max && numbersStack.Count > 0)
                        {
                            max = numbersStack.Max();
                        }
                        else if (popNumber == max && numbersStack.Count == 0)
                        {
                            max = 0;
                        }

                        break;
                    case "3":
                        Console.WriteLine(max);
                        break;
                }
            }
        }
    }
}
