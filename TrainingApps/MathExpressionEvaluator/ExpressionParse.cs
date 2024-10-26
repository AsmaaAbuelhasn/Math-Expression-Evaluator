using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.TrainingApps.MathExpressionEvaluator
{
    internal static class ExpressionParse
    {
        public const string MathSymbole = "^*_+%/";
        public static ExperssionIntialized expressionParser(String expression)
        {

            bool leftSideInthalized = false;
            string token = "";
            ExperssionIntialized expr= new ExperssionIntialized();

            for(int i=0; i< expression.Length; i++)
            {
                var currentChar = expression[i];

                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if(i==expression.Length-1 & leftSideInthalized)
                    {
                        expr.rightSideExpresion = double.Parse(token);
                        break;
                    }
                }
                else if (MathSymbole.Contains(currentChar))
                {
                    if (!leftSideInthalized)
                    {
                        expr.leftSideExpresion = double.Parse(token);
                        leftSideInthalized = true;
                    }
             
                    expr.operationExpresion = parserMathOperation(currentChar.ToString());
                    token = "";
                }
                else if (currentChar=='-' &&i>0)
                {
                    if (expr.operationExpresion == Operation.None)
                    {
                        expr.operationExpresion = Operation.Subtract;
                        if (!leftSideInthalized)
                        {
                            expr.leftSideExpresion = double.Parse(token);
                            leftSideInthalized = true;
                        }
                        token = "";
                    }
                    else 
                        token+= currentChar;

                }
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    leftSideInthalized = true;
                }
                else if(currentChar==' ')
                {
                    if (!leftSideInthalized)
                    {
                        expr.leftSideExpresion = double.Parse(token);
                        leftSideInthalized= true;
                        token = "";
                    }
                    else if (expr.operationExpresion == Operation.None)
                    {
                        expr.operationExpresion=parserMathOperation(token);
                        token = "";
                    }
                }
                else
                    { token+= currentChar; }
            }
            return expr;
        }

        private static Operation parserMathOperation(string token)
        {
            switch (token)
            {
                case "+":
                    return Operation.Addition;
                    break;
                
                case "*":
                    return Operation.Multiblication;
                    break;
                case "/":
                    return Operation.Divide;
                    break;
                case "%":
                    return Operation.Modules;
                    break;
                case "^":
                case "pow":
                    return Operation.Power;
                    break;
                case "sin":
                    return Operation.Sin;
                    break;
                case "Cos":
                    return Operation.Cos;
                    break;
                case "tan":
                    return Operation.Tan;
                    break;
                default:
                    return Operation.None;
                    break;
            }


        }
    }
}
