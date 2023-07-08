using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.Functions
{
    public static class Functions
    {
        public static int Factorial(this int value)
        {
            int result = 1;

            for (int i = 1; i < value + 1; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
