using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            RootObject rootnodes = JsonConvert.DeserializeObject<RootObject>(responseBody);
            List<Item> items = new List<Item>();
            items = rootnodes.items;
            //  DataTable testtable=jsonhelper.ToDataTable<Item>(items);
            //var msg = await stringTask;
            //Console.Write(msg);
        }

       

        static void Main(string[] args)
        {
            ProcessRepositories().Wait();
            // https://api.stackexchange.com/2.2/questions?fromdate=1554076800&todate=1556582400&order=desc&sort=activity&tagged=uwp&site=stackoverflow
        }


    

    }

    public static class jsonhelper
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType)??prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

    }
}
