
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var sb = new StringBuilder();
            var shells = context
                        .Shells
                        .Where(x => x.ShellWeight > shellWeight)
                        .ToList()
                        .Select(x => new ShellDto()
                        {
                            ShellWeight = x.ShellWeight,
                            Caliber = x.Caliber,
                            Guns = x.Guns.Select(g => new GunDto()
                            {
                                GunType = g.GunType.ToString(),
                                GunWeight = g.GunWeight,
                                BarrelLength = g.BarrelLength,
                                Range = g.Range > 3000 ? "Long-range" : "Regular range"
                            })
                            .Where(g => g.GunType == "AntiAircraftGun ")
                            .OrderByDescending(g => g.GunWeight)
                            .ToArray()

                        })
                        .OrderBy(s => s.ShellWeight)
                        .ToArray();
            var json = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return json;
        }



        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
