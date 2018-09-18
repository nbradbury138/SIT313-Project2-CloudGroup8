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
        public async Task<List<TaskData>> GetTask()
        {
            var returnValue = new List<TaskData>();
            var client = new HttpClient();

            if(SettingServices.AccessToken == null)
                return returnValue;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SettingServices.AccessToken);

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

        public async Task<int> PostTask(TaskData task)
        {
            var client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>();
            if(task.ServerId < 0)
                values.Add(new KeyValuePair<string, string>("Id", task.ServerId.ToString()));

            values.Add(new KeyValuePair<string, string>("TaskName", task.TaskName));
            values.Add(new KeyValuePair<string, string>("Description", task.Description));
            values.Add(new KeyValuePair<string, string>("Priority", task.Priority));
            values.Add(new KeyValuePair<string, string>("User", task.User));
            values.Add(new KeyValuePair<string, string>("Status", task.Status));
            values.Add(new KeyValuePair<string, string>("DueDate", task.DueDate.ToString()));
            values.Add(new KeyValuePair<string, string>("LastModifiedDate", DateTime.UtcNow.ToString()));

            if (SettingServices.AccessToken == null)
                return 0;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SettingServices.AccessToken);

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.PostAsync(
                    "https://sit313apiserver.azurewebsites.net/api/Task/", new FormUrlEncodedContent(values));

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
