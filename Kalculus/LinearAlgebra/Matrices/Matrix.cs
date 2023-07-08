using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Kalculus.LinearAlgebra.Matrices;

namespace Kalculus.LinearAlgebra
{
    public partial class Matrix
    {
        
        public Matrix(int n) : this(Evaluate.GetIdentityMatrix(n))
        {

        }

        public Matrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Rows = rows;
            Columns = cols;
            Content = matrix;
            Length = rows * cols;
            if(rows == cols) Determinant = Evaluate.Determinant(this);
        }

        private int NumberMaxLength
        {
            get
            {
                double[,] array = Content;
                int maxLength = 0;

                foreach (var item in array)
                {
                    string stringValue = item.ToString();
                    int length = stringValue.Length;

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }

                return maxLength;
            }
        }

        public int Rows { get; }
        public int Columns { get; }
        public int Length { get; }
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

        /// <summary>
        /// Returns a minor matrix with an element in row a and in column b
        /// </summary>
        public Matrix GetMinor(int a, int b)
        {
            return Evaluate.Minor(this, a, b);
        }

        public Vector GetColumn(int column)
        {
            Vector vector = new(Rows);
            for(int i = 0; i < Rows; i++)
            {
                
                vector[i] = Content[i, column];
            }
            return vector;
        }
        public Vector[] ToVectorArray()
        {
            Vector[] vectors = new Vector[Columns];
            for(int i = 0; i < Columns; i++)
            {
                vectors[i] = this.GetColumn(i);
            }

            return vectors;
        }
        public double this[int column, int row]
        {
            get
            {
                return Content[row, column];
            }
            set
            {
                Content[row, column] = value;
            }
        }

        public override string ToString()
        {
            int rows = Rows;
            int cols = Columns;

            int maxLength = NumberMaxLength + 1;
            StringBuilder sb = new();


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Content[i, j] == -0)
                        Content[i, j] = 0;
                    string value = Content[i, j].ToString(); 
                    int columnWidth = maxLength; 

                    sb.Append(value);

                    if (j < cols - 1)
                    {
                        int spacesToAdd = columnWidth - value.Length;
                        sb.Append(new string(' ', spacesToAdd + 1));
                    }
                }

                sb.AppendLine(); 
            }

            return sb.ToString();
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Rows, Columns);
        }

    }
}
