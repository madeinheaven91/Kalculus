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

            if (content.Length == 0)
                return null;
            if (content.Length == 1)
                return content[0, 0];
            if (content.Length == 4)
                return (content[0, 0] * content[1, 1]) - (content[0, 1] * content[1, 0]);

            throw new Exception();
        }
        public static double[,] Minor(double[,] content, int row, int column)
        {
            if (content.GetLength(0) != content.GetLength(1))
                throw new ArgumentException("The matrix must be square");
            if (row <= 0 || column <= 0 || row > content.GetLength(0) - 1 || column > content.GetLength(1))
                throw new ArgumentException();

            double[,] minor = new double[content.GetLength(0) - 1, content.GetLength(1) - 1];

            for (int i = 0; i < content.GetLength(0); i++)
            {
                for (int j = 0; j < content.GetLength(1); j++)
                {

                    minor[i, j]
                    if (i == row || j == column)
                        

                }
            }
            throw new Exception();

        }
    }
}
