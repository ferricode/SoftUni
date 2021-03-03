using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MutableObjects
{
    public class MutableList
    {
        private List<string> studentNames;

        public MutableList(string[] initialStudentNames)
        {
            studentNames = initialStudentNames.ToList();
        }

        // public List<string> StudentNames { get=>studentNames;  } Продължава да подлежи на външни промени.

        public IReadOnlyList<string> StudentNames { get => studentNames.AsReadOnly(); } //Вече не поздлежи на външни промени.
    }
}
