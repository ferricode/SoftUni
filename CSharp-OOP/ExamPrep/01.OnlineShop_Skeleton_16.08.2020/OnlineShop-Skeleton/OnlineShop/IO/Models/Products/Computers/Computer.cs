using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {

            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance => base.OverallPerformance + CalculateOverallPerformance();
        public override decimal Price => base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        private double CalculateOverallPerformance()
        {
            double averageComponentsPerformance = 0;

            if (components.Count > 0)
            {
                averageComponentsPerformance = components.Average(c => c.OverallPerformance);
            }

            return averageComponentsPerformance;
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList();

        public void AddComponent(IComponent component)
        {

            if (components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name } already exists in {GetType().Name} with Id {Id}.");
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }
            var componentToRemove = components.FirstOrDefault(c => c.GetType().Name == componentType);

            components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {GetType().Name} with Id {Id}.");
            }
            var peripheralToRemove = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }
        public override string ToString()
        {
            double peripheralsAvg = Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : 0;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var item in components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripheralsAvg:f2}):");
            foreach (var item in peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
