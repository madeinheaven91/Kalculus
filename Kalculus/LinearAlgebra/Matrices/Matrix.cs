using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kalculus.LinearAlgebra.Matrices
{
    public class Matrix
    {
        public Matrix(double[,] matrix, bool initParams = false)
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
                Determinant = Evaluate.Determinant(Content);
            }
        }

        public Matrix(int rows, int columns, bool initParams = false)
        {
            Rows = rows;
            Columns = columns;
            Content = new double[rows, columns];
            ElementsCount = rows * columns;
            InitParams = initParams;
            if (initParams)
            {
                Determinant = Evaluate.Determinant(Content);
            }
        }

        private bool InitParams;
        public int Rows { get; }
        public int Columns { get; }
        public int ElementsCount { get; }
        public double? Determinant { get; }
        public double[,] Content { get; set; }

        /// <summary>
        /// Returns whether the matrix is a square matrix or not.
        /// </summary>
        public bool IsSquare
        {
            get
            {
                if (Rows == Columns)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns whether the matrix is an identity matrix or not.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                if (IsSquare == false) return false;

                for (int row = 0; row < Rows; row++)
                {
                    for (int column = 0; column < Columns; column++)
                    {
                        switch (row == column)
                        {
                            case true:
                                switch (Content[row, column])
                                {
                                    case 1:
                                        continue;
                                    default:
                                        return false;
                                }
                            case false:
                                switch (Content[row, column])
                                {
                                    case 0:
                                        continue;
                                    default:
                                        return false;
                                }
                        }
                    }
                }
                return true;
            }
        }

        public double[,] GetMinor(int a, int b)
        {
            return Evaluate.Minor(Content, a, b);
        }

        /// <summary>
        /// Converts matrix contents to string.
        /// </summary>
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

        /// <summary>
        /// Returns whether matrices are equal or not.
        /// </summary>
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
