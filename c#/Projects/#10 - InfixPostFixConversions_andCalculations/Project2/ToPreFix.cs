namespace Project2
{
    public class ToPreFix
    {


        //method convets infix expression to a prefix
        public string ToPreFixConverter(string InfixExpr)
        {
            //checking if the infix is null or empty
            if (string.IsNullOrEmpty(InfixExpr))
            {
                //return an eempty string if the infix expression is null
                return string.Empty;
            }

            //initialze an empty strig to strore the prefix expression
            string preFixExpr = "";

            //initialize a string to store the oprators
            Stack<char> operatorStack = new Stack<char>();


            //loop through each char in the infix form right to left
            for (int i = InfixExpr.Length - 1; i >= 0; i--)
            {
                //get the current chars
                char c = InfixExpr[i];

                //if the current char is a digit, add it to the prefix expression
                if (Char.IsDigit(c))
                {
                    preFixExpr = c + preFixExpr;
                }
                //if the current char is a closing parenthis, or a mulpli/divion operator, push it onto the operator stack
                else if (c == ')' || c == '*' || c == '/')
                {
                    operatorStack.Push(c);
                }
                //if the current char is an add/sub operator 
                else if (c == '+' || c == '-')
                {
                    //pop operraotr from the operator stack and add them to the prefix expression until the top of the stack is not a multi/divion operator
                    while (operatorStack.Count > 0 && (operatorStack.Peek() == '*' || operatorStack.Peek() == '/'))
                    {
                        preFixExpr = operatorStack.Pop() + preFixExpr;
                    }
                    //push to stack
                    operatorStack.Push(c);
                }
                // If char is a (
                else if (c == '(')
                {
                    //pop from stack and add to the prefix expression until )
                    while (operatorStack.Count > 0 && operatorStack.Peek() != ')')
                    {
                        preFixExpr = operatorStack.Pop() + preFixExpr;
                    }
                    //pop ) from the operator stack
                    if (operatorStack.Count > 0 && operatorStack.Peek() == ')')
                    {
                        operatorStack.Pop();
                    }
                }
            }

            //pop remainng ops from the operator stack and add them to prefix expression
            while (operatorStack.Count > 0)
            {
                preFixExpr = operatorStack.Pop() + preFixExpr;
            }

            // return string prefix
            return preFixExpr;
        }
    }
}