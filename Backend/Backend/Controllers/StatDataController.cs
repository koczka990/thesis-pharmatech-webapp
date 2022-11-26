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

        [HttpGet("updateAll")]
        public IActionResult updateAll()
        {
            try
            {
                statDataService.UpdateAll();
                return Ok();
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
