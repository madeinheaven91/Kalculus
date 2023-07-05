namespace Kalculus
{
    public class Functions
    {

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