using API_Tutorial_ProductManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace API_Tutorial_ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Products> products_list = new List<Products>();

        private static int currentId = 1;
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products_list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var products_a = products_list.SingleOrDefault(pd => pd.Id == id);
                if (products_a == null)
                {
                    return NotFound();
                }
                return Ok(products_a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Create(ProductsVM productsVM)
        {
            var products = new Products()
            {
                Id = currentId++,
                Name = productsVM.Name,
                Description = productsVM.Description,
                Price = productsVM.Price,
            };
            products_list.Add(products);
            return Ok( new {
                Success = true,
                Data = products_list
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Products productsedit)
        {
            try
            {
                var products_a = products_list.SingleOrDefault(pd => pd.Id == id);
                if (products_a == null)
                {
                    return NotFound();
                }
                if (id != products_a.Id)
                {
                    return BadRequest();
                }
                // Update
                products_a.Name = productsedit.Name;
                products_a.Price = productsedit.Price;
                products_a.Description = productsedit.Description;

                return Ok(new
                {
                    Success = true,
                    Data = products_a
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var products_a = products_list.SingleOrDefault(pd => pd.Id == id);
                if (products_a == null)
                {
                    return NotFound();
                }
                if (id != products_a.Id)
                {
                    return BadRequest();
                }
                // Update
                products_list.Remove(products_a);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
