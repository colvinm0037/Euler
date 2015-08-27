using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_032
    {
        List<int> digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        void Main()
        {
            // Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

            HashSet<int> pandigital = new HashSet<int>();

            for (int i = 1000; i < 10000; i++)
            {
                String s = Convert.ToString(i);
                if (!s.Contains("0") && (s.ToCharArray().Count() == s.ToCharArray().Distinct().Count()))
                {
                    if (IsPandigital(i))
                    {
                        Console.WriteLine("Adding: " + i);
                        pandigital.Add(i);
                    }
                }
            }

            Console.WriteLine("Sum: " + pandigital.Sum());
        }

        bool IsPandigital(int number)
        {
            if (HandlefourToOne(number))
                return true;
            if (HandleThreeTwo(number))
                return true;
            return false;
        }

        bool HandleThreeTwo(int number)
        {
            List<int> custom = new List<int>(digits);
            string num = Convert.ToString(number);

            foreach (char ch in num)
                custom.Remove((int)Char.GetNumericValue(ch));

            List<int> mulitplicands = new List<int>();

            // find every combination of two digits in list of five digits
            string s = null;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (k != i)
                    {
                        s = Convert.ToString(custom[i]) + Convert.ToString(custom[k]);
                        int multiplicand = Convert.ToInt32(s);
                        mulitplicands.Add(multiplicand);
                    }
                }
            }

            foreach (int multiplicand in mulitplicands)
            {
                List<int> remaining = new List<int>(custom);

                foreach (char ch in Convert.ToString(multiplicand))
                    remaining.Remove((int)Char.GetNumericValue(ch));

                // find every combination of three digits in remaining
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            string abc = Convert.ToString(remaining[a]) + Convert.ToString(remaining[b]) + Convert.ToString(remaining[c]);

                            if (abc.ToCharArray().Count() != abc.ToCharArray().Distinct().Count())
                                continue;

                            int multiplier = Convert.ToInt32(abc);
                            if (multiplicand * multiplier == number)
                            {
                                Console.WriteLine(multiplicand + " * " + multiplier + " = " + (multiplicand * multiplier) + ". Given: " + number);
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        bool HandlefourToOne(int number)
        {
            List<int> custom = new List<int>(digits);
            string num = Convert.ToString(number);

            foreach (char ch in num)
                custom.Remove((int)Char.GetNumericValue(ch));

            List<int> mulitplicands = new List<int>();

            // find every combination of one digits in list of five digits
            for (int i = 0; i < 5; i++)
                mulitplicands.Add(custom[i]);

            foreach (int multiplicand in mulitplicands)
            {
                List<int> remaining = new List<int>(custom);

                foreach (char ch in Convert.ToString(multiplicand))
                    remaining.Remove((int)Char.GetNumericValue(ch));

                // find every combination of four digits in remaining
                for (int a = 0; a < 4; a++)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        for (int c = 0; c < 4; c++)
                        {
                            for (int d = 0; d < 4; d++)
                            {
                                string abcd = Convert.ToString(remaining[a]) + Convert.ToString(remaining[b]) + Convert.ToString(remaining[c]) + Convert.ToString(remaining[d]);
                                int multiplier = Convert.ToInt32(abcd);

                                if (abcd.ToCharArray().Count() != abcd.ToCharArray().Distinct().Count())
                                    continue;

                                if (multiplicand * multiplier == number)
                                {
                                    Console.WriteLine(multiplicand + " * " + multiplier + " = " + (multiplicand * multiplier) + ". Given: " + number);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
