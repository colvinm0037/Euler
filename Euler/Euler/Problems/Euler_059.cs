using Euler.Euler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Euler_059 : IEulerProblem
    {
        private string _description = "Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange). For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107." +
            "\n\n\nA modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key.The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65." +
            "\n\n\nFor unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes.The user would keep the encrypted message and the encryption key in different locations, and without both \"halves\", it is impossible to decrypt the message." + 
            "\n\n\nUnfortunately, this method is impractical for most users, so the modified method is to use a password as a key. If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message.The balance for this method is using a sufficiently long password key for security, but short enough to be memorable." + 
            "\n\n\nYour task has been made easy, as the encryption key consists of three lower case characters.Using cipher.txt(right click and 'Save Link/Target As...'), a file containing the encrypted ASCII codes, and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.";

        public string Run()
        {
            return Main();
        }

        public int Number
        {
            get { return 59; }
        }

        public string Description
        {
            get { return _description; }
        }

        string Main()
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
		        using (StreamReader sr = new StreamReader("Euler\\Resources\\p059_cipher.txt"))
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

			        Console.WriteLine(password[0] + " " + password[1] + " " + password[2]);
			        Console.WriteLine(message);
			        Console.WriteLine("Sum: " + sum);
                    return sum.ToString();                    
		        }
	        }
            return "";
        }
    }
}
