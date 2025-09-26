using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public interface IFunction
    {
        string Name { get; }
        double Calculate(double x);
        bool IsValidForFunction(double x);
        bool IsValidForDerivative(double x);
    }
}

