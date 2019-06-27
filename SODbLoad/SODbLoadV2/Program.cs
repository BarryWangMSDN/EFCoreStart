using Microsoft.EntityFrameworkCore;
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
            //var handler = new SocketsHttpHandler
            //{
            //    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            //};
            //var client = new HttpClient(handler);
            //client.DefaultRequestHeaders.Accept.Clear();
            //HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.2/questions?fromdate=1560902400&todate=1560988800&order=desc&sort=creation&tagged=uwp&site=stackoverflow&filter=!)slodkq_7Zpv(2HiW0R1");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //RootObject rootnodes = JsonConvert.DeserializeObject<RootObject>(responseBody);
            //List<Item> items = new List<Item>();
            //items = rootnodes.items;

            //using (var context = new BasicModelContext())
            //{
            //    foreach (Item item in items)
            //    {
            //        context.Items.Add(item);

            //    }
            //    context.SaveChanges();
            //}
            DateTime datefrom = new DateTime(2019, 6, 1);
            DateTime dateto = new DateTime(2019, 6, 30);
            var finalitems = await getquestions(datefrom, dateto, "desc", "uwp", "!)slodkq_7Zpv(2HiW0R1");
            using (var context = new BasicModelContext())
            {
                foreach (Item item in finalitems)
                {
                    if (item.comment_count > 0)
                    {
                        foreach (Comment comment in item.comments)
                        {
                            context.Comments.Add(comment);                        
                        }
                    }
                    if(item.answer_count>0)
                    {
                        foreach(Answer answer in item.answers)
                        {
                            context.Answers.Add(answer);
                          
                        }
                    }
                    context.Owners.Add(item.owner);     
                    context.Items.Add(item);                   
                }     
                context.SaveChanges();

                //DataTable testtable=jsonhelper.ToDataTable<Item>(items);
                //var msg = await stringTask;
                //Console.Write(msg);
                //SqlException: Cannot insert explicit value for identity column in table 'Owners' when IDENTITY_INSERT is set to OFF.
                //Problem: Actually EF cannot understand duplicate owners with the same id 
            }
        }

        public static async Task<List<Item>> getquestions(DateTime fromdate,DateTime todate,string order,string taggged,string filter)
        {
            List<Item> myitems = new List<Item>();
            int i = 1;
            DateTime utcTime1= DateTime.SpecifyKind(fromdate, DateTimeKind.Utc);
            DateTimeOffset utcTime2 = utcTime1;
            var unixtimefrom = utcTime2.ToUnixTimeSeconds();

            DateTime utcTime3 = DateTime.SpecifyKind(todate, DateTimeKind.Utc);
            DateTimeOffset utcTime4 = utcTime3;
            var unixtimeto = utcTime4.ToUnixTimeSeconds();

            string requestUri = "https://api.stackexchange.com/2.2/questions?" + "fromdate=" + unixtimefrom.ToString() + "&todate=" + unixtimeto.ToString()
                +"&order="+order+"&sort=creation"+ "&tagged="+taggged+ "&site=stackoverflow&pagesize=100&filter="+filter;

            var handler = new SocketsHttpHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            RootObject rootnodes = JsonConvert.DeserializeObject<RootObject>(responseBody);
            myitems = rootnodes.items;
            Console.WriteLine("100 items added!");


            while (rootnodes.has_more==true)
            {
                ++i;
                response = await client.GetAsync(requestUri + "&page=" + i.ToString());
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                rootnodes = JsonConvert.DeserializeObject<RootObject>(responseBody);
                myitems.AddRange(rootnodes.items);
                Console.WriteLine("100 items added!");
                if (rootnodes.has_more == false)
                    Console.WriteLine("loading finished");
                    break;
            }
                
                      
            return myitems;
        }

      

        static void Main(string[] args)
        {
            ProcessRepositories().Wait();
            
        }
    }
}
