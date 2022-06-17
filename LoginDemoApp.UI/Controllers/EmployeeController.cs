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
                        ViewBag.message = "Congratulation ..! "+emp.GivenName+" login as a "+emp.Role+" ...!";
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Credentails!";
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
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/Register";
                using(var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.status = "OK";
                        ViewBag.message = "Congratulation ..! "+ result;
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Inputs!";
                    }
                }
            }
            return View();
        }
    }
}
