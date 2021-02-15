﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _5.GenericCountMethodStrings
{
    public class Box<T> : IComparable
        where T:IComparable
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }

        public int CompareTo(object obj)
        {
            Box<T> box=obj as Box<T>;
            int compare = Value.CompareTo(box.Value);
            return compare;
        }

        public override string ToString()
        {

            Type valueType = Value.GetType();
            string valueTypeFullName = valueType.FullName;

            return $"{valueTypeFullName}: {Value}";

        }
    }
}
