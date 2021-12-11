namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var topTheatres = context
                         .Theatres
                         .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                         .ToList()
                         .OrderByDescending(t => t.NumberOfHalls)
                         .ThenBy(t => t.Name)
                         .Select(t => new
                         {
                             Name = t.Name,
                             Halls = t.NumberOfHalls,
                             TotalIncome = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(p => p.Price),
                             Tickets = t.Tickets
                             .OrderByDescending(tic => tic.Price)
                             .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                             .Select(tic => new
                             {
                                 Price = Decimal.Parse(String.Format($"{tic.Price:0.00}")),
                                 RowNumber = tic.RowNumber
                             })
                             .ToList()
                         })
                         .ToList();

            var result = JsonConvert.SerializeObject(topTheatres, Formatting.Indented);

            return result;

        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                 .Plays
                 .Where(p => p.Rating <= rating)
                 .Select(p => new ExportPlaysDto()
                 {
                     Title = p.Title,
                     Duration = p.Duration.ToString("c"),
                     Rating = p.Rating == 0.00 ? "Premier" : p.Rating.ToString(),
                     Genre = p.Genre,
                     Actors = p.Casts
                            .Where(a => a.IsMainCharacter)
                            .Select(a => new ExportActorsDto()
                            {
                                FullName = a.FullName,
                                MainCharacter = $"Plays main character in '{a.Play.Title}'.",

                            })
                            .OrderByDescending(a => a.FullName)
                            .ToArray()
                 })
                 .OrderBy(p => p.Title)
                 .ThenByDescending(p => p.Genre)
                 .ToArray();

            var result = XmlConverter.Serialize(plays, "Plays");

            return result;

        }
    }
}
