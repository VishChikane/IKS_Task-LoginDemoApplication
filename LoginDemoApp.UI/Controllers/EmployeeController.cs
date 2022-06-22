using LoginDemoApp.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemoApp.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllEmpDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Employee/SelectEmployees";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var empModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<EmployeeModel>>(result);
                        var empModels = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(result);
                        return View(empModels);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }
                }
            }
            return View();
        }


        public IActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeLogin(EmployeeModel empModel)
        {
            if(empModel.Email == null || empModel.Password == null)
            {
                ViewBag.message = "All fields are mandatory";
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(empModel), Encoding.UTF8, "application/json");
                    string endpoint = _configuration["WebApiBaseUrl"] + "Employee/Login";
                    using (var response = await client.PostAsync(endpoint, content))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            var emp = JsonConvert.DeserializeObject<EmployeeModel>(result);
                            ViewBag.status = "OK";
                            ViewBag.message = "Congratulation.!"+ emp.GivenName + " "+emp.Surname+ " ["+emp.Role +"]";
                            //return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Credentails!";
                        }
                    }
                }
            }
            return View();
        }

        public IActionResult EmployeeRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeRegister(EmployeeModel emp)
        {
            if (emp.Email == null || emp.Password == null || emp.GivenName == null || emp.Surname == null || emp.UserName == null)
            {
                ViewBag.message = "All fields are mandatory";
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/Register";
                    using (var response = await client.PostAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            ViewBag.status = "OK";
                            ViewBag.message = "Congratulation ..! " + result;
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Inputs!";
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeUpdate(int empId)
        {
            ViewBag.message = null;
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/SelectEmpById?EmpId="+empId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var emp = JsonConvert.DeserializeObject<EmployeeModel>(result);
                        return View(emp);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeUpdate(EmployeeModel emp)
        {
            if (emp.Email == null || emp.Password == null || emp.GivenName == null || emp.Surname == null || emp.UserName == null)
            {
                ViewBag.message = "All fields are mandatory";
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/Update?empId="+emp.EmpId;
                    using (var response = await client.PutAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            ViewBag.status = "OK";
                            ViewBag.message = "Congratulation ..! Update Successfully Done ..!";
                            return RedirectToAction("ShowAllEmpDetails", "Employee");
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Inputs!";
                        }
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EmployeeDelete(int empId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/SelectEmpById?EmpId=" + empId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var empModel = JsonConvert.DeserializeObject<EmployeeModel>(result);
                        return View(empModel);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmployeeDelete(EmployeeModel deleteEmp)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/Delete?EmpId=" + deleteEmp.EmpId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Employee Deleted Succesfully ...!";
                        return RedirectToAction("ShowAllEmpDetails", "Employee");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry, Employee Delete Failed ...!";
                    }
                }
            }
            return View();
        }
    }
}
