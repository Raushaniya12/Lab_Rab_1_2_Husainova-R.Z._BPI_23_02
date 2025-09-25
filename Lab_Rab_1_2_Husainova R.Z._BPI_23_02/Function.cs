using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public abstract class Function //Базовый класс
    {
        public abstract double Calculate(double x);
        public abstract double CalculateDerivative(double x);
        public abstract string GetName();
    }
}
