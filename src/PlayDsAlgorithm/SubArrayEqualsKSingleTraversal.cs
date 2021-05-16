using System;
using System.Collections.Generic;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm
{
    public class SubArrayEqualsKSingleTraversal : ISolution
    {
        public string Description => "";

        int[] input = new int[] { 3, 4, 7, 2, -3, 1, 4, 2, 1 };

        int k = 7;

        public void Run()
        {
            Dictionary<int, int> prefixSum = new Dictionary<int, int>();
            int cummSum = 0;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                cummSum += input[i];

                // for any cummSum check if it's equal to K
                // if so, we have found a subarray
                if (cummSum == k) count += 1;

                // if cummSum - K is the prefixSum
                // if so, we have found a subarray
                if (prefixSum.ContainsKey(cummSum - k))
                    count += prefixSum[cummSum - k];

                if (prefixSum.ContainsKey(cummSum))
                    prefixSum[cummSum] += 1;
                else
                    prefixSum.Add(cummSum, 1);
            }

            Console.WriteLine($"Count: {count}");
        }
    }
}
