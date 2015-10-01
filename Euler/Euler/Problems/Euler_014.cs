using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_014 : IEulerProblem
    {
        private string _description = "The following iterative sequence is defined for the set of positive integers:" +
            "\n\nn → n/2 (n is even)" +
            "\nn → 3n + 1 (n is odd)" +
            "\n\nUsing the rule above and starting with 13, we generate the following sequence:" +
            "\n\n13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1" +
            "\nIt can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1." +
            "\nWhich starting number, under one million, produces the longest chain?" +
            "\nNOTE: Once the chain starts the terms are allowed to go above one million.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 14; }
        }

        public string Description
        {
            get { return _description; }
        }

        private string Main()
        {
            int max = 0;
            int value = 0;
            for (int i = 2; i <= 1000000; i++)
            {
                int sequence = FindCollatzNumbers(i);
                if (sequence > max)
                {
                    max = sequence;
                    value = i;
                    //Console.WriteLine("i; " + i + ", max: " + max);
                }
            }
            return value.ToString();
        }

        private int FindCollatzNumbers(int number)
        {
            int sequence = 1;
            long current = number;

            while (current != 1)
            {
                if (current % 2 == 0)
                    current = current / 2;
                else
                    current = 3 * current + 1;
                sequence++;
            }
            return sequence;
        }        
    }
}
