using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Euler
{
    public class UsefulFunctions
    {

        public static bool[] findPrimes(long number)
        {
            bool[] myArray = new bool[number];
            for (long i = 2; i < number; i++)
                myArray[i] = true;

            for (int k = 2; k < Math.Sqrt(number); k++)
            {
                if (myArray[k])
                {
                    for (int m = k * k; m < number; m += k)
                        myArray[m] = false;
                }
            }

            return myArray;
        }


    }
}
