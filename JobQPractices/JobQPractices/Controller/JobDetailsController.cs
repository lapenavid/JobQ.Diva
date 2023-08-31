using JobQPractices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JobQPractices.Controller
{
    [Route("api/jobDetails")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly ISimulationRepo _simulationRepo;
        public JobDetailsController(ISimulationRepo simulationRepo)
        {
            _simulationRepo = simulationRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSimulationName()
        {
            try
            {
                var details = await _simulationRepo.GetSimulationName();
                return Ok(details);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
