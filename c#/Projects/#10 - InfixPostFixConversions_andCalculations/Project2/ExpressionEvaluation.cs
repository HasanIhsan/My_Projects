using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class ExpressionEvaluation
    {
        public static double postfixEvaluate(this string expression)
        {
            // Create a stack of expressions
            Stack<Expression> stack = new Stack<Expression>();

            // Loop through each character of the expression
            foreach (char ch in expression)
            {
                // If the character is a digit, push a constant expression with that value onto the stack
                if (char.IsDigit(ch))
                {
                    stack.Push(Expression.Constant(double.Parse(ch.ToString())));
                }
                // If the character is an operator, pop the last two expressions from the stack and create a new expression using the operator
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();

                    switch (ch)
                    {
                        // Create an expression to add the left and right expressions
                        case '+':
                            stack.Push(Expression.Add(left, right));
                            break;
                        // Create an expression to subtract the right expression from the left expression
                        case '-':
                            stack.Push(Expression.Subtract(left, right));
                            break;
                        // Create an expression to multiply the left and right expressions
                        case '*':
                            stack.Push(Expression.Multiply(left, right));
                            break;
                        // Create an expression to divide the left expression by the right expression
                        case '/':
                            stack.Push(Expression.Divide(left, right));
                            break;
                    }
                }
            }

            // Pop the final expression from the stack and compile it into a lambda expression,
            // which can then be executed to get the final result

            // The result should be the final expression in the stack
            Expression finalExpression = stack.Pop();

            // Compile and evaluate the expression
            Func<double> compiledExpression = Expression.Lambda<Func<double>>(finalExpression).Compile();

            return compiledExpression();
        }


        public static double PrefixEvaluate(this string expression)
        {
            char[] exprArr = expression.ToCharArray();
            Stack<Expression> stack = new Stack<Expression>();

            for (int i = exprArr.Length - 1; i >= 0; i--)
            {
                char c = exprArr[i];
                if (Char.IsDigit(c))
                {
                    // If the character is a digit, create an expression to represent it
                    stack.Push(Expression.Constant((double)(c - '0')));
                }
                else
                {
                    // If the character is an operator, pop two expressions from the stack
                    Expression operand1 = stack.Pop();
                    Expression operand2 = stack.Pop();

                    // Create a binary expression representing the operator and operands
                    switch (c)
                    {
                        case '+':
                            stack.Push(Expression.Add(operand1, operand2));
                            break;
                        case '-':
                            stack.Push(Expression.Subtract(operand1, operand2));
                            break;
                        case '*':
                            stack.Push(Expression.Multiply(operand1, operand2));
                            break;
                        case '/':
                            stack.Push(Expression.Divide(operand1, operand2));
                            break;
                        default:
                            throw new ArgumentException("Invalid character in expression: " + c);
                    }
                }
            }

            // The result should be the final expression in the stack
            Expression finalExpression = stack.Pop();

           
            // Compile and evaluate the expression
            Func<double> compiledExpression = Expression.Lambda<Func<double>>(finalExpression).Compile();
            return compiledExpression();
        }
    }
}
