using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_025 : IEulerProblem
    {
        private string _description = "The Fibonacci sequence is defined by the recurrence relation:" +
            "\nFn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1." +
            "\nHence the first 12 terms will be:" +
            "\nF1 = 1" +
            "\nF2 = 1" +
            "\nF3 = 2" +
            "\nF4 = 3" +
            "\nF5 = 5" +
            "\nF6 = 8" +
            "\nF7 = 13" +
            "\nF8 = 21" +
            "\nF9 = 34" +
            "\nF10 = 55" +
            "\nF11 = 89" +
            "\nF12 = 144" +
            "\nThe 12th term, F12, is the first term to contain three digits." +
            "\nWhat is the index of the first term in the Fibonacci sequence to contain 1000 digits?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 25; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            BigInteger[] fibs = new BigInteger[1000000];

            fibs[1] = new BigInteger(1);
            fibs[2] = new BigInteger(1);
            int count = 3;

            while (true)
            {
                fibs[count] = fibs[count - 1] + fibs[count - 2];
                //Console.WriteLine (fibs[count]);
                //Console.WriteLine(fibs[count].ToString().Length);

                if (fibs[count].ToString().Length >= 1000)
                {
                    Console.WriteLine("Count: " + count);
                    break;
                }
                count++;
            }
            return count.ToString();
        }        
    }
}
