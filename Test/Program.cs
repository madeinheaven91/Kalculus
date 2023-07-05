using Kalculus;
using Kalculus.Matrices;

Matrix matrix = new Matrix(2, 4);
matrix.Content[1, 1] = 1;

Console.WriteLine(matrix);
Matrix matrix1 = new Matrix(2, 4);
Console.WriteLine(matrix1);

Console.WriteLine(matrix.Equals(matrix1));

