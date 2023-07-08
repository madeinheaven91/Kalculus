using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus
{
    public static partial class IntExtension
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
    public static class Functions
    {
        
    }
}
