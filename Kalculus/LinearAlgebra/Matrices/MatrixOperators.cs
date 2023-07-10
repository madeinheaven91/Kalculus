namespace Kalculus.LinearAlgebra.Matrices
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

        public static Matrix operator+(Matrix leftMatrix, Matrix rightMatrix)
        {
            return Evaluate.MatrixSubtraction(leftMatrix, rightMatrix);
        }

    }
}
