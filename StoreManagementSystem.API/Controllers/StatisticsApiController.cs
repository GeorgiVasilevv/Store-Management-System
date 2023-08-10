using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Models.ServiceModels.Statistics;
using StoreManagementSystem.Core.Services.Interfaces;
using System.Net;

namespace StoreManagementSystem.API.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StatisticsApiController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type =typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel serviceModel = await storeService.GetStatisticsAsync();

                return Ok(serviceModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
