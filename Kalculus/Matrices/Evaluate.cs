using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.Matrices
{
    internal static class Evaluate
    {
        public static double? Determinant(double[,] content)
        {
            if (content.GetLength(0) != content.GetLength(1))
                throw new ArgumentException("The matrix must be square");
            int n = content.GetLength(0);

            if (content.Length == 0)
                return null;
            if (content.Length == 1)
                return content[0, 0];
            if (content.Length == 4)
                return (content[0, 0] * content[1, 1]) - (content[0, 1] * content[1, 0]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                }
            }
                    throw new NotImplementedException();

        }
        public static double[,] Minor(double[,] matrix, int row, int column)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("The matrix must be square");
            if (row <= 0 || column <= 0 || row > matrix.GetLength(0) - 1 || column > matrix.GetLength(1))
                throw new ArgumentException();

            int size = matrix.GetLength(0);
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
            return minor;
        }
    }
}
