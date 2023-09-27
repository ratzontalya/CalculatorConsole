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
        //public void ValidateSignsAfterBrackets(string exercise)
        //{
        //    if (Regex.IsMatch(exercise, @"^[0-9]+[(]+|[)]+[0-9]+$"))
        //        throw new Exception("Please write arithmetic sign before and after brackets");
        //}
        public void ValidateExercise(List<ArithmeticSign> exercise)
        {
            ValidateBrackets(exercise);
            //ValidateSignsAfterBrackets(exercise);
        }
    }
}
