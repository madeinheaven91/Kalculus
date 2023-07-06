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
    методы с 2 векторами:
        векторное произведение векторов
        узнать являются ли векторы линейно зависимыми ( можно обобщить для n векторов)

    сокращения:
        добавить сокращения для нулевого вектора, для орт и прочего
*/

namespace Kalculus.LinearAlgebra.Vectors
{
    public class Vector
    {
        public Vector(double[] elements)
        {
            VectorOperations.DimensionException(elements.Length);
            Content = elements;
        }

        public Vector(int elementCount, params double[] elements)
        {
            VectorOperations.DimensionException(elementCount);
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
            VectorOperations.DimensionException(min);
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

        // TODO
        /// <summary>
        /// Returns whether two vectors are linearly dependent.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool AreLinearlyDependent(Vector first, Vector second)
        {
            return false;
        }

        /// <summary>
        /// Prints the content of a vector.
        /// </summary>
        public void PrintContent()
        {
            string result = "(";
            foreach (var value in Content)
            {
                result += $"{value}, ";
            }
            Console.WriteLine(result.Remove(result.Length - 2, 2) + ")");
        }

        public static Vector Zero(int dimensions = 2){
            return new Vector(dimensions);
        }
        public static Vector IUnit(int dimensions = 2)
        {
            return new Vector(dimensions, 1);
        }
        public static Vector JUnit(int dimensions = 2)
        {
            return new Vector(dimensions, 0, 1);
        }
        public static Vector KUnit(int dimensions = 3)
        {
            VectorOperations.DimensionException(dimensions, 3);
            return new Vector(dimensions, 0, 0, 1);
        }


        public static Vector operator +(Vector firstVector, Vector secondVector)
        {

            Vector min;
            Vector max;
            if (firstVector.Dimensions > secondVector.Dimensions)
            {
                min = secondVector;
                max = firstVector;
            }
            else
            {
                min = firstVector;
                max = secondVector;
            }

            min = new(max.Dimensions, min.Content);

            Vector result = new(max.Dimensions);
            for (int i = 0; i < max.Dimensions; i++)
            {
                result.Content[i] = max.Content[i] + min.Content[i];
                Console.WriteLine(max.Content[i] + " " + min.Content[i]);
            }
            return result;
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {

            Vector min;
            Vector max;
            if (firstVector.Dimensions > secondVector.Dimensions)
            {
                min = secondVector;
                max = firstVector;
            }
            else
            {
                min = firstVector;
                max = secondVector;
            }

            min = new(max.Dimensions, min.Content);

            Vector result = new(max.Dimensions);
            for (int i = 0; i < max.Dimensions; i++)
            {
                result.Content[i] = max.Content[i] - min.Content[i];
            }
            return result;
        }

        public static Vector operator -(Vector vector)
        {
            for (int i = 0; i < vector.Dimensions; i++)
            {
                vector.Content[i] *= -1;
            }
            return vector;
        }
        public static Vector operator *(double scalar, Vector vector)
        {
            for (int i = 0; i < vector.Dimensions; i++)
            {
                vector.Content[i] *= scalar;
            }
            return vector;
        }
        public static Vector operator *(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.Dimensions; i++)
            {
                vector.Content[i] *= scalar;
            }
            return vector;
        }
        public static Vector operator /(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.Dimensions; i++)
            {
                vector.Content[i] /= scalar;
            }
            return vector;
        }
    }
}
