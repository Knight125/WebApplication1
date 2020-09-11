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
        }
    }
}
