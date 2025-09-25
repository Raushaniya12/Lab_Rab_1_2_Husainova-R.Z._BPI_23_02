using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    internal class Arccos:Function
    {
        public double Calculate(double x)
        {
            if (x < -1 || x > 1)
                throw new ArgumentException("Аргумент x должен быть в диапазоне [-1, 1]");
            return Math.Acos(x);
        }
    }
}
