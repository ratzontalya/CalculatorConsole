using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Calculate(List<ArithmeticSign> exercise, int index = 0)
        {
            double result;
            if (exercise.Count == 0) return 0;
            if ((exercise.Count == 1) && (exercise[0] is Number)) return ((Number) exercise[0]).value;
            if (!(exercise[index] is Number))
            {
                result = exercise[index].CalculateOperator(exercise, index);
            }
            else
            {
                result = Calculate(exercise, index + 1);
            }
            return result;
        }
    }
}
