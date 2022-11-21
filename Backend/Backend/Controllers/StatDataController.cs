using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatDataController : ControllerBase
    {
        private readonly IStatDataService statDataService;
        private readonly ILogger<StatDataController> logger;
        public StatDataController(IStatDataService service, ILogger<StatDataController> logger)
        {
            this.statDataService = service;
            this.logger = logger;
        }
    }
}
