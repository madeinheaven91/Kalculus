namespace Kalculus
{
    public class Functions
    {
        public static double Power(double baseNumber, double exponent)
        {
            if (exponent == 0)
                return 1;

            double result = 1;
            int absExponent = (int)Math.Abs(exponent);

            for (int i = 0; i < absExponent; i++)
            {
                result *= baseNumber;
            }

            if (exponent < 0)
                result = 1 / result;

            double fractionalPart = exponent - absExponent;

            if (fractionalPart != 0)
                result *= Root(baseNumber, fractionalPart);

            return result;
        }

        private static double Root(double baseNumber, double degree)
        {
            const double epsilon = 1e-10; // Точность вычислений

            double x = 1; // Начальное приближение
            double delta;

            do
            {
                double powX = 1;
                for (int i = 0; i < degree; i++)
                {
                    powX *= x;
                }

                double prevX = x;
                x = (1 / degree) * ((degree - 1) * x + (baseNumber / powX));
                delta = Abs(x - prevX);
            }
            while (delta > epsilon);

            return x;
        }

        public static double Abs(double x)
        {
            if (x == 0) return 0;
            if (x < 0) return -x;
            return x;
        }

        public static decimal Logarithm(decimal arg, decimal baseValue)
        {
            decimal low = 0;
            decimal high = arg;

            while(high - low > Basic.EPSILON)
            {
                decimal mid = (low + high) / 2;
                decimal value = (decimal) Math.Pow((double) baseValue, (double) mid);

                if (value < arg) low = mid;
                else high = mid;

            }

            return low;
        }
    }
}