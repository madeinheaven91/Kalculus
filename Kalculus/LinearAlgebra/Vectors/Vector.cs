using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

/* TODO:
 * операторы:
        умножение векторов на скаляр (*)
        

    методы с 2 векторами:
        векторное произведение векторов
        скалярное произведение векторов\
        узнать угол между векторами
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
            Content = elements;
        }

        public Vector(int elementCount, params double[] elements)
        {
            Content = new double[elementCount];
            for (int i = 0; i < elementCount; i++)
            {

                if (i >= elements.Length)
                {
                    Content[i] = 0;
                }
                else if(i >= elementCount)
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

        /// <summary>
        /// Trims all zeros from the end until it reaches a non-zero vector component.
        /// </summary>
        public void Trim()
        {
            for (int i = this.Dimensions - 1; i > 0; i--)
            {
                if (this.Content[i] != 0)
                {
                    this.Dimensions = i + 1;
                    break;
                }
                if(i == 1)
                {
                    this.Dimensions = 2;
                    break;
                }
            }
        }

        /// <summary>
        /// Prints the content of a vector.
        /// </summary>
        public override string ToString()
        {
            string result = "(";
            foreach (var value in Content)
            {
                result += $"{value}, ";
            }
            return result.Remove(result.Length - 2, 2) + ")";
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
    }
}
