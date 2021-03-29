using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CustomSerialization
{
    class Serializer
    {
        public string ToJson(object obj)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\n");
            Type type = obj.GetType();

            foreach (var property in type.GetProperties((BindingFlags)60))
            {
                string name = property.Name;
                object
            }
        }
    }
}
