using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.LinearAlgebra.Matrices
{
    internal static class Evaluate
    {
        public static double Determinant(Matrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("The matrix must be square");

            if (matrix.Length == 0)
                return 0;
            if (matrix.Length == 1)
                return matrix[0, 0];
            if (matrix.Length == 4)
                return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);


            double determinant = 0;

            for (int j = 0; j < matrix.Columns; j++)
            {
                Matrix subMatrix = Minor(matrix, 0, j);
                double subDeterminant = Determinant(subMatrix);
                determinant += Math.Pow(-1, j) * matrix[0, j] * subDeterminant;
            }
            return determinant;
        }

        public static Matrix Minor(Matrix matrix, int row, int column)
        {

            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("The matrix must be square");
            if (row < 0 || column < 0 || row > matrix.Rows - 1 || column > matrix.Columns)
                throw new ArgumentException();

            int size = matrix.Rows;
            double[,] minor = new double[size - 1, size - 1];
            int m = 0, n = 0;

            for (int i = 0; i < size; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j != column)
                        {
                            minor[m, n] = matrix[i, j];
                            n++;
                        }
                    }
                    m++;
                    n = 0;
                }
            }
            return new Matrix(minor);
        }

        public static Matrix MultiplyByScalar(double scalar, Matrix matrix)
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

        public static Matrix MultiplyMatrices(Matrix leftMatrix, Matrix rightMatrix) 
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

        public static double[,] GetIndentityMatrix(int n)
        {
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }
            }

            return matrix;
        }

    }
}
