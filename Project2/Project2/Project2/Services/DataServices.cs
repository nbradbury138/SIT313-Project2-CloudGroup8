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
        public async Task<TaskData> GetTask(string username)
        {
            var returnValue = new TaskData();
            var client = new HttpClient();

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.GetAsync(string.Format("https://sit313apiserver.azurewebsites.net/api/Task/{0}", username));
            }
            catch (Exception ex)
            {
                returnValue.SuccessStatus = false;
                returnValue.ErrorMessage = ex.ToString();
                return returnValue;
            }

            returnValue.SuccessStatus = response.IsSuccessStatusCode;
            if (!returnValue.SuccessStatus)
                returnValue.ErrorMessage = response.ReasonPhrase;

            return returnValue;
        }
    }
}
