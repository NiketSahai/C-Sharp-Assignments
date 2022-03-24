using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegates
{
    public static class IntHelper
    {
        public static bool IsOdd(this int num)
        {
            return (num % 2 != 0);
        }

        public static bool IsEven(this int num)
        {
            return (num % 2 == 0);
        }

        public static bool IsPrime(this int num)
        {
            for(int i=2; i<num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IsDivisibleBy(this int num, int testNum)
        {
            return (num % testNum == 0);
        }
    }
}
