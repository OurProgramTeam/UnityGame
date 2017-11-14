using System;

namespace Scripts.Utils
{
    public static class NumberUtils
    {
        public static float RoundByStep(float number, float step)
        {
            float result = (float)Math.Round(number / step) * step;

            return result;
        }

        public static double RoundByStep(double number, double step)
        {
            double result = Math.Round(number / step) * step;

            return result;
        }

        public static float RoundByDigitsCount(float number, int digitsCount)
        {
            return (float)Math.Round(number, digitsCount);
        }
    }
}