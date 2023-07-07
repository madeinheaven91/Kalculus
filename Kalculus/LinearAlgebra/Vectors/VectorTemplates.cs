using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/* TODO:
    GetHashCode();
*/

namespace Kalculus.LinearAlgebra
{
    public partial class Vector
    {
        /// <summary>
        /// Returns the zero vector of a given dimension.
        /// </summary>
        public static Vector Zero(int dimensions = 2)
        {
            return new Vector(dimensions);
        }
        /// <summary>
        /// Returns the i unit vector of a given dimension.
        /// </summary>
        public static Vector UnitX(int dimensions = 2)
        {
            return new Vector(dimensions, 1);
        }
        /// <summary>
        /// Returns the j unit vector of a given dimension.
        /// </summary>
        public static Vector UnitY(int dimensions = 2)
        {
            return new Vector(dimensions, 0, 1);
        }
        /// <summary>
        /// Returns the k unit vector of a given dimension (minimum 3).
        /// </summary>
        public static Vector UnitZ(int dimensions = 3)
        {
            Helper.DimensionException(dimensions);
            return new Vector(dimensions, 0, 0, 1);
        }
        /// <summary>
        /// Returns the unit vector of a given dimension.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="dimensions"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Vector UnitN(int n, int dimensions = 2)
        {
            switch (n) {
                case 1:
                    return Vector.UnitX(dimensions);
                case 2:
                    return Vector.UnitY(dimensions);
                case 3:
                    if (dimensions == 2) return Vector.UnitZ(3);
                    else return Vector.UnitZ(dimensions);

                default:
                    if (n < 1) throw new Exception("Unable to create a unit vector with less than 1 dimension.");
                    Helper.DimensionException(dimensions);
                    Vector unitVector = new(n);
                    unitVector[n-1] = 1;
                    return unitVector;
            }
        }
    }
}
