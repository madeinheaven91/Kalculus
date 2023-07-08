using Kalculus.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kalculus.Combinatorics
{
    public static class Combinatorics
    {
        public static int Permutations(int set)
        {
            return set.Factorial();
        }

        public static int Arrangements(int choice, int set)
        {
            if (choice > set) throw new Exception("Number of chosen elements must be lower than number of elements in set.");
            if (choice < 1 || set < 1) throw new Exception("Either number of chosen elements or number of elements in set is less than 1.");
            return set.Factorial() / ((set - choice).Factorial());
        }

        public static int Combinations(int choice, int set)
        {
            if (choice > set) throw new Exception("Number of chosen elements must be lower than number of elements in set.");
            if (choice < 1 || set < 1) throw new Exception("Either number of chosen elements or number of elements in set is less than 1.");
            return set.Factorial() / ((set - choice).Factorial() * choice.Factorial());
        }
    }
}
