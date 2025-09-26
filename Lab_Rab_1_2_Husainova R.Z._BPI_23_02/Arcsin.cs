using System;
namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{

    public class Arcsin : Function
    {
        public Arcsin() : base("arcsin") { }

        public override string GetInfo()
        {
            return "arcsin(x)";
        }

        public override string GetInfo(string context)
        {
            if (context == "расчёт")
            {
                return "Вычисление arcsin(x)";
            }
            else if (context == "производная")
            {
                return "Производная arcsin(x) = 1 / sqrt(1 - x²)";
            }
            else
            {
                return base.GetInfo(context);
            }
        }

        public override bool IsValidForFunction(double x) => x >= -1 && x <= 1;
        public override bool IsValidForDerivative(double x) => Math.Abs(x) < 1;

        public override double Calculate(double x)
        {
            if (!IsValidForFunction(x))
                throw new ArgumentOutOfRangeException(nameof(x), "Для arcsin(x): x ∈ [-1; 1]");
            return Math.Asin(x);
        }
    }
}