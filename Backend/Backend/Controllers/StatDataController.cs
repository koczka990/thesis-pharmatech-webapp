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
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("DaysBetween")]
        public IActionResult GetDaysBetween(DateTime from, DateTime to)
        {
            try
            {
                return Ok(statDataService.GetDaysBetween(from, to));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Day")]
        public IActionResult GetDay(int year, int month, int day)
        {
            try
            {
                return Ok(statDataService.GetDay(year, month, day));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Month")]
        public IActionResult GetMonth(int year, int month)
        {
            try
            {
                return Ok(statDataService.GetMonth(year, month));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Year")]
        public IActionResult GetYear(int year)
        {
            try
            {
                return Ok(statDataService.GetYear(year));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("lastseven")]
        public IActionResult GetLastSeven()
        {
            try
            {
                return Ok(statDataService.GetLastSeven());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }

        }

        [HttpGet("LastMonthDays")]
        public IActionResult GetLastMonthDays()
        {
            try
            {
                return Ok(statDataService.GetLastMonthDays());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("MonthDays")]
        public IActionResult GetMonthDays(int year, int month)
        {
            try
            {
                return Ok(statDataService.GetMonthDays(year, month));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("YearMonths")]
        public IActionResult GetYearMonts(int year)
        {
            try
            {
                return Ok(statDataService.GetYearMonth(year));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
