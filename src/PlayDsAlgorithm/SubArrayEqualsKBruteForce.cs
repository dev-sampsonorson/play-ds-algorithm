using System;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm
{
    public class SubArrayEqualsKBruteForce : ISolution
    {
        public string Description => "Subarray sum equals K - Brute Force";

        int[] input = new int[] { 3, 4, 7, 2, -3, 1, 4, 2 };

        int k = 7;

        public void Run()
        {
            int count = 0;
            int[] prefixSum = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            prefixSum[i] = i == 0 ? input[i] : prefixSum[i - 1] + input[i];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    int
                        leftSum = 0,
                        rightSum = 0;

                    if (i == 0)
                    {
                        leftSum = 0;
                        rightSum = prefixSum[j];
                    }
                    else
                    {
                        leftSum = prefixSum[i - 1];
                        rightSum = prefixSum[j];
                    }

                    if (rightSum - leftSum == k) count += 1;
                }
            }

            Console.WriteLine($"Count: {count}");
        }
    }
}
