using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_062
    {
        // TODO: Not working

        string _description = "The cube, 41063625 (345^3), can be permuted to produce two other cubes: 56623104 (384^3) and 66430125 (405^3)." +
                            "\n\nIn fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube." + 
                            "\n\nFind the smallest cube for which exactly five permutations of its digits are cube.";
        
        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 62; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            // We don't necessarily need to look at every permutation
            // Just need to be find every cube that contains the exact same characters
            // There is still ways to improve the speed of this by keeping track of permutations?";

            HashSet<long> cubes = new HashSet<long>();
            int max = 20000;
            int maxCount = 0;
            long finalCube = 0;

            for (long i = 1; i < max; i++)
                cubes.Add(i * i * i);

            foreach (long cube in cubes)
            {
                int validPermutations = 1;
                var currentCubeLength = cube.ToString().Length;
                var currentCubeChars = cube.ToString().ToCharArray().OrderBy(c => c).ToList();

                var cubesOfSameLength = cubes.Where(c => c.ToString().Length == currentCubeLength && c != cube).ToList();
                foreach (long similarCube in cubesOfSameLength)
                {
                    var similarCubeChars = similarCube.ToString().ToCharArray().OrderBy(c => c).ToList();

                    bool isMatch = true;
                    for (int i = 0; i < currentCubeLength; i++)
                    {
                        if (currentCubeChars[i] != similarCubeChars[i])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                        validPermutations++;
                }

                if (validPermutations > maxCount)
                {
                    maxCount = validPermutations;
                    finalCube = cube;
                    Console.WriteLine(cube + ", " + validPermutations);
                }

                if (maxCount == 5)
                    break;
            }

            Console.WriteLine("Cube permutations: " + maxCount);
            Console.WriteLine("Cube: " + finalCube);
            Console.WriteLine("Cubic: " + Math.Pow(finalCube, (1.0 / 3.0)));
            return "";
        }

        // Elegant solution I found online
        // return Enumerable.Range(4, 10000)
        //                .Select(i => new BigInteger(i) * i * i)
        //                .ToLookup(b => new string(b.ToString().ToCharArray().OrderBy(c => c).ToArray()))
        //                .Where(grouping => grouping.Count() == 5)
        //                .SelectMany(grouping => grouping)
        //                .Min();
        
    }
}
