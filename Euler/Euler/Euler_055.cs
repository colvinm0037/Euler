using Euler.Euler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_055 : IEulerProblem
    {
        private string _description = "If we take 47, reverse and add, 47 + 74 = 121, which is palindromic." + 
            "\n\nNot all numbers produce palindromes so quickly.For example," +
            "\n\n349 + 943 = 1292," +
            "\n1292 + 2921 = 4213" +
            "\n4213 + 3124 = 7337" +
            "\n\nThat is, 349 took three iterations to arrive at a palindrome." +
            "\n\nAlthough no one has proved it yet, it is thought that some numbers, like 196, never produce a palindrome. A number that never forms a palindrome through the reverse and add process is called a Lychrel number. Due to the theoretical nature of these numbers, and for the purpose of this problem, we shall assume that a number is Lychrel until proven otherwise. In addition you are given that for every number below ten-thousand, it will either (i) become a palindrome in less than fifty iterations, or, (ii)no one, with all the computing power that exists, has managed so far to map it to a palindrome.In fact, 10677 is the first number to be shown to require over fifty iterations before producing a palindrome: 4668731596684224866951378664(53 iterations, 28 - digits)." +
            "\n\nSurprisingly, there are palindromic numbers that are themselves Lychrel numbers; the first example is 4994." +
            "\n\nHow many Lychrel numbers are there below ten-thousand?";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 55; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
        {
	        int amount = 10000;
	        int count = 0;

	        for (long i = 0; i < amount; i++)
	        {
		        long reverse = Reverse(i);
		        bool isPalindrome = false;
		        long val = i;
		
		        for (int k = 0; k < 50; k++)
		        {
			        val = val + Reverse(val);
			        if (val == Reverse(val))
			        {
				        isPalindrome = true;
				        break;
			        }
		        }
		
		        if (isPalindrome)
			        count++;
	        }
            
            return (amount - count).ToString();
        }

        long Reverse(long number)
        {
	        long left = number;
	        long rev = 0;
	        while(left > 0)
	        {
		        long r = left % 10;  
		        rev = rev * 10 + r;
		        left = left / 10;
	        }
	
	        return rev;
        }
    }
}
