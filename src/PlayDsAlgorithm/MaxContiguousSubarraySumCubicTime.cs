using System;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm {
    public class MaxContiguousSubarraySumCubicTime : ISolution
    {
        public string Description => throw new System.NotImplementedException();

        int[] input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        public void Run()
        {
            int maxWindowSum = 0, windowSum;

            for (int l = 0; l < input.Length; l++) {
                for (int r = l; r < input.Length; r++) {
                    windowSum = 0;

                    // get all the sum in the window [l,r]
                    for (int i = l; i <= r; i++) windowSum += input[i];

                    // check if the windowSum is the max
                    maxWindowSum = Math.Max(maxWindowSum, windowSum);
                }
            }

            Console.WriteLine($"Max sum: {maxWindowSum}");            
        }
    }
}