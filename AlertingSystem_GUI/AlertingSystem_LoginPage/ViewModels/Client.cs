using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using AlertingSystem_LoginPage.Models;
using Newtonsoft.Json;

namespace AlertingSystem_LoginPage.ViewModels
{
    public class Client
    {
        private readonly string remoteurl = "http://161.85.95.38:56294/";
        private readonly string localurl = "http://localhost:56294/";



        public ObservableCollection<Patient> GetAllPatients()
        {
            
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(localurl);
            var output = new ObservableCollection<Patient>();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = client.GetAsync("api/NurseStation/GetPatient/").Result;
            //string s = response.Content.ReadAsStringAsync().Result;
            //var output = JsonConvert.DeserializeObject<ObservableCollection<Patient>>(s);
            return output;
        }

        public Patient GetPatientBasedOnBed(int bed)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl+"api/NurseStation/GetPatientBasedOnBed/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(bed.ToString()).Result;
            string s = response.Content.ReadAsStringAsync().Result;
            var output = JsonConvert.DeserializeObject<Patient>(s);
            return output;

        }
        public Patient GetPatient(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl+"api/NurseStation/GetSpecificPatient/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(id).Result;
            string s = response.Content.ReadAsStringAsync().Result;
            var output = JsonConvert.DeserializeObject<Patient>(s);
            return output;
        }

        public List<int> GetVitals(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl+"api/NurseStation/Getvitals/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(id).Result;
            string s = response.Content.ReadAsStringAsync().Result;
            var output = JsonConvert.DeserializeObject<List<int>>(s);
            return output;
        }

        public void RegisterPatient(Patient patient)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl);
            var myContent = JsonConvert.SerializeObject(patient);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("api/NurseStation/register", byteContent).Result;
            if (!result.IsSuccessStatusCode)
            {
               throw new HttpException("Error");
            }
            
        }

        public void UpdatePatient(string id, Patient patient)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl+"api/NurseStation/UpdatePatientRecord/");
            var myContent = JsonConvert.SerializeObject(patient);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync(id.ToString(), byteContent).Result;
            if (!result.IsSuccessStatusCode)
            {
                throw new HttpException("Error");
            }

        }

        public List<string> GetPatientCondition(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localurl+"api/PatientCondition/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(id).Result;
            string s = response.Content.ReadAsStringAsync().Result;
            var output = JsonConvert.DeserializeObject<List<string>>(s);
            return output;
        }
    }
}
