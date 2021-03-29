using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSerialization
{
    class Player
    {
        public int ID { get; set; }

        public string  Name { get; set; }

        public int Age { get; set; }

        public Score Score { get; set; }

        public int [] Games { get; set; }
    }
}
