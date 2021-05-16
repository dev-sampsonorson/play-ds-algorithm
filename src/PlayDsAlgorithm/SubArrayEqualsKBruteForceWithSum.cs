using System;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm
{
    public class SubArrayEqualsKBruteForceWithSum : ISolution
    {
        public string Description =>
            "Subarray sum equals K - Brute Force with sum";

        int[] input = new int[] { 3, 4, 7, 2, -3, 1, 4, 2 };

        int k = 7;

        public void Run()
        {
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int subArraySum = 0;

                for (int j = i; j < input.Length; j++)
                {
                    subArraySum += input[j];

                    if (subArraySum == k) count += 1;
                }
            }

            Console.WriteLine($"Count: {count}");
        }
    }
}
