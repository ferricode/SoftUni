namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var plays = new List<Play>();
            var sb = new StringBuilder();

            var playsDtos = XmlConverter.Deserializer<ImportPlaysDto>(xmlString, "Plays");

            foreach (var playDto in playsDtos)
            {

                bool isValidGenre = Enum.TryParse(typeof(Genre), playDto.Genre, out var playGenre);



                bool isValidDuration = TimeSpan.TryParseExact(playDto.Duration, "c",
                    CultureInfo.InvariantCulture, TimeSpanStyles.None, out var validDuration);

                if (!IsValid(playDto) ||
                      !isValidGenre ||
                      !isValidDuration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                if (TimeSpan.Parse(playDto.Duration).Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = validDuration, 
                    Rating = (float)playDto.Rating,
                    Genre = (Genre)playGenre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter

                };

                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));

            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            List<Cast> casts = new List<Cast>();
            const string root = "Casts";

            var castDtos = XmlConverter.Deserializer<ImportCastsDto>(xmlString, root);

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber, 
                    PlayId=castDto.PlayId
                };
                string character = cast.IsMainCharacter ? "main" : "lesser";

                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, character));
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            List<Theatre> theatresTickets = new List<Theatre>();


            var theatresTicketsDto = JsonConvert.DeserializeObject<List<ImportTheatreDto>>(jsonString);

            foreach (var theatreT in theatresTicketsDto)
            {
                if (!IsValid(theatreT))
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                    List < Ticket > ticketsInTheatre = new List<Ticket>();

                foreach (var ticket in theatreT.Tickets )
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var ticketToAdd = new Ticket()
                    {
                        RowNumber = ticket.RowNumber,
                        Price = ticket.Price,
                        PlayId = ticket.PlayId
                    };
                    ticketsInTheatre.Add(ticketToAdd);
                }
               
                var theatre = new Theatre()
                {

                    Name = theatreT.Name,
                    NumberOfHalls = theatreT.NumberOfHalls,
                    Director = theatreT.Director,
                    Tickets = ticketsInTheatre,
                };
                


                theatresTickets.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));

            }
            context.Theatres.AddRange(theatresTickets);
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
