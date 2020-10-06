using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication_Week12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEmployeeService _employeeService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet("hello/{id}")]
        public string GetAA()
        {
            return "Hello world";
        }

        [HttpGet("EmployeeListAdmin")]
        public IEnumerable<EmployeeViewModel> EmployeeListAdmin()
        {
            var employeeBModels = _employeeService.FetchAll(true);

            var vmList = new List<EmployeeViewModel>();
            foreach (var item in employeeBModels)
            {
                var vmEmployee = new EmployeeViewModel();

                vmEmployee.Id = item.EmployeeId;
                vmEmployee.Name = item.Name.ToUpper();
                vmEmployee.Salary = item.Salary; //.ToString();
                vmEmployee.IsRetired = item.IsRetired;
                vmEmployee.SalarySuper = item.SalarySuper.ToString();

                if (item.Salary > 5)
                {
                    vmEmployee.SalaryColor = "green";
                }
                else
                {
                    vmEmployee.SalaryColor = "red";
                }
                vmList.Add(vmEmployee);
            }

            return vmList;
        }






    }
}
