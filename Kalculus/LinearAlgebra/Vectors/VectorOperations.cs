using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/* TODO:
    методы с 2 векторами:
        узнать являются ли векторы линейно зависимыми ( можно обобщить для n векторов)
        
    

*/

namespace Kalculus.LinearAlgebra.Vectors
{
    public static class VectorOperations
    {
        /// <summary>
        /// Makes the vector with less dimensions out of 2 have the same amount as the other.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        public static void NormalizeDimensions(Vector first, Vector second)
        {
            if(first.Dimensions > second.Dimensions)
            {
                second.Dimensions = first.Dimensions;
            }
            else
            {
                first.Dimensions = second.Dimensions;
            }
        }

        /// <summary>
        /// Calculates the dot product of 2 vectors.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        /// <returns></returns>
        public static double DotProduct(Vector first, Vector second)
        {
            NormalizeDimensions(first, second);

            double product = 0;
            for(int i = 0; i < first.Dimensions; i++)
            {
                product += first.Content[i] * second.Content[i];
            }

            return product;
        }

        /// <summary>
        /// Calculates the angle between 2 vectors.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        /// <param name="Is angle in radians?"></param>
        /// <returns></returns>
        public static double Angle(Vector first, Vector second, bool inRadians = true) 
        {
            
            double cos = DotProduct(first, second) / (first.Magnitude * second.Magnitude);
            if(inRadians) return Math.Acos(cos);
            else return Math.Acos(cos) * 180 / Math.PI;

        }

        public static bool AreLinearlyDependent(Vector first, Vector second)
        {
            return false;
        }
    }
}
