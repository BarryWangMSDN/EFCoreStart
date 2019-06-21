using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SODbLoadV2
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
            HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.2/questions?fromdate=1560902400&todate=1560988800&order=desc&sort=creation&tagged=uwp&site=stackoverflow&filter=!)slodkq_7Zpv(2HiW0R1");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            RootObject rootnodes = JsonConvert.DeserializeObject<RootObject>(responseBody);
            List<Item> items = new List<Item>();
            items = rootnodes.items;




            //  DataTable testtable=jsonhelper.ToDataTable<Item>(items);
            //var msg = await stringTask;
            //Console.Write(msg);
            //SqlException: Cannot insert explicit value for identity column in table 'Owners' when IDENTITY_INSERT is set to OFF.
        }


        static void Main(string[] args)
        {
            ProcessRepositories().Wait();

        }
    }
}
