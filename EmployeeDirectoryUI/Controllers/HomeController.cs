using EmployeeDirectoryUI.Models;
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
            string EmpId = collection.Get("EmpId");
            string FormType = collection.Get("formtype");
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
            string Image = collection.Get("Image");

            Employee employee = new Employee()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = EmailAddress,
                Birthdate = DateTime.Parse(DOB),
                Password = Password,
                salary = Convert.ToDecimal(Salary),
                Address = Address,
                Country = Convert.ToInt32(contryDDL),
                State = Convert.ToInt32(stateDDL),
                City = Convert.ToInt32(cityDDL),
                Zipcode = ZipCode,
                MaritalStatus = MaritalStatus == "on" ? true : false,
                Gender = gender,
                Images = Image
            };

            if (FormType == "Edit")
                employee.Id = Convert.ToInt32(EmpId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                var FormAPI = FormType == "save" ? "AddEmployee" : "UpdateEmployee";

                var responseTask = client.PostAsJsonAsync<Employee>(FormAPI, employee);

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44333/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteEmployee?Id=" + Id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return null;
                }
            }
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

        [HttpGet]
        public string GetEmployee(int Id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44333/api/");

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    var responseTask = client.GetAsync("GetEmployee?Id=" + Id);
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
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult GetEmployeeList(JqueryDatatableParam param)
        {
            try
            {
                List<Employee> List = new List<Employee>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44333/api/");

                    var responseTask = client.GetAsync("GetEmployees");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var employees = result.Content.ReadAsAsync<List<Employee>>().Result;

                        if (!string.IsNullOrEmpty(param.sSearch))
                        {
                            employees = employees.Where(x => x.FirstName.ToLower().Contains(param.sSearch.ToLower())
                                                          || x.LastName.ToLower().Contains(param.sSearch.ToLower())
                                                          || x.Email.ToLower().Contains(param.sSearch.ToLower())
                                                          || x.Address.ToString().Contains(param.sSearch.ToLower())
                                                          || x.Gender.ToString().Contains(param.sSearch.ToLower())
                                                          || x.salary.ToString().Contains(param.sSearch.ToLower())
                                                          || x.Birthdate.ToString("dd'/'MM'/'yyyy").ToLower().Contains(param.sSearch.ToLower())).ToList();
                        }

                        var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
                        var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

                        //if (sortColumnIndex == 3)
                        //{
                        //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.Age) : employees.OrderByDescending(c => c.Age);
                        //}
                        //if (sortColumnIndex == 6)
                        //{
                        //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.Birthdate) : employees.OrderByDescending(c => c.Birthdate);
                        //}
                        //else if (sortColumnIndex == 7)
                        //{
                        //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.salary) : employees.OrderByDescending(c => c.salary);
                        //}
                        //else
                        //{
                        //    Func<Employee, string> orderingFunction = e => sortColumnIndex == 0 ? e.FirstName :
                        //                                                   sortColumnIndex == 1 ? e.LastName:
                        //                                                   e.Email;

                        //    employees = sortDirection == "asc" ? employees.OrderBy(orderingFunction) : employees.OrderByDescending(orderingFunction);
                        //}

                        var displayResult = employees.Skip(param.iDisplayStart)
                                                .Take(param.iDisplayLength).ToList();

                        var totalRecords = employees.Count();

                        return Json(new
                        {
                            param.sEcho,
                            iTotalRecords = totalRecords,
                            iTotalDisplayRecords = totalRecords,
                            aaData = displayResult
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}