namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var sb = new StringBuilder();
            var prisoners = context
                         .Prisoners
                         .ToList()
                         .Where(p=>ids.Contains(p.Id))
                         .Select(p => new ExportPrisonerDto()
                         {
                             Id = p.Id,
                             Name = p.FullName,
                             CellNumber = p.Cell.CellNumber,

                             Officers = p.PrisonerOfficers.Select(x => new ExportOfficersDto()
                             {
                                 OfficerName = x.Officer.FullName,
                                 Department = x.Officer.Department.Name
                             })
                               .OrderBy(p=>p.OfficerName)
                               .ToList(),
                             
                               TotalOfficerSalary = p.PrisonerOfficers.Sum(o => o.Officer.Salary),
                         })
                          .OrderBy(p => p.Name)
                          .ThenBy(p => p.Id)
                          .ToList();

            var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] pNames = prisonersNames.Split(",");
            var sb = new StringBuilder();
            var prisoners = context
                         .Prisoners
                         .ToList()
                         .Where(p => pNames.Contains(p.FullName))
                         .Select(p => new ExportPrisonersInbox()
                         {
                             Id = p.Id,
                             Name = p.FullName,
                             IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),

                             EncryptedMessages = p.Mails.Select(x => new ExportMessageDto()
                             {
                                 Description = string.Join("", x.Description.Reverse())
                             })
                              .ToList()


                         })
                          .OrderBy(p => p.Name)
                          .ThenBy(p => p.Id)
                          .ToList();

            var result = XmlConverter.Serialize(prisoners, "Prisoners");

            return result;
        }
         
    }
}