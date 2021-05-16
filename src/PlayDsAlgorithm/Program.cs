using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm
{
    class Program
    {
        static List<SolutionDesc> solutionDictionary = new List<SolutionDesc>() {
            new SolutionDesc(1, typeof(SubArrayEqualsKBruteForce)),
            new SolutionDesc(2, typeof(SubArrayEqualsKBruteForceWithSum)),
            new SolutionDesc(3, typeof(SubArrayEqualsKSingleTraversal)),
            new SolutionDesc(4, typeof(MaxContiguousSubarraySumCubicTime))
        };

        static void Main(string[] args)
        {
            Console.WriteLine(); 
            foreach(var item in solutionDictionary)
                Console.WriteLine($"{item.Id}: {item.SolutionType.Name}");

            Console.WriteLine();            
            Console.Write("Solution Id: ");

            int index = Convert.ToInt32(Console.ReadLine()) - 1;
                
            Console.WriteLine(new String('.', 50));
            Console.WriteLine();

            // Construct solution
            ISolution solution = CreateSolution(index);

            // Execute solution
            solution.Run();
        }

        static ISolution CreateSolution(int solutionIndex) {
            SolutionDesc desc = solutionDictionary[solutionIndex];
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().SingleOrDefault(x => x.Name == desc.SolutionType.Name);

            return type == null ? null : Activator.CreateInstance(type) as ISolution;
        }
    }
}
