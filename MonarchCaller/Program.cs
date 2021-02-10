using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MonarchCaller
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:44357/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/text"));
            var response = await client.GetAsync("api/Monarchs/GetLongestRuledHouse");
            var contetnt =  response.Content.ReadAsStringAsync();
            Console.WriteLine($"GetLongestRuledHouse -> result {contetnt}");
        }
    }
}
