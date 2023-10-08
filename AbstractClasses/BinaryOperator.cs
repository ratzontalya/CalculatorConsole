using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperator : ArithmeticMethod
    {
        public override double Calculate(List<ArithmeticSign> exercise, int operationIndex)
        {
            List<ArithmeticSign> localExercise = new List<ArithmeticSign>(exercise);
            List<ArithmeticSign> subExercise = HigherOperatorsSubExercise(localExercise.GetRange(operationIndex + 1, localExercise.Count - operationIndex - 1), localExercise[operationIndex]);
            int subExerciseLength = subExercise.Count;
            double subExerciseResult = calculator.Calculate(subExercise);

            localExercise.RemoveRange(operationIndex + 1, subExerciseLength);
            localExercise.Insert(operationIndex + 1, new Number(subExerciseResult));

            if ((localExercise.Count < 3) || (!(localExercise[operationIndex - 1] is Number)) || (!(localExercise[operationIndex + 1] is Number)))
                throw new Exception("This operator is a binary operator, you need 2 numbers for it");
            double left = localExercise[operationIndex - 1].Calculate(exercise, operationIndex - 1);
            double right = localExercise[operationIndex + 1].Calculate(exercise, operationIndex + 1);
            double operatorResult = Operation(left, right);
            localExercise.RemoveRange(operationIndex - 1, 3);
            localExercise.Insert(operationIndex - 1, new Number(operatorResult));

            return calculator.Calculate(localExercise, operationIndex);
        }
    }
}
