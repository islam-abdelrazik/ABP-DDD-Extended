using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ARB.ESBService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetailCustomerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RetailCustomerController> _logger;

        public RetailCustomerController(ILogger<RetailCustomerController> logger)
        {
            _logger = logger;
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

        public class ESBModel
        {
            public Guid CIC { get; set; }
            public string CR { get; set; }
        }

        [HttpGet]
        [Route("GetCRByName/{name}")]
        public ActionResult<ESBModel> GetCRByName(string name)
        {
            var rng = new Random();
            ESBModel model = new ESBModel
            {
                CIC = Guid.NewGuid(),
                CR = Summaries[rng.Next(Summaries.Length)]
            };
            return model;
        }
    }
}
