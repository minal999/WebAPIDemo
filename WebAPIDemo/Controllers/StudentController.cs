using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        // GET: api/<StudentController>
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                return new ObjectResult(_service.GetAllStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }

        // GET api/<StudentController>/5
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                return new ObjectResult(_service.GetStudentById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent([FromBody] Student stud)
        {
            try
            {
                int res = _service.AddStudent(stud);
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

        // PUT api/<StudentController>/5
        [HttpPost]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Student stud)
        {
            try
            {
                int res = _service.UpdateStudent(stud);
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

        // DELETE api/<StudentController>/5
        [HttpGet]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                int res = _service.DeleteStudent(id);
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
