using Kalculus;
using Kalculus.Matrices;
using Kalculus.Vectors;
using System.Runtime.ExceptionServices;
using System.Security;

double[] dude = new double[] { 1, 2 };
Vector vector = new(5, 1, 1);

vector.PrintContent();
Console.WriteLine(vector.Dimensions);
Console.WriteLine(vector.Magnitude);

Vector fisrt = new(2, 1, 1);
Vector second = new(3, 2, 0, 9);
Vector sum = second + fisrt;
sum.PrintContent();

Console.WriteLine($"{sum[0]}, {sum[1]}, {sum[2]}");