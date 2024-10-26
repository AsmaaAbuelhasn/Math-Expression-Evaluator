using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.TrainingApps.MathExpressionEvaluator
{
    public static class App
    {
        public static void Run(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please Enter your Mathimatical Expression");
                string expression = Console.ReadLine();
                var exp = ExpressionParse.expressionParser(expression);


                Console.WriteLine($"Left side = {exp.leftSideExpresion}  , opeation = {exp.operationExpresion},   right side = {exp.rightSideExpresion} ");
                Console.WriteLine($"{expression} = {EvaluateExpression(exp)}");
            }
        }

        private static object EvaluateExpression(ExperssionIntialized exp)
        {

            if (exp.operationExpresion == Operation.Addition)
                return exp.leftSideExpresion + exp.rightSideExpresion;
            else if (exp.operationExpresion == Operation.Subtract)
                return exp.leftSideExpresion - exp.rightSideExpresion;
            else if (exp.operationExpresion == Operation.Multiblication)
                return exp.leftSideExpresion * exp.rightSideExpresion;
            else if (exp.operationExpresion == Operation.Divide)
                return exp.leftSideExpresion / exp.rightSideExpresion;
            else if (exp.operationExpresion == Operation.Power)
                return Math.Pow(exp.leftSideExpresion, exp.rightSideExpresion);
            else if (exp.operationExpresion == Operation.Modules)
                return exp.leftSideExpresion % exp.rightSideExpresion;
            else if (exp.operationExpresion == Operation.Sin)
                return Math.Sin(exp.rightSideExpresion);
            else if (exp.operationExpresion == Operation.Cos)
                return Math.Cos(exp.rightSideExpresion);
            else if (exp.operationExpresion == Operation.Tan)
                return Math.Tan(exp.rightSideExpresion);
            else
               return 0;
        }
    }
}
