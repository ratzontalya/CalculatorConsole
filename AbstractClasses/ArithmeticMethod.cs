using Calculator.AbstractClasses;
using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class ArithmeticMethod : ArithmeticSign
    {
        public Dictionary<int, Type[]> operationsOrder = new Dictionary<int, Type[]>(){
            { 1, new Type[]{typeof(Plus), typeof(Minus) } },
            { 2, new Type[] { typeof(Mult), typeof(Divide)} },
            { 3, new Type[] { typeof(HonoraryMinus)} },
            { 4, new Type[] { typeof(RoundParentheses) } }
        };
        protected abstract double Operation(params double[] numbers);
        protected List<ArithmeticSign> HigherOperatorsSubExercise(List<ArithmeticSign> exercise, ArithmeticSign currentOperation)
        {
            int currentOperationLevel = operationsOrder.FirstOrDefault(keyValue => keyValue.Value.Contains(currentOperation.GetType())).Key;
            Type[] lowerOperations = operationsOrder.Keys.ToList().FindAll(key => key <= currentOperationLevel)
                                                                   .Select(key => operationsOrder[key])
                                                                   .SelectMany(value => value).ToArray();
            int openBrackets = 0;
            bool isFinished = false;
            List<ArithmeticSign> subExercise = exercise.Where((arithmeticSign) =>
            {
                bool addCharacter = !isFinished;
                if (!(arithmeticSign is Number))
                {
                    IActionFactory actionFactory = new ActionFactory();
                    addCharacter = false;
                    if ((openBrackets == 0) && (lowerOperations.Contains(arithmeticSign.GetType())))
                        isFinished = true;
                    if ((arithmeticSign is Parentheses) && (((Parentheses)arithmeticSign).isOpen)) openBrackets += 1;
                    else if ((arithmeticSign is Parentheses) && (!((Parentheses)arithmeticSign).isOpen)) openBrackets -= 1;
                    if (!isFinished)
                        addCharacter = true;
                }
                return addCharacter;
            }).ToList();
            return subExercise;
        }
    }
}
