using Calculator.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IValidator
    {
        void ValidateBrackets(List<ArithmeticSign> exercise);
        void ValidateSignsAfterBrackets(List<ArithmeticSign> exercise);
        void ValidateExercise(List<ArithmeticSign> exercise);
    }
}
