using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.LinearAlgebra.Matrices
{
    public partial class Matrix
    {
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return ScalarMultiply(scalar, matrix);
        }
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return ScalarMultiply(scalar, matrix);
        }
        private static Matrix ScalarMultiply (double scalar, Matrix matrix)
        {
            int rows = matrix.Rows;
            int cols = matrix.Columns;

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = scalar * matrix[i, j];
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator*(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.Columns != rightMatrix.Rows)
            {
                throw new ArgumentException("Invalid matrix dimensions");
            }

            int rows = leftMatrix.Rows;
            int cols = rightMatrix.Columns;
            int commonLength = leftMatrix.Columns;

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < commonLength; k++)
                    {
                        sum += leftMatrix[i, k] * rightMatrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return new Matrix(result);
        }
    }
}
