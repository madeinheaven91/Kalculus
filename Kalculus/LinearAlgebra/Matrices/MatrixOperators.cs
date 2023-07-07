using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Kalculus.LinearAlgebra;

namespace Kalculus.LinearAlgebra
{
    public partial class Matrix
    {
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return Evaluate.MultiplyByScalar(scalar, matrix);
        }

        public static Matrix operator*(Matrix leftMatrix, Matrix rightMatrix)
        {
            return Evaluate.MultiplyMatrices(leftMatrix, rightMatrix);
        }
    }
}
