using Cede_Dotnet_MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Cede_Dotnet_MVC.Services
{
    public class UserService
    {

        public List<User> GetUserByNit(string Nit)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage result = httpClient.GetAsync($@"http://localhost:51708/api/User?$filter=Nit eq '{Nit}'&$format=application/json;odata.metadata=none").Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = result.Content.ReadAsStringAsync().Result;

                var ODataJSON =  JsonConvert.DeserializeObject<JObject>(jsonresult);
                //ODataJSON.Property("@odata.context").Remove();
                //ODataJSON.Add("Terminal", ODataJSON["value"]); //adding Terminal attribute
                //ODataJSON.Property("value").Remove(); // removing default value attribute.

                return JsonConvert.DeserializeObject<List<User>>(ODataJSON.Property("value").Value.ToString());
            }

            return null;
        }

        public List<User> GetUsers()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage result = httpClient.GetAsync("http://localhost:51708/api/User").Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<User>>(jsonresult);
            }

            return null;
        }
    }
}