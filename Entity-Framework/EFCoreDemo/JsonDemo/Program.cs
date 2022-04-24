using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JsonDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Name = new Name()
                {
                    FirstName = "Фериде",
                    LastName = "Джебеджи"
                },
                DateOfBirth = new DateTime(1998, 11, 11),
                Age = 23
            };

            var serializer = new XmlSerializer(typeof(Person));

            //string xml = File.ReadAllText("person.xml");
            //Person person = (Person)serializer.Deserialize(new StringReader(xml));

            using (var stream = new StreamWriter("person.xml"))
            {
                serializer.Serialize(stream, person);
            }

            //with usings:
            //using System.Text.Json;
            //using System.Text.Json.Serialization;

            //string serializedPerson = JsonSerializer.Serialize(person);

            //await File.WriteAllTextAsync("person.json", serializedPerson);

            //Person anotherPerson = JsonSerializer.Deserialize<Person>(serializedPerson);
            //Console.WriteLine(serializedPerson);


            // Json
            //DefaultContractResolver contractResolver = new DefaultContractResolver()
            //{
            //    //NamingStrategy = new KebabCaseNamingStrategy()
            //    NamingStrategy = new SnakeCaseNamingStrategy()

            //};

            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    ContractResolver = contractResolver,
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore,
            //    DateFormatString = "yyyy-MM-dd"
            //};



            //Json with Newtonsoft
            //string serializedPerson = JsonConvert.SerializeObject(person, settings);

            ////await File.WriteAllTextAsync("person.json", serializedPerson);

            ////Person anotherPerson = JsonConvert.DeserializeObject<Person>(serializedPerson);
            ////Console.WriteLine(serializedPerson);

            //JObject json = JObject.Parse(serializedPerson);
            //string fullName = json["name"]
            //    .Children()
            //    .Select(t => string.Format("{0} {1}", t["first_name"], t["last_name"]))
            //    .FirstOrDefault();

            //Console.WriteLine(fullName);

        }
    }
}
