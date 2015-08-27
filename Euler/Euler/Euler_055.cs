using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_055
    {
        void Main()
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
		
            Console.WriteLine("Lycheral Numbers below " + amount + ": " + (amount - count));
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
