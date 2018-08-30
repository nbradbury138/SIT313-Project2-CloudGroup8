using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project2.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class UserServices
    {
        public async Task<bool> RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterViewModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await client.PostAsync(
                "http://192.168.1.51:45456/api/Account/Register", httpContent);

            return response.IsSuccessStatusCode;
        }

        /*public async Task LoginAsync(string userName, string password)
        {
            var client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.51:45456/Token");
            request.Content = new FormUrlEncodedContent(values);
            
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
            var accessToken = jwtDynamic.Value<string>("access_token");
        }*/
    }
}
