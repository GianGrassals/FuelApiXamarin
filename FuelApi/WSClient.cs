using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebServiceSample
{
    public class WSClient
    {

       //Get
        public async Task<List<T>> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response =  client.GetAsync(url).GetAwaiter().GetResult();
            var json = await response.Content.ReadAsStringAsync();
            var jsonList = JsonConvert.DeserializeObject<List<T>>(json);

            return jsonList;
        }

    }
}
