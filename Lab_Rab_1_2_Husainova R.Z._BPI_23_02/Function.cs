using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public abstract class Function //Базовый класс 
    {
        public abstract string Name { get; }
        public abstract double Calculate(double x);
        public abstract bool IsValidForDerivative(double x);
        public abstract bool IsValidForFunction(double x);
    }
}
