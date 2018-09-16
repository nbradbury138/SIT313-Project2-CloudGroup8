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
        public async Task<LoginServerReturnData> RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var returnValue = new LoginServerReturnData();
            var client = new HttpClient();

            var model = new UserRegistrationData
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.PostAsync(
                    "https://sit313apiserver.azurewebsites.net/api/Account/Register", httpContent);
            }
            catch(Exception ex)
            {
                returnValue.SuccessStatus = false;
                returnValue.ErrorMessage = ex.ToString();
                return returnValue;
            }

            returnValue.SuccessStatus = response.IsSuccessStatusCode;
            if(!returnValue.SuccessStatus)
                returnValue.ErrorMessage = response.ReasonPhrase;

            return returnValue;
        }

        public async Task<LoginServerReturnData> LoginAsync(string userName, string password)
        {
            var returnValue = new LoginServerReturnData();
            var client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://sit313apiserver.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(values);
            
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);
                var accessToken = jwtDynamic.Value<string>("access_token");

                if(string.IsNullOrEmpty(accessToken))
                {
                    returnValue.SuccessStatus = false;
                    returnValue.ErrorMessage = "Something went wrong - Empty Access Token";
                }
                else
                {
                    returnValue.SuccessStatus = true;
                    returnValue.AccessToken = accessToken;
                }
            }
            else
            {
                returnValue.SuccessStatus = false;
                returnValue.ErrorMessage = response.ReasonPhrase;
            }
            return returnValue;
        }

        private class UserRegistrationData
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public class LoginServerReturnData
        {
            public bool SuccessStatus;
            public string ErrorMessage;
            public string AccessToken;
        }
    }
}
