using Cede_Dotnet_MVC.Models;
using Cede_Dotnet_MVC.Services.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;


namespace Cede_Dotnet_MVC.Services
{
    public class DisponibilityService : IDisponibilityService
    {
        private string apiUrl { get; set; } = ConfigurationManager.AppSettings["apiurl"];

        private HttpClient httpClient { get; set; } = new HttpClient();

        public async Task<List<Disponibility>> GetDisponibility()
        {
            HttpResponseMessage result = await httpClient.GetAsync($"{apiUrl}Disponibility");

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = await result.Content.ReadAsStringAsync();

                var ODataJSON = JsonConvert.DeserializeObject<JObject>(jsonresult);

                return JsonConvert.DeserializeObject<List<Disponibility>>(ODataJSON.Property("value").Value.ToString());
            }

            return null;
        }
    }
}