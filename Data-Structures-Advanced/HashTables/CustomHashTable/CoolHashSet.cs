using System;
using System.Collections.Generic;
using System.Text;

namespace CustomHashTable
{
    public class CoolHashSet
    {
        public List<string>[] internalArray;
        private int fillCount = 0;
        private int loadFactor;
        public CoolHashSet(int capacity = 8, int loadFactor = 75)
        {
            internalArray = new List<string>[capacity];
            this.loadFactor = loadFactor;
        }
        public void Add(string element)
        {
            Add(element, internalArray);
        }
        private void Add(string element, List<string>[] internalArray, bool isResizing = false)
        {

            int index = Math.Abs(HashFunction(element) % internalArray.Length);

            if (internalArray[index] == null)
            {
                internalArray[index] = new List<string>();
            }

            if (!isResizing && Contains(element, index))
            {
                return;
            }
            internalArray[index].Add(element);

            if (!isResizing)
            {
                fillCount++;
                Resize();
            }
        }

        private void Resize()
        {
            if ((fillCount / (float)internalArray.Length * 100) > loadFactor)
            {
                Console.WriteLine($"Fill count: {fillCount}  Array Length: {internalArray.Length}");
                Console.WriteLine($"Fill rate: {(internalArray.Length / (float)fillCount * 100)} > {loadFactor} loadFactor... resizing");

                List<string>[] resizedArray = new List<string>[internalArray.Length * 2];
                for (int i = 0; i < internalArray.Length; i++)
                {
                    if (internalArray[i] != null)
                    {
                        for (int j = 0; j < internalArray[i].Count; j++)
                        {
                            Add(internalArray[i][j], resizedArray, true);
                        }
                    }
                }
                internalArray = resizedArray;
            }
        }

        public bool Contains(string element)
        {
            int index = Math.Abs(HashFunction(element) % internalArray.Length);
            return Contains(element, index);

        }
        private bool Contains(string element, int index)
        {
            if (internalArray[index] == null)
            {
                return false;
            }

            for (int i = 0; i < internalArray[index].Count; i++)
            {
                if (internalArray[index][i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        private int HashFunction(string element)
        {
            int hash = 7;

            for (int i = 0; i < element.Length; i++)
            {
                hash += hash * 31 + element[i] * 7;
            }

            return hash;
        }
    }
}
