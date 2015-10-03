using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_052 : IEulerProblem
    {
        private string _description = "It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order." + 
                                      "\n\nFind the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.";
        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 52; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
            for (int i = 1; i < 1000000; i++)
            {
                List<char> integer = i.ToString().ToCharArray().OrderBy(ch => ch).ToList();
                bool isMatch = true;

                for (int factor = 2; factor <= 6; factor++)
                {
                    List<char> multiple = (i * factor).ToString().ToCharArray().OrderBy(ch => ch).ToList();

                    if (integer.Count() != multiple.Count())
                    {
                        isMatch = false;
                        break;
                    }

                    for (int k = 0; k < integer.Count(); k++)
                    {
                        if (integer[k] != multiple[k] || integer[k] != multiple[k])
                        {
                            isMatch = false;                            
                            break;
                        }
                    }
                }

                if (isMatch)
                {
                    return i.ToString();                    
                }                
            }
            return "";
        }
    }
}
