using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Box> boxes = new List<Box>();
        

            while (command != "end")
            {
                string[] cmdArgs = command.Split().ToArray();

                string serialNumber = cmdArgs[0];
                string itemName = cmdArgs[1];
                double itemQuantity = double.Parse(cmdArgs[2]);
                double itemPrice = double.Parse(cmdArgs[3]);

                //Item Item = new Item(itemName, itemPrice);
                Box box = new Box();
                box.Item = new Item();

                box.SerialNumber = serialNumber;
                box.Item.Name = itemName;
                box.ItemQuantity = itemQuantity;
                box.Item.Price = itemPrice;

                boxes.Add(box);
                command = Console.ReadLine();
            }
            foreach (var box in boxes)
            {
                box.BoxPrice = box.Item.Price * box.ItemQuantity;
            }

            boxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }


        }
        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public class Box
        {
            public Box()
            {
                Item = new Item();
            }
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public double ItemQuantity { get; set; }
            public double BoxPrice { get; set; }

        }
    }
}
