using System;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public class Arcsin: Function
    {
        public Arcsin() : base("arcsin") { }

        public override bool IsValidForFunction(double x) => x >= -1 && x <= 1;
        public override bool IsValidForDerivative(double x) => Math.Abs(x) < 1;

        public override double Calculate(double x)
        {
            if (!IsValidForFunction(x))
                throw new ArgumentOutOfRangeException(nameof(x), "Для arcsin(x): x должен быть в диапазоне [-1; 1]");
            return Math.Asin(x);
        }
        public override string GetInfo()
        {
            return "arcsin(x)";
        }
    }
}