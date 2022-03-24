using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Excercise 1");
            Console.WriteLine("Excercise 2");
            Console.WriteLine("Excercise 3");

            byte exerciseChoice=0;
            Console.Write("Select exercise of your choice(1, 2, 3): ");
            exerciseChoice = Convert.ToByte(Console.ReadLine());

            switch (exerciseChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter any Number: ");
                    string num = Console.ReadLine();

                    Console.WriteLine("1. Convert to Int");
                    Console.WriteLine("2. Convert to Float");
                    Console.WriteLine("3. Convert to Boolean");

                    byte ex1Choice = Convert.ToByte(Console.ReadLine());
                    switch (ex1Choice)
                    {
                        case 1:
                            Console.WriteLine("Converting using int.Parse: {0}", int.Parse(num));
                            Console.WriteLine("Converting using Convert.ToInt: {0}", Convert.ToInt32(num));
                            int a;
                            Console.WriteLine("Converting using int.tryParse: {0}", int.TryParse(num, out a));
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("Converting using Convert.ToDouble: {0}", Convert.ToDouble(num));
                            Console.WriteLine("Converting using float.Parse: {0}", float.Parse(num));
                            Console.WriteLine("Converting using Convert.ToSingle: {0}", Convert.ToSingle(num));
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Converting using Convert.ToBoolean: {0}", Convert.ToBoolean(num));
                            bool myVal;
                            Console.WriteLine("Converting using Boolean.tryParse: {0}", Boolean.TryParse(num, out myVal));
                            Console.ReadLine();
                            break;
                    }
                    Console.ReadLine();
                    break;


                case 2:
                    Console.Clear();
                    Console.WriteLine("== checks for refference identities");
                    Console.WriteLine("Equals() checks for contents only");
                    Console.WriteLine("RefferenceEquals() checks if two object instances are the same instance or not");

                    // for comparison between Equals and == following code is demonstrated
                    /*
                     We will use two objects, a string and a character array for our comparison
                    */
                    object name = "Niket";
                    char[] nameArray = { 'N', 'i', 'k', 'e', 't' };
                    object myName = new string(nameArray);
                    Console.WriteLine("\n\n Result of comparison using == operator is {0}", name == myName);
                    Console.WriteLine("\n Comparison using Equals method is {0}", myName.Equals(name));

                    // for referenceEquals following code is used
                    Console.WriteLine("\n Result of Comparison using ReferenceEquals() is {0}", object.ReferenceEquals(name, myName));
                    Console.ReadLine();
                    break;


                case 3:
                    Console.Clear();
                    int num1, num2, i, j, flag;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Enter any two numbers (second number should be greater than first between 2 and 1000)");
                        Console.Write("Enter number 1: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter number 2: ");
                        num2 = Convert.ToInt32(Console.ReadLine());
                    } while ((num1 > num2) && (num1 != num2) && ((num1>=2 && num1<=1000) && (num2>=2 && num2<=1000)));

                    Console.WriteLine("Prime Numbers between {0} and {1} are", num1, num2);
                    if(num1 == 2)
                    {
                        Console.WriteLine(num1);
                    }
                    if(num1%2 == 0)
                    {
                        num1++;
                    }

                    
                    for(i=num1; i<=num2; i= i+2)
                    {
                        flag = 1;
                        for (j=2; j*j<=i; ++j)
                        {
                            if(i%j == 0)
                            {
                                flag = 0;
                                break;
                            }
                        }

                        if(flag == 1)
                        {
                            Console.WriteLine(i);
                        }
                    }
                    Console.ReadLine();
                    break;


                default:
                    Console.WriteLine("Please Enter a valid choice!!!");
                    break;
            }
        }
    }
}
