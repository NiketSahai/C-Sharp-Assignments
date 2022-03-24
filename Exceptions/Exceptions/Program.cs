using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Exceptions
{
    class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message)
            : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1 Display following message to user: “Enter any number from 1-5"
            //2 User enters an option from 1-5, show the exact message to user for the number selected
            int number = -1;

            int timesPlayed = 0;
            //you have played this game for 5 times. 
            while (timesPlayed < 5)
            {
                try
                {
                    Console.Write("Enter any number from 1-5: ");
                    string inputString = Console.ReadLine();
                    //If user does not enter correct number from 1-5 show error message. and then -> GOTO step 1
                    if (!userInputIsCorrect(inputString, 1, 5, 0, false))
                    {
                        number = -1;
                    }
                    else
                    {
                        int.TryParse(inputString, out number);
                        timesPlayed++;
                        if (number == 1)
                        {
                            getAnswer("Enter even number: ", number);
                        }
                        else if (number == 2)
                        {
                            getAnswer("Enter odd number: ", number);

                        }
                        else if (number == 3)
                        {
                            getAnswer("Enter a prime number: ", number);

                        }
                        else if (number == 4)
                        {
                            getAnswer("Enter a negative number: ", number);

                        }
                        else if (number == 5)
                        {
                            getAnswer("Enter a zero number: ", number);
                        }
                    }
                }
                catch (InvalidNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                    number = -1;
                }
            }
            Console.WriteLine("\nYou have played this game for 5 times.\n");

            Console.ReadLine();
        }
        static void getAnswer(string message, int method)
        {
            const int minValue = -1000000;
            const int maxValue = 1000000;
            Console.Write(message);
            string inputString = Console.ReadLine();
            if (userInputIsCorrect(inputString, minValue, maxValue, 0, false))
            {
                if (userInputIsCorrect(inputString, minValue, maxValue, method, true))
                {
                    Console.WriteLine("It is a correct answer.");
                }
            }
        }

        static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;


            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
                if (number % i == 0)
                    return false;
            return true;
        }
        
        static bool userInputIsCorrect(string inputString, int min, int max, int method, bool isNextFunctions)
        {
            if (!isNextFunctions)
            {
                int number = -1;
                if (!int.TryParse(inputString, out number))
                {
                    throw new InvalidNumberException(string.Format("Error: enter any integer number from {0}-{1}.", min, max));
                }
                else
                {
                    if (number < min || number > max)
                    {
                        throw new InvalidNumberException(string.Format("Error: enter any number from {0}-{1}.", min, max));
                    }
                    return true;
                }
            }
            else
            {
                int number = -1;
                int.TryParse(inputString, out number);
                if (method == 1)
                {
                    if (number % 2 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("\nIt is not even number. Try again.\n");
                    }
                }
                if (method == 2)
                {
                    if (number % 2 == 1)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("\nIt is not odd number. Try again.\n");
                    }
                }
                if (method == 3)
                {
                    if (isPrime(number))
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("\nIt is not a prime number. Try again.\n");
                    }
                }
                if (method == 4)
                {
                    if (number < 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("\nIt is not a negative number. Try again.\n");
                    }
                }
                if (method == 5)
                {
                    if (number == 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("\nIt is not a zero number. Try again.\n");
                    }
                }
                return false;
            }
        }
    }
}
