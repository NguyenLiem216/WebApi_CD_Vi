using API_Tutorial_ProductManager.Data;
using API_Tutorial_ProductManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_Tutorial_ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly DContext _context;

        public TypeController(DContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category_list_all = _context.Product_Types.ToList();
            return Ok(category_list_all);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category_list = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == id);
            if (category_list == null)
            {
                return NotFound();
            }

            return Ok(category_list);
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(ModelType modelType)
        {
            try
            {
                var category_lst_post = new Products_Type
                {
                    TypeName = modelType.TypeName
                };
                _context.Add(category_lst_post);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, category_lst_post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTypeById(int id, ModelType modelType)
        {
            var category_list = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == id);
            if (category_list == null)
            {
                return NotFound();
            }
            category_list.TypeName = modelType.TypeName;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var category_list = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == id);
            if (category_list == null)
            {
                return NotFound();
            }
            _context.Remove(category_list);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
