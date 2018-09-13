using Newtonsoft.Json;
using Project2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class WebServices
    {
        public async Task GetTaskAsync(int taskId, string access_token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            var apiString = $"http://localhost:49563/api/Task/'{taskId}'";

            var json = await client.GetStringAsync(apiString);
            var values = JsonConvert.DeserializeObject<List<string>>(json);
        }

        public async Task SetTaskAsync(TaskData task, string access_token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            var apiString = $"http://localhost:49563/api/Task/'{task.Id}'";
            var content = new StringContent(task.ToString());

            var response = await client.PostAsync(apiString, content);
        }
    }
}
