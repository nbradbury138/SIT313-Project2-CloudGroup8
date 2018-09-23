using Project2.Helpers;
using Newtonsoft.Json;
using Project2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project2.Services
{
    public static class DataServices
    {
        public static async Task<List<TaskData>> GetTask()
        {
            var returnValue = new List<TaskData>();
            var client = new HttpClient();

            if(SettingServices.AccessToken == null)
                return returnValue;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SettingServices.AccessToken);

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var json = await client.GetStringAsync(string.Format("https://sit313apiserver.azurewebsites.net/api/TaskModels/"));
                returnValue = JsonConvert.DeserializeObject<List<TaskData>>(json);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error attempting to get the task from the server - " + ex.Message, "OK", "Cancel");
                return returnValue;
            }

            return returnValue;
        }

        public static async Task<TaskData> GetTask(int serverId)
        {
            var returnValue = new TaskData();
            var client = new HttpClient();

            if (SettingServices.AccessToken == null)
                return returnValue;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SettingServices.AccessToken);

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var json = await client.GetStringAsync(string.Format("https://sit313apiserver.azurewebsites.net/api/TaskModels/{0}", serverId));
                returnValue = JsonConvert.DeserializeObject<TaskData>(json);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error attempting to get the task from the server - " + ex.Message, "OK", "Cancel");
                return returnValue;
            }

            return returnValue;
        }

        public static async Task<int> PostTask(TaskData task)
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
                    "https://sit313apiserver.azurewebsites.net/api/TaskModels/", new FormUrlEncodedContent(values));

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TaskData>(content).Id;
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error attempting to insert the task from the server - " + ex.Message, "OK", "Cancel");
                return 0;
            }
        }

        public static async Task<int> PutTask(TaskData task)
        {
            var client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>();

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
                response = await client.PutAsync(
                    "https://sit313apiserver.azurewebsites.net/api/TaskModels/", new FormUrlEncodedContent(values));

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TaskData>(content).Id;
                }

                return 0;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error attempting to update the task from the server - " + ex.Message, "OK", "Cancel");
                return 0;
            }
        }

        public static async Task<int> DeleteTask(TaskData task)
        {
            var client = new HttpClient();

            string deleteID;
            if (task.ServerId > 0)
                deleteID = task.ServerId.ToString();
            else
                return 0;

            if (SettingServices.AccessToken == null)
                return 0;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SettingServices.AccessToken);

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.DeleteAsync(string.Format("https://sit313apiserver.azurewebsites.net/api/TaskModels/{0}", deleteID));

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    await Application.Current.MainPage.DisplayAlert("Error", "Could not remove task from server with code: " + response.StatusCode.ToString(), "OK", "Cancel");

                return 0;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error attempting to delete the task from the server - " + ex.Message, "OK", "Cancel");
                return 0;
            }
        }

        public static async Task Synchronise()
        {
            DBHelper dbhelp = new DBHelper();
            var localTasks = dbhelp.GetAllTasksForUser(SettingServices.Username);
            var remoteTasks = await GetTask();

            foreach(var remote in remoteTasks)
            {
                var found = false;
                foreach(var local in localTasks)
                {
                    if (local.ServerId == remote.Id)
                    {
                        found = true;
                        if (remote.LastModifiedDate > local.LastModifiedDate)
                        {
                            local.Description = remote.Description;
                            local.DueDate = remote.DueDate;
                            local.LastModifiedDate = remote.LastModifiedDate;
                            local.Priority = remote.Priority;
                            local.ServerId = remote.Id;
                            local.Status = remote.Status;
                            local.TaskName = remote.TaskName;
                            local.User = remote.User;
                            dbhelp.UpdateTask(local);
                        }
                        break;
                    }
                }
                if (!found)
                {
                    var newTask = new TaskData();

                    newTask.ServerId = remote.Id;
                    newTask.Description = remote.Description;
                    newTask.DueDate = remote.DueDate;
                    newTask.LastModifiedDate = remote.LastModifiedDate;
                    newTask.Priority = remote.Priority;
                    newTask.ServerId = remote.Id;
                    newTask.Status = remote.Status;
                    newTask.TaskName = remote.TaskName;
                    newTask.User = remote.User;
                    dbhelp.InsertTask(newTask);
                }
            }

            foreach(var local in localTasks)
            {
                var found = false;
                foreach (var remote in remoteTasks)
                {
                    if (remote.Id == local.ServerId)
                    {
                        found = true;
                        if (local.LastModifiedDate > remote.LastModifiedDate)
                        {
                            remote.Description = local.Description;
                            remote.DueDate = local.DueDate;
                            remote.LastModifiedDate = local.LastModifiedDate;
                            remote.Priority = local.Priority;
                            remote.ServerId = local.ServerId;
                            remote.Id = local.ServerId;
                            remote.Status = local.Status;
                            remote.TaskName = local.TaskName;
                            remote.User = local.User;
                            await PutTask(remote);
                        }
                        break;
                    }
                }
                if (!found)
                {
                    var newTask = new TaskData();

                    newTask.Description = local.Description;
                    newTask.DueDate = local.DueDate;
                    newTask.LastModifiedDate = local.LastModifiedDate;
                    newTask.Priority = local.Priority;
                    newTask.Status = local.Status;
                    newTask.TaskName = local.TaskName;
                    newTask.User = local.User;

                    var result = await PostTask(newTask);
                    local.ServerId = result;
                    dbhelp.UpdateTask(local);

                    newTask.ServerId = local.ServerId;
                    newTask.Id = local.ServerId;
                    await PutTask(newTask);
                }
                    
            }
        }
    }
}
