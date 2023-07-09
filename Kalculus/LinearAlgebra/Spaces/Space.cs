using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalculus.LinearAlgebra;
using Kalculus.LinearAlgebra.Vectors;
using Kalculus.LinearAlgebra.Matrices;

using static System.Net.Mime.MediaTypeNames;
/*
 * TODO:
 *  разобраться че вообще происходит
 */
namespace Kalculus.LinearAlgebra
{
    public partial class Space
    {
        public Space(Vector[] basis) {
            for(int i = 0; i < basis.Length; i++)
            {
                Basis[i] = basis[i];
            }
            Vectors = new List<Vector>();
        }
        public Space(Matrix matrix)
        {
            Helper.MatrixSquareException(matrix);
            Basis = matrix.ToVectorArray();
            Vectors = new List<Vector>();
        }
        public Space(int dimensions)
        {
            Basis = new Vector[dimensions];
            for (int i = 0; i < dimensions; i++)
            {
                
                Basis[i] = Vector.UnitN(i+1, dimensions);
            }

            Vectors = new List<Vector>();
        }

        public Vector this[int index]
        {
            get
            {
                return Basis[index];
            }
            set
            {
                Basis[index] = value;
            }
        }
        public Vector[] Basis { get; } 
        public int Dimensions { get
            {
                return Basis.Length;
            }
        }
        public int Span { get; }
        public List<Vector>? Vectors;
        public int SetModule
        {
            get { return Vectors.Count; }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < Dimensions; i++)
            {
                sb.Append($"e{i+1} - {Basis[i]}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
