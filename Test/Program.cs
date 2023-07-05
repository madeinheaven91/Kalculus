using Kalculus;
using Kalculus.Matrices;



double[,] matrix = new double[4, 4] { 
    { 1, 0, 0, 1},
    { 0, 1, 0, 0},
    { 0, 0, 1, 0},
    { 0, 0, 0, 1} };

Matrix m = new(matrix, false);

Console.WriteLine(m.IsIdentity());