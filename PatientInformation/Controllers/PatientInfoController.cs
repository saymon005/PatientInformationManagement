using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientInformation.Models;
using System.Text;

namespace PatientInformation.Controllers
{
    public class PatientInfoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7133/api");

        private readonly HttpClient _client;
        public PatientInfoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        private List<string> GetDiseaseList()
        {
            return new List<string>
            {
                "Diabetes",
                "Hypertension",
                "Heart Disease",
                "Asthma",
                "Cancer",
                "Mental illness"
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PatientInfo> patientInfos = new List<PatientInfo>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/PatientInfo/GetPatientInfos").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                patientInfos = JsonConvert.DeserializeObject<List<PatientInfo>>(data);
            }
            return View(patientInfos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Diseases = GetDiseaseList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientInfo patientInfo)
        {
            try
            {
                string data = JsonConvert.SerializeObject(patientInfo);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _client.PostAsync(_client.BaseAddress + "/PatientInfo/CreatePatientInfo", stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                
            }
            ViewBag.Diseases = GetDiseaseList();
            return View();

        }
        [HttpGet]
        public IActionResult EditPatientInfo(int id)
        {
            try
            {
                PatientInfo patientInfo = new PatientInfo();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/PatinetInfo/GetPatientInfo/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    patientInfo = JsonConvert.DeserializeObject<PatientInfo>(data);
                }
                return View(patientInfo);
            }
            catch(Exception ex) 
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditPatientInfo(PatientInfo patientInfo)
        {
            try
            {
                string data = JsonConvert.SerializeObject(patientInfo);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _client.PostAsync(_client.BaseAddress + "/PatientInfo/UpdatePatientInfo", stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.Diseases = GetDiseaseList();
            return View();
        }
    }
}
