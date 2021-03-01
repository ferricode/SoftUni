
using System.Collections.Generic;


namespace CustomStack
{
    public class StackOfStrings<T> : Stack<T>
    {
        public bool IsEmpty()
        {

            return this.Count == 0;
        }
        public void AddRange(IEnumerable<T>values)
        {
            foreach (var value in values)
            {
                this.Push(value);
            }
        }

    }
}
