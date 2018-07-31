using System;
using System.Linq;

class CryptoMaster
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int maxSequenceLength = 0;
        for (int index = 0; index < numbers.Length; index++)
        {
            for (int step = 1; step < numbers.Length; step++)
            {
                int currentIndex = index;
                int nextIndex = (index + step) % numbers.Length;
                int sequenceLength = 1;

                while (numbers[currentIndex] < numbers[nextIndex])
                {
                    currentIndex = nextIndex;
                    nextIndex = (nextIndex + step) % numbers.Length;
                    sequenceLength++;
                }

                if (sequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = sequenceLength;
                }
            }
        }

        Console.WriteLine(maxSequenceLength);
    }
}