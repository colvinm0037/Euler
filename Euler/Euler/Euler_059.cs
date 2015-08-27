using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler_059
    {
        void Main()
{
	// Build all possible passwords
	List<List<int>> passwords = new List<List<int>>();
	for (int i = 97; i <= 122; i++)
	{
		for (int j = 97; j <= 122; j++)
		{
			for (int k = 97; k <= 122; k++)
			{
				var password = new List<int> { i, j, k};
				passwords.Add(password);
			}
		}
	}
	
	// Read in text file
	string line = null;
	var values = new List<string>();
	try
	{
		using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\p059_cipher.txt"))
		{
			while ((line = sr.ReadLine()) != null)
				values = line.Split(',').ToList();				
		}
	}
	catch (Exception e)
	{
		Console.WriteLine("The file could not be read:");
		Console.WriteLine(e.Message);
	}

	// Convert encoded message to list of ints
	var intValues = new List<int>();
	foreach (string s in values)
		intValues.Add(Int32.Parse(s));

	// Decode the message with every password
	foreach (var password in passwords)
	{
		int counter = 0;
		var messageBuilder = new StringBuilder();
		foreach (int val in intValues)
		{
			messageBuilder.Append((char) (val ^ password[counter]));
			counter++;
			if (counter >= 3) counter = 0;
		}
		string message = messageBuilder.ToString();
		if (!(message.Contains("#") || message.Contains("~") || message.Contains("&")
				|| message.Contains("%") || message.Contains("{") || message.Contains("}")))
        {		
			int sum = 0;
			foreach (char c in message)
				sum += (int)c;

			Console.WriteLine(password[0] + " " +password[1] + " " + password[2]);
			Console.WriteLine(message);
			Console.WriteLine("Sum: " + sum);
			break;
		}
	}
}
    }
}
