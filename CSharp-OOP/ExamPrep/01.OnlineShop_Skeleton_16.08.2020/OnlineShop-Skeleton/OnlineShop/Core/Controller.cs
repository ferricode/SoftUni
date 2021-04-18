using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            ValidateExistingComputerId(computerId);

            IComponent component = null;

            switch (componentType)
            {
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;

            }
            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddComponent(component);

            components.Add(component);


            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {

            if (!Enum.IsDefined(typeof(ComputerType), 1) && !Enum.IsDefined(typeof(ComputerType), 2))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ValidateExistingComputerId(computerId);

            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }
            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddPeripheral(peripheral);

            peripherals.Add(peripheral);


            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var computerToRemove = computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);

            if (computerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computerToRemove);

            return computerToRemove.ToString();

        }

        public string BuyComputer(int id)
        {
            ValidateExistingComputerId(id);

            var itemToRemove = computers.SingleOrDefault(c => c.Id == id);
            computers.Remove(itemToRemove);

            return itemToRemove.ToString();
        }

        public string GetComputerData(int id)
        {
            ValidateExistingComputerId(id);

            var computer = computers.FirstOrDefault(c => c.Id==id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ValidateExistingComputerId(computerId);

            var componentToRemove = components.FirstOrDefault(p => p.GetType().Name == componentType);

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.RemoveComponent(componentType);

            components.Remove(componentToRemove);
            return string.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ValidateExistingComputerId(computerId);

            var peripheralToRemove = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.RemovePeripheral(peripheralType);


            peripherals.Remove(peripheralToRemove);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
        }
        private void ValidateExistingComputerId(int id)
        {
            var expectedId = computers.FirstOrDefault(c => c.Id == id);

            if (expectedId == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}

