using Microsoft.AspNetCore.Mvc;
using MontyHallService.Domain;
using MontyHallService.Model;

namespace GeneaLogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        [Route("MontyHallSimulations")]
        [HttpGet]
        public async Task<IActionResult> MontyHallSimulations(int NumberOfSimulation, bool isChange)
        {
            try
            {
               
                if (NumberOfSimulation < 1)
                {
                    throw new InvalidDataException("No Game!!");
                }
                var response = MontyHallSimulation.MontySimulationCall(NumberOfSimulation, isChange);
               
                MontyResult result = new MontyResult
                {
                    NumberOfSimulation = NumberOfSimulation,
                    IsChange = isChange,
                    SuccessCount = response,
                    SuccessPercent = (Decimal)(response * 100) / NumberOfSimulation
                };
                return Ok(result);
            }

            catch (InvalidDataException dataEx)
            {
                return NotFound("No Game!!");
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


    }
}
