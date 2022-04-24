namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var countries = new List<Country>();

            const string root = "Countries";
            var countriesDto = XmlConverter.Deserializer<ImportCountryDto>(xmlString, root);

            foreach (var country in countriesDto)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newCountry = new Country()
                {
                    ArmySize = country.ArmySize,
                    CountryName = country.CountryName
                };

                countries.Add(newCountry);
                sb.AppendLine(string.Format(SuccessfulImportCountry, newCountry.CountryName, newCountry.ArmySize));

            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var manufacturers = new List<Manufacturer>();

            const string root = "Manufacturers";
            var manufacturersDto = XmlConverter.Deserializer<ImportManufacturerDto>(xmlString, root);

            bool isUnique = true;

            foreach (var man in manufacturersDto)
            {
                if (!IsValid(man))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newManufacturer = new Manufacturer()
                {

                    ManufacturerName = man.ManufacturerName,
                    Founded = man.Founded
                };

                if (manufacturers.Any(x => x.ManufacturerName == man.ManufacturerName))
                {
                    isUnique = false;
                    sb.AppendLine(ErrorMessage);
                    continue;
                };
                manufacturers.Add(newManufacturer);

                string[] foundedTokens = newManufacturer.Founded.Split(", ");
                Array.Reverse(foundedTokens);
                string place = foundedTokens[1] + ", " + foundedTokens[0];


                sb.AppendLine(String.Format(SuccessfulImportManufacturer, newManufacturer.ManufacturerName, place));
            }
            if (isUnique)
            {

                context.Manufacturers.AddRange(manufacturers);
                context.SaveChanges();

            };
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var shells = new List<Shell>();

            const string root = "Shells";
            var shellsDto = XmlConverter.Deserializer<ImportShellDto>(xmlString, root);

            foreach (var shell in shellsDto)
            {
                if (!IsValid(shell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newShell = new Shell()
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber
                };

                shells.Add(newShell);
                sb.AppendLine(string.Format(SuccessfulImportShell, newShell.Caliber, newShell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var guns = new List<Gun>();

            var gunsDtos = JsonConvert.DeserializeObject<IEnumerable<ImportGunDto>>(jsonString);


            foreach (var gun in gunsDtos)
            {
                if (!IsValid(gun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //bool hasInvalidType = false;
                //string[] validType = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };

                //if (!validType.Any(t => t == gun.GunType) == false)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    hasInvalidType = true;
                //    continue;

              //  }

                bool hasGunType = Enum.TryParse<GunType>(gun.GunType, true, out GunType gunType);

                if (!hasGunType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newGun = new Gun()
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = gunType,
                    ShellId = gun.ShellId,

                };

                List<CountryGun> countryGuns = new List<CountryGun>();

                foreach (var countryDto in gun.Countries)
                {
                    Country currCountry = context.Countries.FirstOrDefault(c => c.Id == countryDto.Id);

                    CountryGun countryGun = new CountryGun()
                    {
                        Gun = newGun,
                        Country = currCountry
                    };

                    countryGuns.Add(countryGun);

                }

                newGun.CountriesGuns=countryGuns;


                guns.Add(newGun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();


        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
