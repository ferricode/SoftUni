using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonDemo
{
   public  class Person
    {
       // [JsonProperty("names")]
        public Name Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        
        //[JsonIgnore]
        public int Age { get; set; }

    }
}
