using System;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public static class Derivative
    {
        public static double Calculate(IFunction func, double x)
        {
            if (!func.IsValidForDerivative(x))
            {
                string message;
                if (func.Name == "arcsin")
                    message = "Для производной arcsin(x): |x| должен быть < 1";
                else if (func.Name == "arccos")
                    message = "Для производной arccos(x): |x| должен быть < 1";
                else
                    message = "Недопустимое значение x для производной";

                throw new ArgumentOutOfRangeException(nameof(x), message);
            }

            double denominator = Math.Sqrt(1 - x * x);
            if (func.Name == "arcsin")
                return 1.0 / denominator;
            else if (func.Name == "arccos")
                return -1.0 / denominator;
            else
                throw new InvalidOperationException("Неизвестная функция");
        }
    }
}