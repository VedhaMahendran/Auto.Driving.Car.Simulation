using Auto.Driving.Car.Api.Interface;
using Auto.Driving.Car.Api.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Auto.Driving.Car.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoDrivingCarController : ControllerBase
    {
        private readonly ICarService _carService;

        public AutoDrivingCarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public ActionResult<string> MoveCar([FromBody] CarMoveRequestDto carMoveRequestDto)
        {
            try
            {
                var result = _carService.MoveCar(carMoveRequestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
