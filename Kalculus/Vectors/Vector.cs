using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/* TODO:
 * операторы:
        умножение векторов на скаляр (*)
        векторное произведение векторов
        скалярное произведение векторов\

    методы с 2 векторами:
        узнать угол между векторами
        узнать являются ли векторы линейно зависимыми ( можно обобщить для n векторов)
        
    

*/

namespace Kalculus.Vectors
{
    public class Vector
    {
        public Vector(double[] elements) {
            Content = elements;
        }

        public Vector(int elementCount, params double[] elements)
        {
            if (elements.Length > elementCount) throw new ArgumentException("Too many values.");
            Content = new double[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                
                if (i >= elements.Length) {
                    Content[i] = 0; 
                }
                else
                {
                    Content[i] = elements[i];
                }
            }
        }

        // сделать так, чтобы можно было написать vector[n] и выдавалось значение n+1-ной координаты вектора
        public double this[int index]
        {
            get
            {
                return this.Content[index];
            }
            set 
            {
                this.Content[index] = value;
            }
        }

        public double[] Content { get; set; }
        public int Dimensions { get { return Content.Length; } }
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

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {

            Vector min;
            Vector max;
            if(firstVector.Dimensions > secondVector.Dimensions)
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
            }
            return result;
        }
    }
}
