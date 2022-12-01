using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return new ObjectResult(_service.GetAllEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }
        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                return new ObjectResult(_service.GetEmployeeById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            try
            {
                int res = _service.AddEmployee(emp);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee emp)
        {
            try
            {
                int res = _service.UpdateEmployee(emp);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpGet]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                int res = _service.DeleteEmployee(id);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
