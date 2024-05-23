using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientInformation.Models;
using System.Text.Json.Serialization;



namespace PatientInformation.Controllers
{
    public class PatientInfoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44362/api");

        private readonly HttpClient _client;
        public PatientInfoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PatientInfo> patientInfos = new List<PatientInfo>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/DiseaseInfo/GetDiseaseInfos").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                patientInfos = JsonConvert.DeserializeObject<List<PatientInfo>>(data);
            }
            return View(patientInfos);
        }

       

    }
}
