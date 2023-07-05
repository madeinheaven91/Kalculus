using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.Matrices
{
    internal class MatrixEvaluate
    {
        public double? Determinant(double[,] content)
        {
            if (content.GetLength(0) != content.GetLength(1)) 
                throw new ArgumentNullException("The matrix must be square");

            if (content.Length == 0)
                return null;
            if (content.Length == 1)
                return content[0, 0];
            if (content.Length == 4)
                return (content[0, 0] * content[1, 1]) - (content[0, 1] * content[1, 0]);
            throw new Exception();
        }
    }
}
