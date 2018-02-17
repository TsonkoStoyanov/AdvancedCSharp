using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    class SequenceWithQueue
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Queue<long> queueNumber = new Queue<long>();
            List<long> numbers = new List<long>();

            queueNumber.Enqueue(number);
            numbers.Add(number);

            while (numbers.Count < 50)
            {
                var firstItem = queueNumber.Peek() + 1;
                queueNumber.Enqueue(firstItem);
                var secondItem = (queueNumber.Peek() * 2) + 1;
                queueNumber.Enqueue(secondItem);
                var thirdItem = firstItem + 1;
                queueNumber.Enqueue(thirdItem);

                queueNumber.Dequeue();
                numbers.Add(firstItem);
                numbers.Add(secondItem);
                numbers.Add(thirdItem);
            }
            Console.WriteLine(string.Join(" ", numbers.Take(50)));
        }
    }
}
