using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }


        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return new ObjectResult(_service.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }

        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return new ObjectResult(_service.GetProductById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }


        // POST api/<ProductController>
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product prod)
        {
            try
            {
                int res = _service.AddProduct(prod);
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

        // PUT api/<ProductController>/5
        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] Product prod)
        {
            try
            {
                int res = _service.UpdateProduct(prod);
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


        // DELETE api/<ProductController>/5
        [HttpGet]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                int res = _service.DeleteProduct(id);
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
