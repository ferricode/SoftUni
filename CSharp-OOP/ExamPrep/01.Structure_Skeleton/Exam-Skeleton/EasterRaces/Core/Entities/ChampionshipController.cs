using Easterraces.Repositories;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = driverRepository.GetByName(driverName);

            var car = carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));

            }

            driver.AddCar(car);


            carRepository.Remove(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var driver = driverRepository.GetByName(driverName);
            var race = raceRepository.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            }

            race.AddDriver(driver);
            driverRepository.Remove(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            var carExists = carRepository.GetByName(model);
            if (carExists != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            if (type == "Muscle")
            {

                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            var driverExists = driverRepository.GetByName(driverName);
            if (driverExists != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            var driver = new Driver(driverName);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var newRace = new Race(name, laps);
            raceRepository.Add(newRace);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var drivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .ToList();

            //string.Format(OutputMessages.DriverFirstPosition, drivers.First().Name, raceName);
            //drivers.Remove(drivers.First());
            //string.Format(OutputMessages.DriverSecondPosition, drivers.First().Name, raceName);
            //drivers.Remove(drivers.First());
            //string.Format(OutputMessages.DriverThirdPosition, drivers.First().Name, raceName);

            raceRepository.Remove(race);

            return string.Format(OutputMessages.DriverFirstPosition, drivers[0].Name, raceName) + Environment.NewLine +

            string.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, raceName) + Environment.NewLine +

            string.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, raceName);


        }
    }
}
