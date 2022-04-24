namespace AsyncDemo
{
    public class Program
    {
        public static async Task  Main()
        {
            
            string url = "https://softuni.bg";

            using (HttpClient client = new HttpClient())
            { 
            var result = client.GetAsync(url).Result;

                if (result.IsSuccessStatusCode)
                {
                    string content=await result.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }
       
    }
}
