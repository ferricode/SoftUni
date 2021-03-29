using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with price {this.price}");
            return this.price;

        }
    }
}
