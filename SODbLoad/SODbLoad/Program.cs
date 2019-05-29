using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SODbLoad
{
    class Program
    {
       
        private static async Task ProcessRepositories()
        {
            var handler = new SocketsHttpHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.2/questions?fromdate=1556409600&todate=1556496000&order=desc&sort=activity&tagged=uwp&site=stackoverflow");
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            RootObject rootnodes= JsonConvert.DeserializeObject<RootObject>(responseBody);
            List<Item> items = new List<Item>();
            items = rootnodes.items;

            //var msg = await stringTask;
            //Console.Write(msg);
        }

        static void Main(string[] args)
        {
            ProcessRepositories().Wait();
            // https://api.stackexchange.com/2.2/questions?fromdate=1554076800&todate=1556582400&order=desc&sort=activity&tagged=uwp&site=stackoverflow
        }


    

    }
}
