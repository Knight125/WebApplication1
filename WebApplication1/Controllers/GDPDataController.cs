using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GDPDataController : ControllerBase
    {

        private readonly ILogger<GDPDataController> _logger;

        public GDPDataController(ILogger<GDPDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GDPData> Get()
        {
            SQLDataAccesor accesor = new SQLDataAccesor();
            List<GDPData> dataGDP = accesor.data;
            return dataGDP;
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new GDPData
            {
                Country = "test" + index,
                SubjectDescriptor = "subj",
                Units = "uni",
                Scale = "corns",
                Y2012 = 12.1 + index,
                Y2013 = 13.1 + index,
                Y2014 = 14.1 + index,
                Y2015 = 15.1 + index,
                Y2016 = 16.1 + index,
                Y2017 = 17.1 + index,
                Y2018 = 18.1 + index,
                Y2019 = 19.1 + index,
                EstimatesStartAfter = 2013+  index
    })
            .ToArray();
        }
    }
}
