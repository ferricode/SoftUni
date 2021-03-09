using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    public class Order
    {
        private decimal amount;
        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                CheckAmount(value);
                amount = value;
            }
        }
        public void PlaceOrder(decimal amount)
        {
            CheckAmount(amount);
            Amount -= amount;
        }
        private void CheckAmount(decimal value)
        {
            if (value > 500)
            {
                throw new NotSupportedException("You are not supposed to have large amounts in orders");
            }
            if (value < 0)
            {
                throw new ArgumentException("You can't have negative orders or you don't have enough money");
            }
        }
    }
}
