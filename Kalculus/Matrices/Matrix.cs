using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.Matrices
{
    public class Matrix
    {
        public Matrix(double[,] matrix, bool initParams = true)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Rows = rows;
            Columns = cols;
            Content = matrix;
            ElementsCount = rows * cols;
            InitParams = initParams;
            if (initParams)
            {
                MatrixEvaluate evaluate = new MatrixEvaluate();
                Determinant = evaluate.Determinant(Content);
            }
        }
        private bool InitParams;
        public int Rows { get; }
        public int Columns { get; }
        public int ElementsCount { get; }
        public double? Determinant { get; }
        public double[,] Content { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    stringBuilder.Append(Content[i, j]);
                }
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType() || obj is not Matrix)
                return false;

            Matrix other = (Matrix)obj;
            if (Rows != other.Rows || Columns != other.Columns)
                return false;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Content[i, j] != other.Content[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
