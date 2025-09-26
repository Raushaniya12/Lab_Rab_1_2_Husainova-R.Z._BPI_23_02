using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public abstract class Function: IFunction //Базовый класс 
    {
        protected readonly string _name;
        protected Function(string name)
        {
            _name = name;
        }
        public string Name => _name;
        public virtual string GetInfo()
        {
            return $"Обратная тригонометрическая функция: {Name}";
        }
        public virtual string GetInfo(string context)
        {
            return $"{GetInfo()} [контекст: {context}]";
        }

        public abstract double Calculate(double x);
        public abstract bool IsValidForFunction(double x);
        public abstract bool IsValidForDerivative(double x);
    }
}
