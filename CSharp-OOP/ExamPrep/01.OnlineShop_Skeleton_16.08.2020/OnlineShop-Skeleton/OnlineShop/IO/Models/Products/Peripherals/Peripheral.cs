using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product,IPeripheral
    {
       
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectonType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectonType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Connection Type: {this.ConnectionType}";
        }
    }
}
