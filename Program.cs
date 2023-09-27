﻿using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string shouldContinue = "y";
                string toContinue = shouldContinue;
                while (toContinue == shouldContinue)
                {
                    Console.WriteLine("Please enter:");
                    string exercise = Console.ReadLine();

                    Calculator calculator = new Calculator();
                    Converter converter = new Converter();
                    List<ArithmeticSign> convertedExercise = converter.ConvertExerciseToList(exercise);
                    IValidator validator = new Validator();
                    validator.ValidateExercise(convertedExercise);
                    double result = calculator.Calculate(convertedExercise);
                    Console.WriteLine(result);

                    Console.WriteLine("Do you want to continue?y/n");
                    toContinue = Console.ReadLine();
                }
            } catch(Exception error)
            {
                Console.WriteLine(error.Message);
                Console.ReadKey();
            }
        }
    }
}
