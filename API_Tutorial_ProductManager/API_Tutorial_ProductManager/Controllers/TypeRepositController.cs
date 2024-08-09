using API_Tutorial_ProductManager.Models;
using API_Tutorial_ProductManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Tutorial_ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeRepositController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public TypeRepositController(ITypeRepository typeRepository) 
        { 
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(_typeRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _typeRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, TypeVM type)
        {
            if(id != type.Id_Type)
            {
                return BadRequest();
            }
            try
            {
               _typeRepository.Update(type);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _typeRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(ModelType modelType)
        {
            try
            {
                return Ok(_typeRepository.Add(modelType));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
