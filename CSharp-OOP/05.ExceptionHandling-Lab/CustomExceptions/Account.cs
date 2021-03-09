using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    class Account
    {
        public void PlaceOrder(decimal amount)
        {
            try
            {
                Order order = new Order() { Amount = amount };
                order.PlaceOrder(amount);
            }
            catch (Exception ex)
            {

                throw new OrderException("Order was not placed", ex);
            }

        }
    }
}
