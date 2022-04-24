namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> open = new Stack<char>();
        

            bool isValid = true;

            if (parentheses.Length == 0 || parentheses.Length % 2 != 0)
            {
                return false;
            }
            foreach (var item in parentheses)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    open.Push(item);
                }
                else
                {
                    bool isFirstIsValid = item == ')' && open.Pop() == '(';
                    bool isSecondIsValid = item == '}' && open.Pop() == '{';
                    bool isThirsIsValid = item == ']' && open.Pop() == '[';

                    if (!(isFirstIsValid || isSecondIsValid || isThirsIsValid))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
