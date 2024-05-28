using System;
using System.IO;

namespace Lab0_A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int minNumber = -1;

            while (minNumber < 0)
            {
                Console.Write("Enter the low number: ");
                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out minNumber) && minNumber >= 0)
                {
                    Console.WriteLine($"The user typed the {userInput} number.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative integer.");
                    minNumber = -1; 
                }
            }

            int maxNumber = minNumber;

            while (maxNumber <= minNumber)
            {
                Console.Write("\nEnter the high number: ");
                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out maxNumber) && maxNumber > minNumber)
                {
                    Console.WriteLine($"The user typed the {userInput} number.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer greater than the low number.");
                    maxNumber = minNumber; 
                }
            }

            var primeNumbers = new System.Collections.Generic.List<int>();

            for (int i = minNumber; i < maxNumber; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            foreach (int prime in primeNumbers)
            {
                Console.WriteLine($"Prime: {prime}");
            }

            string filePath = @"C:\Users\Omkumar\Desktop\OOP2\lab1\lab1\numbers.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = primeNumbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(primeNumbers[i]);
                }
            }
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
