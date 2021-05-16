using System;

namespace PlayDsAlgorithm.Core
{
    public static class Utility
    {
        public static void Print(int[] array)
        {
            foreach (int item in array) Console.Write($"{item}, ");
        }
    }
}
