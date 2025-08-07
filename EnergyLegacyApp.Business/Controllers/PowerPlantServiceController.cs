using Microsoft.AspNetCore.Mvc;
using EnergyLegacyApp.Data;
using EnergyLegacyApp.Data.Models;
using EnergyLegacyApp.Business;

namespace EnergyLegacyApp_Business.Controllers
{
    [ApiController]
    [Route("PowerPlantService")]
    public class PowerPlantServiceController : ControllerBase
    {
        private readonly PowerPlantService _powerPlantService;

        public PowerPlantServiceController(IConfiguration configuration)
        {
            var dbHelper = new DatabaseHelper(configuration);
            var powerPlantRepo = new PowerPlantRepository(dbHelper);
            var energyConsumptionRepo = new EnergyConsumptionRepository(dbHelper);
            _powerPlantService = new PowerPlantService(powerPlantRepo, energyConsumptionRepo);
        }

        // DTO classes representing request bodies

        public class GetPowerPlantByIdRequest
        {
            public int Id { get; set; }
        }

        public class CreateOrUpdatePowerPlantRequest
        {
            public required PowerPlant Plant { get; set; }
        }

        public class DeletePowerPlantRequest
        {
            public int Id { get; set; }
        }

        public class GetPowerPlantsByEfficiencyRequest
        {
            public decimal MinEfficiency { get; set; }
        }

        public class CalculateTotalCapacityRequest
        {
            public required string Region { get; set; }
        }

        public class GeneratePowerPlantReportRequest
        {
            public int PlantId { get; set; }
        }

        // Endpoints now use explicit DTOs as parameters

        [HttpPost("GetAllPowerPlants")]
        [ProducesResponseType(typeof(List<PowerPlant>), StatusCodes.Status200OK)]
        public IActionResult GetAllPowerPlants()
        {
            try
            {
                var plants = _powerPlantService.GetAllPowerPlants();
                return Ok(plants);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("GetPowerPlantById")]
        [ProducesResponseType(typeof(PowerPlant), StatusCodes.Status200OK)]
        public IActionResult GetPowerPlantById([FromBody] GetPowerPlantByIdRequest request)
        {
            try
            {
                var plant = _powerPlantService.GetPowerPlantById(request.Id);
                return Ok(plant);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("CreatePowerPlant")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult CreatePowerPlant([FromBody] CreateOrUpdatePowerPlantRequest request)
        {
            try
            {
                bool created = _powerPlantService.CreatePowerPlant(request.Plant);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("UpdatePowerPlant")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult UpdatePowerPlant([FromBody] CreateOrUpdatePowerPlantRequest request)
        {
            try
            {
                bool updated = _powerPlantService.UpdatePowerPlant(request.Plant);
                return Ok(updated);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("DeletePowerPlant")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult DeletePowerPlant([FromBody] DeletePowerPlantRequest request)
        {
            try
            {
                bool deleted = _powerPlantService.DeletePowerPlant(request.Id);
                return Ok(deleted);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("GetPowerPlantsByEfficiency")]
        [ProducesResponseType(typeof(List<PowerPlant>), StatusCodes.Status200OK)]
        public IActionResult GetPowerPlantsByEfficiency([FromBody] GetPowerPlantsByEfficiencyRequest request)
        {
            try
            {
                var plants = _powerPlantService.GetPowerPlantsByEfficiency(request.MinEfficiency);
                return Ok(plants);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("CalculateTotalCapacity")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public IActionResult CalculateTotalCapacity([FromBody] CalculateTotalCapacityRequest request)
        {
            try
            {
                decimal totalCapacity = _powerPlantService.CalculateTotalCapacity(request.Region);
                return Ok(totalCapacity);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("GeneratePowerPlantReport")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GeneratePowerPlantReport([FromBody] GeneratePowerPlantReportRequest request)
        {
            try
            {
                string report = _powerPlantService.GeneratePowerPlantReport(request.PlantId);
                return Ok(report);
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
