 using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    class OrderException:Exception
    {
        public OrderException(string message, Exception innerException=null)
            :base(message, innerException)
        {
        
        }

    }
}
