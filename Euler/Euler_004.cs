using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_004
    {
        static void Main(string[] args)
        {
            int max = 0;

            for (int i = 999; i > 0; i--)
            {
                for (int k = 999; k > 0; k--)
                {
                    int number = i * k;
                    if (isPalindrome(number))
                    {
                        if (number > max)
                            max = number;
                    }
                }
            }

            Console.WriteLine(max);
            Console.ReadKey();
        }


        static bool isPalindrome(int number)
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
    }
}
