using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kalculus.LinearAlgebra.Vectors;

/* TODO:
 *  GetHashCode();
 *  CrossProduct(Vector rhs, Vector lhs);
 *  TripleProduct(Vector first, Vector second, Vector third);
 *  Spacial Operations:
 *      Scale to space:
 *          берет базисные векторы пространства и подгоняет координаты вектора под эти базисы.
 *          сделать это можно по типу умножения матрицы на вектор Av = w, где A - матрица, состоящая из базисных векторов пространства, v - исходный вектор, w - результат
*/

namespace Kalculus.LinearAlgebra
{
    public partial class Vector
    {
        public Vector(double[] elements)
        {
            Helper.DimensionException(elements.Length);
            Content = elements;
        }
        public Vector(int elementCount, params double[] elements)
        {
            Helper.DimensionException(elementCount);
            Content = new double[elementCount];
            for (int i = 0; i < elementCount; i++)
            {

                if (i >= elements.Length)
                {
                    Content[i] = 0;
                }
                else if (i >= elementCount)
                {
                    break;
                }
                else
                {
                    Content[i] = elements[i];
                }
            }
        }

        public double this[int index]
        {
            get
            {
                return Content[index];
            }
            set
            {
                Content[index] = value;
            }
        }

        public double[] Content { get; set; }
        public int Dimensions {
            get {
                return Content.Length;
            }
            set
            {

                double[] newContent = new double[value];

                if (value > Content.Length)
                {
                    for (int i = 0; i < Content.Length; i++)
                    {
                        newContent[i] = Content[i];
                    }
                }
                else
                {
                    for (int i = 0; i < value; i++)
                    {
                        newContent[i] = Content[i];
                    }
                }
                Content = newContent;
            }
        }
        public double Magnitude
        {
            get
            {
                double sum = 0;
                foreach (var element in Content)
                {
                    sum += element * element;

                }
                return Math.Sqrt(sum);
            }
        }
        public double MagnitudeSquared
        {
            get
            {
                double sum = 0;
                foreach (var element in Content)
                {
                    sum += element * element;

                }
                return sum;
            }
        }
        public Vector Normalized { get
            {
                return Normalize(this);
            }
        }
        private Space? space;
        public Space? Space {
            get
            {
                if (space is null) return null;
                return space;
            }
            set
            {
                space?.Vectors.Remove(this);
                if (Dimensions != value.Dimensions) this.EquateDimensions(value.Dimensions);
                space = value;
                space.Vectors.Add(this);
            }
        }
        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector Normalize(Vector vector)
        {
            double num = vector.Magnitude;
            if (num > 1E-05f)
            {
                return vector / vector.Magnitude;
            }
            else
            {
                return new Vector(vector.Dimensions);
            }
        }

        /// <summary>
        /// Trims all zeros from the end until it reaches a non-zero vector component.
        /// </summary>
        public Vector Trim(int min = 2)
        {
            Helper.DimensionException(min);
            Vector result = this;
            for (int i = result.Dimensions - 1; i > 0; i--)
            {
                if (result.Content[i] != 0)
                {
                    result.Dimensions = i + 1;
                    return result;
                }
                if (i == min - 1)
                {
                    result.Dimensions = min;
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Makes the vector with less dimensions out of 2 have the same amount as the other.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        public static void EquateDimensions(Vector first, Vector second)
        {
            if (first.Dimensions > second.Dimensions)
            {
                second.Dimensions = first.Dimensions;
            }
            else
            {
                first.Dimensions = second.Dimensions;
            }
        }

        /// <summary>
        /// Makes the vector has the same amount of dimension as the other.
        /// </summary>
        public Vector EquateDimensions(Vector vector)
        {
            this.Dimensions = vector.Dimensions;
            return this;
        }

        /// <summary>
        /// Sets the amount of vector's dimensions to an arbitrary number equal or greater than 2.
        /// </summary>
        public Vector EquateDimensions(int dimensions)
        {
            Vector vector = new(dimensions);
            this.Dimensions = vector.Dimensions;
            return this;
        }



        /// <summary>
        /// Calculates the dot product of 2 vectors.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        /// <returns></returns>
        public static double DotProduct(Vector first, Vector second)
        {
            EquateDimensions(first, second);

            double product = 0;
            for (int i = 0; i < first.Dimensions; i++)
            {
                product += first.Content[i] * second.Content[i];
            }

            return product;
        }

        /// <summary>
        /// Calculates the cross product of 2 3-dimensional vectors.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        /// <returns></returns>
        /*public static Vector CrossProduct(Vector rhs, Vector lhs)
        {
            Vector rhsMod, lhsMod;
            if (rhs.Dimensions > 3)
            {
                rhsMod = rhs.Trim(3);
            }
            else
            {
                rhsMod = rhs.EquateDimensions(3);
            }
            if (lhs.Dimensions > 3)
            {
                lhsMod = lhs.Trim(3);
            }
            else
            {
                lhsMod = lhs.EquateDimensions(3);
            }

            Vector product = new(3);

            

            





            return product;
        }*/

        /// <summary>
        /// Calculates the triple product of 2 vectors.
        /// </summary>
        /// <param name="First vector"></param>
        /// <param name="Second vector"></param>
        /// <returns></returns>
        /*public static double TripleProduct(Vector first, Vector second, Vector third)
        {
            EquateDimensions(first, second);
            EquateDimensions(first, third);

            double product = 0;
            return product;
        }*/

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
            if (inRadians) return Math.Acos(cos);
            else return Math.Acos(cos) * 180 / Math.PI;

        }

        

        /// <summary>
        /// Returns whether two vectors are collinear.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool AreCollinear(Vector first, Vector second)
        {
            EquateDimensions (first, second);
            for(int i = 0; i < first.Dimensions; i++)
            {
                if (first[i] != 0 && second[i] != 0)
                {
                    double n = first[i] / second[i];
                    if (n * second == first) return true;
                }
            }
            

            return false;
        }

        /// <summary>
        /// Returns whether two vectors are orthogonal.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool AreOrthogonal(Vector first, Vector second) => DotProduct(first, second) == 0;

        public override string ToString()
        {
            string result = "column(";
            foreach (var value in Content)
            {
                result += $"{value}, ";
            }
            return result.Remove(result.Length - 2, 2) + ")";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not Vector) return false;

            Vector? vector = obj as Vector;
            if (Dimensions != vector.Dimensions)
            {
                return false;
            }

            for (int i = 0; i < Dimensions; i++)
            {
                if (Content[i] != vector[i])
                {
                    return false;
                }
            }

            return true;
        }        
    }
}
