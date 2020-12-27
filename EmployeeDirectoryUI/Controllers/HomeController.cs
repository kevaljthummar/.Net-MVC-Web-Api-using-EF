using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDirectoryUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
        {
            string FormType = collection.Get("formtype");
            string Image = collection.Get("Image");
            string FirstName = collection.Get("FirstName");
            string LastName = collection.Get("LastName");
            string EmailAddress = collection.Get("EmailAddress");
            string DOB = collection.Get("DOB");
            string Password = collection.Get("Password");
            string Salary = collection.Get("Salary");
            string Address = collection.Get("Address");
            string contryDDL = collection.Get("contryDDL");
            string stateDDL = collection.Get("stateDDL");
            string cityDDL = collection.Get("cityDDL");
            string ZipCode = collection.Get("ZipCode");
            string MaritalStatus = collection.Get("MaritalStatus");
            string gender = collection.Get("gender");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public string GetContrys()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("GetContries");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync().Result;
                    return jsonString;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        public string GetStates(int ContryId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("GetStates?ContryId=" + ContryId);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync().Result;
                    return jsonString;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpGet]
        public string GetCitys(int StateId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("GetCitys?StateId=" + StateId);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync().Result;
                    return jsonString;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}