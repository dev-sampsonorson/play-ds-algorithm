using System;
using System.Linq;
using System.Collections.Generic;
using PlayDsAlgorithm.Core;

namespace PlayDsAlgorithm {
    public class MinimumWindowSubstringBruteForce : ISolution
    {
        public static int Id = 5; 
        public string Description => "";

        public void Run()
        {
             /* string searchString = "adobecodebanc";
             string characterString = "abcz"; */
             
             /* string searchString = "donutsandwafflemakemehungry";
             string characterString = "flea"; */
             
             /* string searchString = "whoopiepiesmakemyscalegroan";
             string characterString = "roam"; */
             
             string searchString = "coffeeteabiscuits";
             string characterString = "cake";

             int n = searchString.Length;
             int minWindowLength = Int32.MaxValue;
            //  int minWindowSize = characterString.Length;

                    // converts char string to map
                    IDictionary<char, int> charMap = ConvertToMap(characterString);

            for (int l = 0; l < n; l++) {
                for (int r = l; r < n; r++) {

                    // converts window to map
                    int windowLength = (r - l) + 1;
                    IDictionary<char, int> windowMap = ConvertToMap(searchString.Substring(l, windowLength));

                    int nFound = 0;
                    foreach(var pair in charMap) {
                        if (!windowMap.ContainsKey(pair.Key) || windowMap[pair.Key] < pair.Value) break;

                        nFound += 1;
                    }

                    if (nFound == charMap.Count)
                        minWindowLength = Math.Min(minWindowLength, windowLength);
                }
            }

            Console.WriteLine();
            if (minWindowLength != Int32.MaxValue) Console.WriteLine($"Min window substring length: {minWindowLength}");
            else Console.WriteLine("Not found: min window substring length");
        }

        private IDictionary<char, int> ConvertToMap(string value) {
            IDictionary<char, int> map = new Dictionary<char, int>();
                    for (int i = 0; i < value.Length; i++) {
                        if (map.ContainsKey(value[i])) {
                            map[value[i]] += 1;
                        } else {
                            map.Add(value[i], 1);
                        }
                    }

                    return map;  
        }
    }
}