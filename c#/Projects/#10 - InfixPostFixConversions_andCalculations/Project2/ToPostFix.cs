namespace Project2
{
    public class ToPostFix
    {

        //convert the infix to post fix 
        //this is like the toprefix with a fre modifacations 
        public string ToPostFixConverter(string InfixExpr)
        {
            // check if string is empty or null
            if (string.IsNullOrEmpty(InfixExpr))
            {
                // return if string is empty
                //now that i thnk about it this may never be callde
                return string.Empty;
            }
             
            //initialize an empty string to sstore the postfix exp
            string postFixExpr = "";
             
            //initialize a string to store operators
            Stack<char> operatorStack = new Stack<char>();
             
            //loop through each character in the infix expresssion from left to right
            for (int i = 0; i < InfixExpr.Length; i++)
            { 
                //get the current char
                char c = InfixExpr[i];
                 
                //if the current char is a digit, add it to the postfix exp
                if (Char.IsDigit(c))
                {
                    postFixExpr += c;
                } 
                //else if the current char is a (, pust it onto the opstack
                else if (c == '(')
                {
                    operatorStack.Push(c);
                } 
                //else if the current char is a )
                else if (c == ')')
                { 
                    //pop ops from the operator stack and add them to the poist fix expression unitl (
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        postFixExpr += operatorStack.Pop();
                    } 

                    //pop the ( from the op stack
                    if (operatorStack.Count > 0 && operatorStack.Peek() == '(')
                    {
                        operatorStack.Pop();
                    }
                } 

                //if the curent char is an op
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    //pop the op from the operator stack and add them to the psotfix expression until an operator with a lower or equal precedience 
                    //aka the condition of being considered more important than someone or something else; priority in importance, order, or rank.(googleed it)
                    while (operatorStack.Count > 0 && GetPrecedence(operatorStack.Peek()) >= GetPrecedence(c))
                    {
                        postFixExpr += operatorStack.Pop();
                    }

                    //push to stack
                    operatorStack.Push(c);
                }
            }

        
            //pop remaining ops from the stak and add them to the postfix exp
            while (operatorStack.Count > 0)
            {
                postFixExpr += operatorStack.Pop();
            }

            // return postfix exp
            return postFixExpr;
        }
 
        
        //helper method to get the precedience of an op
        private int GetPrecedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
    }
}