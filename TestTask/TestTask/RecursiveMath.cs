using System;

namespace TestTask
{
    public static class RecursiveMath
    {
        public static int FibonacciNumber(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must be >= 0", nameof(index));
            }
            else if (index <= 1)
            {
                return index;
            }
            else
            {
                return FibonacciNumber(index - 2) + FibonacciNumber(index - 1);
            }
        }

        public static float Pow(float number, int power)
        {
            if (power == 0)
            {
                return 1.0f;
            }

            if (ApproximatelyEquals(number,0.0f) && power <= 0) {
                
                throw new ArithmeticException("Can not raise 0 to a power less than 1");
            }

            if (ApproximatelyEquals(number, 0.0f) || ApproximatelyEquals(number, 1.0f))
            {
                return number;
            }
            
            if (power > 1)
            {
                return number * Pow(number, power - 1) ;
            }
            
            if (power < 1)
            {
                return 1 / number * Pow(number, power + 1);
            }

            return number;
        }
        
        private static bool ApproximatelyEquals(float a, float b)
        {
            return Math.Abs(a - b) < 0.00001f;
        }
    }
}