using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class HonoraryOperator : ArithmeticMethod
    {
        public override double CalculateOperator(List<ArithmeticSign> exercise, int operationIndex)
        {
            List<ArithmeticSign> subExercise = HigherOperatorsSubExercise(exercise.GetRange(operationIndex + 1, exercise.Count - operationIndex - 1), exercise[operationIndex]);
            int subExerciseLength = subExercise.Count;
            double subExerciseResult = calculator.Calculate(subExercise);

            exercise.RemoveRange(operationIndex + 1, subExerciseLength);
            exercise.Insert(operationIndex + 1, new Number(subExerciseResult));

            if ((exercise.Count < 2) || (!(exercise[operationIndex + 1] is Number)))
                throw new Exception("Incorrect input ");
            double operatorResult = Operation(((Number)exercise[operationIndex + 1]).value);
            exercise.RemoveRange(operationIndex, 2);
            exercise.Insert(operationIndex, new Number(operatorResult));

            return calculator.Calculate(exercise, operationIndex);
        }
    }
}
