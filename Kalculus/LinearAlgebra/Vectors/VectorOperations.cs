using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/* TODO:
    методы с 2 векторами:
        узнать являются ли векторы линейно зависимыми ( можно обобщить для n векторов)
        
    

*/

namespace Kalculus.LinearAlgebra.Vectors
{
    internal static class VectorOperations
    {
        public static void DimensionException(int dimensions, int min = 2)
        {
            if (dimensions < min) throw new Exception($"The vector has less dimensions than {min}.");
        }
    }
}
