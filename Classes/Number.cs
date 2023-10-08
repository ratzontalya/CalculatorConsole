using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Number : ArithmeticSign
    {
        private double value;
        public Number(double number) {
            value = number;
        }
        public override double Calculate(List<ArithmeticSign> exercise, int index)
        {
            return value;
        }
    }
}
