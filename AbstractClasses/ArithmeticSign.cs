using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class ArithmeticSign
    {
        protected Calculator calculator = new Calculator();
        public abstract double Calculate(List<ArithmeticSign> exercise, int index);
    }
}
