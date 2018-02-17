using System;
using System.Linq;

namespace _02._Crypto_Master
{
    class CryptoMaster
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxSequence = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int curentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentsequence = 1;

                    while (numbers[curentIndex]< numbers[nextIndex])
                    {
                        curentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentsequence++;
                    }
                    if (currentsequence > maxSequence)
                    {
                        maxSequence = currentsequence;
                    }
                }
            }
            Console.WriteLine(maxSequence);
        }
    }
}
