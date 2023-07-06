# Kalculus

Kalculus is a mathematical library made by 2 idiots.

Things currently added:

Matrix class:
  Fields:
    public int Rows { get; }
    public int Columns { get; }
    public int ElementsCount { get; }
    public double? Determinant { get; }
    public double[,] Content { get; set; }
    public bool IsSquare ( get; }
    public bool IsIdentity ( get; )
  Methods:
    public double[,] GetMinor(int a, int b)
    
Vector class:
  Fields:
    public double[] Content { get; set; }
    public int Dimensions { get; set; }
    public double Magnitude { get; }
    public double MagnitudeSquared { get; }
    public Vector Normalized { get; }
  Methods:
    public static Vector Normalize(Vector vector)
    public Vector Trim(int min = 2)
    public static void EquateDimensions(Vector first, Vector second)
    public Vector EquateDimensions(Vector vector)
    public static double DotProduct(Vector first, Vector second)
    public static double Angle(Vector first, Vector second, bool inRadians = true)
  Operators:
    Vector + Vector
    Vector - Vector
    -Vector
    Vector * Scalar
    Vector / Scalar
