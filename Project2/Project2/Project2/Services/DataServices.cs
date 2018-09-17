using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class DataServices
    {
        public async Task<List<TaskData>> GetTask(string username, string accesstoken)
        {
            var returnValue = new List<TaskData>();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var json = await client.GetStringAsync(string.Format("https://sit313apiserver.azurewebsites.net/api/Task/"));
                returnValue = JsonConvert.DeserializeObject<List<TaskData>>(json);
            }
            catch (Exception ex)
            {
                return returnValue;
            }

            return returnValue;
        }
    }
}
