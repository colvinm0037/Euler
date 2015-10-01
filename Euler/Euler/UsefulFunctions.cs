using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public static bool isPrime(int number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(number); i = i + 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public static bool isPalindrome(int number)
        {
            String s = number.ToString();
            Stack stack = new Stack();

            for (int i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                char ch = (char)stack.Pop();
                if (s[i] != ch)
                    return false;
            }

            return true;
        }

        public static BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
                return BigInteger.One;
            else
                return number * Factorial(number - BigInteger.One);
        }

        public static int SumOfProperDivisors(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

    }
}
