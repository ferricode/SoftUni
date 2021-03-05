﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        //Problem 1
        //public Citizen(string name, int age)
        //{
        //    Name = name;
        //    Age = age;
        //}

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
          
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Id { get; private set; }
       


    }
}