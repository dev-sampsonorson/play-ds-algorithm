using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using PlayDsAlgorithm.Core;
using System.IO;
using System.Threading.Tasks;

namespace PlayDsAlgorithm {
    class Program {
        static IDictionary<int, SolutionDesc> solutionDictionary;

        static void Main(string[] args) {
            try {
                solutionDictionary = CreateSolutionDictionary();

                UpdateLastSolutionId("Storage/MaxSolutionId.txt", solutionDictionary.Keys.Max()).Wait();

                Console.WriteLine();
                foreach (var item in solutionDictionary.OrderBy(x => x.Key))
                    Console.WriteLine($"{item.Key}: {item.Value.SolutionType.Name}");

                Console.WriteLine();
                Console.Write("Solution Id: ");

                int slnId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(new String('.', 50));
                Console.WriteLine();

                // Construct solution
                ISolution solution = CreateSolution(solutionDictionary[slnId]);

                // Execute solution
                solution?.Run();
            } catch (System.Exception ex) {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        static ISolution CreateSolution(SolutionDesc desc) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().SingleOrDefault(x => x.Name == desc.SolutionType.Name);
            return type == null ? null : Activator.CreateInstance(type) as ISolution;
        }

        static IDictionary<int, SolutionDesc> CreateSolutionDictionary() {
            IDictionary<int, SolutionDesc> result = new Dictionary<int, SolutionDesc>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Type[] types = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ISolution))).ToArray();
            IEnumerable<Type> types = assembly.GetTypes().Where(t => !t.IsInterface && typeof(ISolution).IsAssignableFrom(t));


            foreach (Type t in types) {
                var f = t.GetField("Id", BindingFlags.Public | BindingFlags.Static);
                int slnId = (int)t.GetField("Id", BindingFlags.Public | BindingFlags.Static).GetValue(null);

                if (result.ContainsKey(slnId))
                    throw new Exception($"Solution id: {slnId} already exists. Check {t.Name} and {result[slnId].SolutionType.Name}");

                result.Add(slnId, new SolutionDesc(slnId, t));
            }

            return result;
        }

        static Task UpdateLastSolutionId(string filePath, int maxSolutionId) {
            return File.WriteAllTextAsync(filePath, maxSolutionId.ToString());
        }
    }
}
