using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ExtensionMethodsDelegates
{
    public delegate bool NewDelegate(int element);

    class Program
    {
        public static bool GreaterThanFive(int element) => element > 5;
        public static bool LessThanFive(int element) => element < 5;

        public static void PrintList(IEnumerable<int> list)
        {
            foreach(int i in list)
                Console.WriteLine(i + " ");
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Exercise 11 \n2. Exercise 12 \n3. Exercise 13");
            Console.WriteLine("Enter your choice(1, 2, 3): ");
            int exerciseChoice = Convert.ToInt16(Console.ReadLine());

            switch (exerciseChoice)
            {
                #region exercise 11
                case 1:
                    Console.WriteLine("Enter any number: ");
                    int num = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Checking for Odd number: {0}", num.IsOdd());
                    Console.WriteLine("Checking for Even number: {0}", num.IsEven());
                    Console.WriteLine("Checking for Prime number: {0}", num.IsPrime());
                    Console.WriteLine("Enter any number to check for divisibility: ");
                    int testNum = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Result for divisiblity with {0} is {1}", testNum, num.IsDivisibleBy(testNum));
                    break;
                #endregion

                #region exercise 12
                case 2:
                    Console.WriteLine("\nWe are taking a list of integers: 1, 2, 3, 4, 5, 6, 7, 8, 9");
                    List<int> list = new List<int>();
                    list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                    // Point 1
                    NewDelegate d1 = (int element) => element % 2 != 0;
                    IEnumerable<int> query1 = list.Where(x => d1(x));

                    // Point 2
                    NewDelegate d2 = (int element) => element % 2 == 0;
                    IEnumerable<int> query2 = list.Where(x => d2(x));

                    // Point 3
                    NewDelegate d3 = delegate(int element) {
                        for (int i = 2; i < element; i++)
                            if (element % i == 0)
                                return false;
                        return true;
                    };
                    IEnumerable<int> query3 = list.Where(x => d3(x));

                    // Point 4
                    NewDelegate d4 = (int element) =>
                    {
                        for (int i = 2; i < element; i++)
                            if (element % i == 0)
                                return false;
                        return true;
                    };
                    IEnumerable<int> query4 = list.Where(x => d4(x));

                    // Point 5
                    IEnumerable<int> query5 = list.Where(LessThanFive);

                    // Point 6
                    IEnumerable<int> query6 = list.Where(GreaterThanFive);

                    // Point 7
                    NewDelegate d7 = (int element) => element % 3 == 0;
                    IEnumerable<int> query7 = list.Where(x => d7(x));

                    // Point 8
                    NewDelegate d8 = delegate (int element)
                    {
                        return (element % 3 == 1);
                    };
                    IEnumerable<int> query8 = list.Where(x => d8(x));

                    // Point 9
                    NewDelegate d9 = (int element) => element % 3 == 2;
                    IEnumerable<int> query9 = list.Where(x => d9(x));

                    Console.WriteLine("Printing Results of Point 1: ");
                    PrintList(query1);

                    Console.WriteLine("Printing Results of Point 2: ");
                    PrintList(query2);

                    Console.WriteLine("Printing Results of Point 3: ");
                    PrintList(query3);

                    Console.WriteLine("Printing Results of Point 4: ");
                    PrintList(query4);

                    Console.WriteLine("Printing Results of Point 5: ");
                    PrintList(query5);

                    Console.WriteLine("Printing Results of Point 6: ");
                    PrintList(query6);

                    Console.WriteLine("Printing Results of Point 7: ");
                    PrintList(query7);

                    Console.WriteLine("Printing Results of Point 8: ");
                    PrintList(query8);

                    Console.WriteLine("Printing Results of Point 9: ");
                    PrintList(query9);

                    break;
                #endregion

                #region exercise 13
                case 3:
                    int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                    Console.WriteLine("Result of CustomAll");
                    var all = data.CustomAll(i => i%2==0);
                    Console.WriteLine(all);

                    Console.WriteLine("Result of CustomAny");
                    var any = data.CustomAny(i => i%3==0);
                    Console.WriteLine(any);

                    Console.WriteLine("Result of CustomMax");
                    var max = data.CustomMax(i => i<5);
                    Console.WriteLine(max);

                    Console.WriteLine("Result of CustomMin");
                    var min = data.CustomMin(i => i<5);
                    Console.WriteLine(min);

                    Console.WriteLine("Result of CustomWhere");
                    var where = data.CustomWhere(i => i%2==0);
                    PrintList(where);

                    Console.WriteLine("Result of CustomSelect");
                    var select = data.CustomSelect(i => i*i);
                    PrintList(select);

                    Console.ReadLine();
                    break;

                    #endregion
                default:
                    Console.WriteLine("Please enter correct choice!!!");
                    break;

                Console.ReadLine();
            }
        }
    }
}
