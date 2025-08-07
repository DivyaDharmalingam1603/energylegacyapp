using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using EnergyLegacyApp.Data;
using Microsoft.AspNetCore.Http;

namespace EnergyLegacyApp_Data.Controllers
{
    [ApiController]
    public class DatabaseHelperController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Constructor with DI for IConfiguration
        public DatabaseHelperController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("GetConnection_e3b0c442")]
        [ProducesResponseType(typeof(MySqlConnection), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetConnection_e3b0c442Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                DatabaseHelper myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                
                // Initialize the right constructor with IConfiguration
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new DatabaseHelper(_configuration);
                }

                return Ok(myInstance.GetConnection());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("ExecuteQuery_473287f8")]
        [ProducesResponseType(typeof(DataTable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult ExecuteQuery_473287f8Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                DatabaseHelper myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new DatabaseHelper(_configuration);
                }

                string query = methodContainer.query;
                return Ok(myInstance.ExecuteQuery(query));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("ExecuteNonQuery_473287f8")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult ExecuteNonQuery_473287f8Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                DatabaseHelper myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new DatabaseHelper(_configuration);
                }

                string query = methodContainer.query;
                return Ok(myInstance.ExecuteNonQuery(query));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("ExecuteScalar_473287f8")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult ExecuteScalar_473287f8Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                DatabaseHelper myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new DatabaseHelper(_configuration);
                }

                string query = methodContainer.query;
                return Ok(myInstance.ExecuteScalar(query));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
    }
}