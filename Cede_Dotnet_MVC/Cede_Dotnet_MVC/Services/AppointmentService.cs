using Cede_Dotnet_MVC.Models;
using Cede_Dotnet_MVC.Services.Contract;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cede_Dotnet_MVC.Services
{
    public class AppointmentService : IAppointmentService
    {
        private string apiUrl { get; set; } = ConfigurationManager.AppSettings["apiurl"];

        private HttpClient httpClient { get; set; } = new HttpClient();

        public async Task<Appointment> SaveAppointment(Appointment appointment)
        {
            string bodyRequest = JsonConvert.SerializeObject(appointment);

            var content = new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = await httpClient.PostAsync($"{apiUrl}Appointment", content);

            if (result.IsSuccessStatusCode)
            {
                var jsonresult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Appointment>(jsonresult.ToString());
            }

            return null;
        }
    }
}