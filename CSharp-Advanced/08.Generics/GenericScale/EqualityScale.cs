using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T First;
        private T Second;

        public EqualityScale(T first, T second)
        {
            this.First = first;
            this.Second = second;

        }

        public bool AreEqual()
        {
            return first.Equals(second);
        }


    }
}
