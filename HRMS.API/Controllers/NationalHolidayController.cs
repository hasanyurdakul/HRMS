using HRMS.BUSINESS;
using HRMS.CORE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalHolidayController : ControllerBase
    {
        private readonly INationalHolidayService _nationalHolidayService;

        public NationalHolidayController(INationalHolidayService nationalHolidayService)
        {
            _nationalHolidayService = nationalHolidayService;
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<UpcomingNationalHolidayDTO>> GetUpcoming()
        {
            var result = await _nationalHolidayService.GetUpcomingNationalHolidaysAsync();
            return Ok(result);
        }
    }
}
