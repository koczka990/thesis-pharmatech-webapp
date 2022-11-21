using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountingDataController : ControllerBase
    {
        private readonly ICountingDataService countingDataService;
        private readonly ILogger<CountingDataController> logger;
        public CountingDataController(ICountingDataService service, ILogger<CountingDataController> logger)
        {
            this.countingDataService = service;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetCountingData()
        {
            try
            {
                return Ok(countingDataService.GetAllData());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GenerateTestData")]
        public IActionResult GenerateTestData(DateTime fromTime, DateTime toTime)
        {
            try
            {
                countingDataService.GenerateTestData(fromTime, toTime);
                return Ok();
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
