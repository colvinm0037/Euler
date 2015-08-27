using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_036
    {
        void Main()
        {
            long sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (isPalindrome(i) && isPalindrome(Convert.ToString(i, 2)))
                {
                    Console.WriteLine(i + " and " + Convert.ToString(i, 2) + " are palindromes");
                    sum += i;
                }
            }
            Console.WriteLine("Sum: " + sum);
        }

        bool isPalindrome<T>(T number)
        {
            String s = number.ToString();
            Stack stack = new Stack();

            for (int i = 0; i < s.Length; i++)
                stack.Push(s[i]);

            for (int i = 0; i < s.Length; i++)
            {
                char ch = (char)stack.Pop();
                if (s[i] != ch)
                    return false;
            }

            return true;
        }
    }
}
