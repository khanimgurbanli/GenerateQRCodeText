using Newtonsoft.Json.Linq;
using QrCodeReaderTextFormat.Data;
using QrCodeReaderTextFormat.Models;

namespace QrCodeReaderTextFormat
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Db intance
            AppDbContext db = new AppDbContext();

            // For requset url
            HttpClient client = new HttpClient();

            string resonponse = client.GetStringAsync("https://randomuser.me/api?results=50").Result;

            // Get data
            var result = JObject.Parse(resonponse);

            // Add db
            for (int i = 0; i < result["results"].ToArray().Length; i++)
                db.VCards.Add(new VCard
                {
                    Firstname = result["results"][i]["name"]["first"].ToString(),
                    Surname = result["results"][i]["name"]["last"].ToString(),
                    Email = result["results"][i]["email"].ToString(),
                    Country = result["results"][i]["location"]["country"].ToString(),
                    City = result["results"][i]["location"]["city"].ToString(),
                    Phone = result["results"][i]["phone"].ToString(),
                });
            var check = db.SaveChanges() > 0;

            // Show message about proccess

            if (check)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Succesfully added records to db");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops :( Try again");
                Console.ResetColor();
            }

            // Read records
            var getAll = db.VCards.ToList();
            foreach (var record in getAll) System.Console.WriteLine(record);
        }
    }
}
