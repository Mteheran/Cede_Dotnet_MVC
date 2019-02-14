using Cede_Dotnet_MVC.Models;
using Cede_Dotnet_MVC.Services.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace Cede_Dotnet_MVC.Services
{
    public class UserService : IUserService
    {
        private string apiUrl { get; set; } = ConfigurationManager.AppSettings["apiurl"];

        private HttpClient httpClient { get; set; } = new HttpClient();

        public User GetUserByUserId(string userId)
        {          
            HttpResponseMessage result = httpClient.GetAsync($@"{apiUrl}User/?Id={userId}").Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = result.Content.ReadAsStringAsync().Result;

                var ODataJSON =  JsonConvert.DeserializeObject<JObject>(jsonresult);
                ODataJSON.Property("@odata.context").Remove();
                //ODataJSON.Add("Terminal", ODataJSON["value"]); //adding Terminal attribute
                //ODataJSON.Property("value").Remove(); // removing default value attribute.

                return JsonConvert.DeserializeObject<User>(ODataJSON.ToString());
            }

            return null;
        }

        public string ValidateUserByNitAndNitDate(string nit, DateTime nitDate)
        {
            HttpResponseMessage result = httpClient.GetAsync($@"{apiUrl}User?$filter=Nit eq '{nit}'&$format=application/json").Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = result.Content.ReadAsStringAsync().Result;

                var ODataJSON = JsonConvert.DeserializeObject<JObject>(jsonresult);

                var user = JsonConvert.DeserializeObject<List<User>>(ODataJSON.Property("value").Value.ToString()).FirstOrDefault();
                if(user?.UserId.ToString() != string.Empty && user?.NitDate == nitDate)
                {
                    return user.UserId.ToString();
                }

                return "";
            }

            return null;
        }

        public List<User> GetUsers()
        {          
            HttpResponseMessage result = httpClient.GetAsync($"{ apiUrl}User").Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<User>>(jsonresult);
            }

            return null;
        }
    }
}