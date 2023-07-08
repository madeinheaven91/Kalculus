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
            if (leftMatrix.Columns != rightMatrix.Columns || leftMatrix.Rows != rightMatrix.Columns)
                throw new ArgumentException("The matrices must have same size");

            int cols = leftMatrix.Columns;
            int rows = rightMatrix.Rows;
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = leftMatrix[i,j] + rightMatrix[i,j];
                }
            }
            return new Matrix(matrix);
        }

    }
}
