using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Challenges
{
    class Challenge_Week_1
    {
        void Main()
        {
            // Levels 1, 2, and 3 obtain the correct answer under the goal time
            // Level 4 is fast but is somewhat off from correct answer
            // Level 5 tries (and fails) to use method used in Level 4 and takes an eternity to complete

            LevelOne();
            LevelTwo();
            LevelThree();
            LevelFour();

            // LevelFive();
        }

        void LevelOne()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long total1 = 1000 / 3;
            long totalSum1 = (total1 * (total1 + 1)) / 2;
            long sum1 = 3 * totalSum1;

            long total2 = 999 / 5;
            long totalSum2 = (total2 * (total2 + 1)) / 2;
            long sum2 = 5 * totalSum2;

            long total3 = 1000 / 15;
            long totalSum3 = (total3 * (total3 + 1)) / 2;
            long sum3 = 15 * totalSum3;

            long sum4 = sum1 + sum2 - sum3;

            stopwatch.Stop();
            Console.WriteLine("Level One: " + sum4 + ", Time in MS: " + stopwatch.ElapsedMilliseconds);
        }

        void LevelTwo()
        {
            // Level 2
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long total1 = 100000000 / 12;
            long totalSum1 = (total1 * (total1 + 1)) / 2;
            long sum3 = 12 * totalSum1;

            long total2 = 100000000 / 18;
            long totalSum2 = (total2 * (total2 + 1)) / 2;
            long sum4 = 18 * totalSum2;

            long total3 = 100000000 / 36;
            long totalSum3 = (total3 * (total3 + 1)) / 2;
            long sum5 = 36 * totalSum3;

            long sum6 = sum3 + sum4 - sum5;

            stopwatch.Stop();
            Console.WriteLine("Level Two: " + sum6 + ", Time in MS: " + stopwatch.ElapsedMilliseconds);
        }

        void LevelThree()
        {
            // Level 3
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long total1 = 100000000 / 12;
            long totalSum1 = (total1 * (total1 + 1)) / 2;
            long sum1 = 12 * totalSum1;

            long total2 = 100000000 / 18;
            long totalSum2 = (total2 * (total2 + 1)) / 2;
            long sum2 = 18 * totalSum2;

            long total3 = 99999999 / 20;
            long totalSum3 = (total3 * (total3 + 1)) / 2;
            long sum3 = 20 * totalSum3;

            long total4 = 100000000 / 36;
            long totalSum4 = (total4 * (total4 + 1)) / 2;
            long sum4 = 36 * totalSum4;

            long total6 = 100000000 / 60;
            long totalSum6 = (total6 * (total6 + 1)) / 2;
            long sum5 = 60 * totalSum6;

            long totalSums = sum1 + sum2 + sum3 - sum4 - sum5;
            stopwatch.Stop();
            Console.WriteLine("Level Three: " + totalSums + ", Time in MS: " + stopwatch.ElapsedMilliseconds);
        }

        void LevelFour()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> initialList = new List<int> { 5, 6, 9, 16, 22, 42, 57, 66, 69, 112, 146, 256, 257, 301, 573, 666, 1001, 2001, 3001, 23457 };
            List<int> intList = new List<int>(initialList);

            // Remove any number in the list divisible by another number in the list
            foreach (int a in initialList)
            {
                foreach (int b in initialList)
                {
                    if (a % b == 0 && a != b)
                    {
                        intList.Remove(a);
                    }
                }
            }

            // This puts the sum of every multiple of every number in our list into finalSum
            // This duplicates some values that will need to be removed
            long finalSum = 0;
            foreach (int currentInt in intList)
            {
                long total = 99999999 / currentInt;
                long totalSum = (total * (total + 1)) / 2;
                long sum = currentInt * totalSum;
                finalSum += sum;
            }

            // Make a list of the lcm of every possible pair of two numbers in our list
            HashSet<int> lcmList = new HashSet<int>();
            foreach (int currentInt in intList)
            {
                List<int> tempList = new List<int>(intList);
                tempList.Remove(currentInt);

                foreach (int tempInt in tempList)
                {
                    // find the lcm of currentInt and tempInt
                    int lcm = findLcm(currentInt, tempInt);

                    if (lcm < 99999999)
                    {
                        //Console.WriteLine ("lcm(" + currentInt + ", " + tempInt + ") = " + lcm);
                        lcmList.Add(lcm);
                    }
                }
            }

            // Make a final set of lcms that aren't divisible by any other number in the hashset
            HashSet<int> finalSet = new HashSet<int>();
            foreach (int k in lcmList)
            {
                finalSet.Add(k);
            }

            foreach (int lcmInt in lcmList)
            {
                foreach (int lcmInt2 in lcmList)
                {
                    if (lcmInt2 % lcmInt == 0 && lcmInt2 != lcmInt)
                    {
                        finalSet.Remove(lcmInt2);
                    }
                }
            }

            // Subtract the multiples of every number in the final lcm set from finalSum
            foreach (int lcmInt in finalSet)
            {
                long total = 99999999 / lcmInt;
                long totalSum = (total * (total + 1)) / 2;
                long sum = lcmInt * totalSum;
                finalSum -= sum;
            }

            stopwatch.Stop();
            Console.WriteLine("Level Four: " + finalSum + ", Time in MS: " + stopwatch.ElapsedMilliseconds);
        }

        int findLcm(int currentInt, int tempInt)
        {
            int num1, num2, lcm = 0;
            if (currentInt > tempInt)
            {
                num1 = currentInt;
                num2 = tempInt;
            }
            else
            {
                num1 = tempInt;
                num2 = currentInt;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return lcm;
        }


        void LevelFive()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> initialList = new List<int>(PseudoRandom(0, 100000));
            List<int> intList = new List<int>(initialList);

            foreach (int a in initialList)
            {
                foreach (int b in initialList)
                {
                    if (a == 0 || (a % b == 0 && a != b))
                    {
                        intList.Remove(a);
                    }
                }
            }

            foreach (int h in intList)
                Console.WriteLine(h);


            // This puts the sum of every multiple of every number in our list into finalSum
            // This duplicates some values that will need to be removed
            long finalSum = 0;
            foreach (int currentInt in intList)
            {
                long total = 99999999 / currentInt;
                long totalSum = (total * (total + 1)) / 2;
                long sum = currentInt * totalSum;
                finalSum += sum;
            }

            // Make a list of the lcm of every possible pair of two numbers in our list
            HashSet<int> lcmList = new HashSet<int>();
            foreach (int currentInt in intList)
            {
                List<int> tempList = new List<int>(intList);
                tempList.Remove(currentInt);

                foreach (int tempInt in tempList)
                {
                    // find the lcm of currentInt and tempInt
                    int lcm = findLcm(currentInt, tempInt);

                    if (lcm < 99999999 && lcm > 0)
                    {
                        //	Console.WriteLine ("lcm(" + currentInt + ", " + tempInt + ") = " + lcm);
                        lcmList.Add(lcm);
                    }
                }
            }

            // Make a final set of lcms that aren't divisible by any other number in the hashset
            HashSet<int> finalSet = new HashSet<int>();
            foreach (int k in lcmList)
            {
                finalSet.Add(k);
            }

            foreach (int lcmInt in lcmList)
            {
                foreach (int lcmInt2 in lcmList)
                {
                    if (lcmInt2 % lcmInt == 0 && lcmInt2 != lcmInt)
                    {
                        finalSet.Remove(lcmInt2);
                    }
                }
            }

            // Subtract the multiples of every number in the final lcm set from finalSum
            foreach (int lcmInt in finalSet)
            {
                //	Console.WriteLine (lcmInt);
                long total = 99999999 / lcmInt;
                long totalSum = (total * (total + 1)) / 2;
                long sum = lcmInt * totalSum;
                finalSum -= sum;
            }

            stopwatch.Stop();
            Console.WriteLine("Level Four: " + finalSum + ", Time in MS: " + stopwatch.ElapsedMilliseconds);
        }

        // Linear Congruential Generator (http://en.wikipedia.org/wiki/Linear_congruential_generator)
        // Period length for this implementation is 2^19.
        // Implemenation from: https://projecteuler.net/problem=150 (modified to generate numbers from 2 to 2^19 + 1)
        IEnumerable<int> PseudoRandom(int seed, int limit)
        {
            long t = seed;
            for (int k = 1; k <= limit; k++)
            {
                t = mod((615949 * t + 797807), 2 << 19);
                yield return (int)(t + 1);
            }
        }

        long mod(long x, long m)
        {
            long r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
