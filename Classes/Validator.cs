using Calculator.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Validator : IValidator
    {
        private IActionFactory actionFactory = new ActionFactory();
        public void ValidateBrackets(List<ArithmeticSign> exercise)
        {
            int validateBrackets = 0;
            foreach (ArithmeticSign arithmeticSign in exercise)
            {
                if (!(arithmeticSign is Number))
                {
                    validateBrackets += arithmeticSign is Parentheses && ((Parentheses)arithmeticSign).isOpen ? 1 : 0;
                    validateBrackets -= arithmeticSign is Parentheses && !((Parentheses)arithmeticSign).isOpen ? 1 : 0;
                    if (validateBrackets == -1) throw new Exception("Please use the brackets correctly.");
                }
            }
            if (validateBrackets != 0) throw new Exception("Please use the brackets correctly.");
        }
        public void ValidateSignsAfterBrackets(List<ArithmeticSign> exercise)
        {
            int index = 0;
            foreach (ArithmeticSign sign in exercise)
            {
                if((index > 0) && (sign is Parentheses) && (((Parentheses)sign).isOpen) && exercise[index -1] is Number)
                    throw new Exception("Please write arithmetic sign before and after brackets");
                if ((index < exercise.Count - 1) && (sign is Parentheses) && (!((Parentheses)sign).isOpen) && exercise[index + 1] is Number)
                    throw new Exception("Please write arithmetic sign before and after brackets");
                index += 1;
            }
        }
        public void ValidateExercise(List<ArithmeticSign> exercise)
        {
            ValidateBrackets(exercise);
            ValidateSignsAfterBrackets(exercise);
        }
    }
}
