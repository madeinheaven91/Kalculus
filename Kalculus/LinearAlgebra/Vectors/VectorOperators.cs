using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.LinearAlgebra
{
    public partial class Vector
    {
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
        public static bool operator ==(Vector first, Vector second) => (first.Equals(second));
        public static bool operator !=(Vector first, Vector second) => (first.Equals(second));
    }
}
