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
        void ValidateBrackets(string exercise);
        void ValidateSignsType(string exercise);
        void ValidateSignsAfterBrackets(string exercise);
        void ValidateExercise(string exercise);
    }
}
