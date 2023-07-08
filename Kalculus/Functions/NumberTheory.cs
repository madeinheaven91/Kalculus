using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.Functions
{
    public static class Calculate
    {
        public static int[] Factorize(this int value)
        {
            List<int> result = new List<int>();
            int processed = value;
            int factor = 2;
            while (processed != 1)
            {
                if (processed % factor == 0)
                {
                    result.Add(factor);
                    processed /= factor;
                    continue;
                }
                factor++;
            }
            return result.ToArray();
        }

        public static int GCF(int first, int second)
        {
           while(first != 0 && second != 0)
            {
                if(first > second)
                {
                    first = first % second;
                }
                else
                {
                    second = second % first;
                }
            }

            return first + second;
        }

        public static int LCM(int first, int second)
        {
            return first * second / GCF(first, second);
        }

    }
}
