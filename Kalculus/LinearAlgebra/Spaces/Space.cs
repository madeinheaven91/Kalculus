using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalculus.LinearAlgebra;
/*
 * TODO:
 *  разобраться че вообще происходит
 */
namespace Kalculus.LinearAlgebra
{
    public partial class Space
    {
        /*public Space(Vector[] basis) {
            for(int i = 0; i < basis.Length; i++)
            {
                Basis[i] = basis[i];
            }
        }
        public Space(Matrix matrix)
        {

        }*/
        public Space(int dimensions)
        {
            Basis = new Vector[dimensions];
            for (int i = 0; i < dimensions; i++)
            {
                
                Basis[i] = Vector.UnitN(i+1, dimensions);
            }
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
    }
}
