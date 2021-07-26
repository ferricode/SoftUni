using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementList
{
    public class CoolList<T>
    {
        private T[] array;
        private int index = 0;

        public CoolList(int initialCapacity=4) 
        {
            array = new T[initialCapacity];
        }
        public int Count { get { return index; } }
        public int InternalArrayCount { get { return array.Length; } }
        public void Add(T element)
        {
            if (index==array.Length)
            {
                array=DoubleArrraySize(array);
            }
            array[index] = element;
            index++;
            
        }
        public T this[int i]
        {
            get 
            {
                return array[i];
            }
            set 
            {
                array[i] = value;
            }
        }

        private T[] DoubleArrraySize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
           return newArray;
        }
    }
}
