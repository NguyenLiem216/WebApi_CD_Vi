using API_Tutorial_ProductManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Tutorial_ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsFSPController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsFSPController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAllProducts(string? search, decimal? from, decimal? to, string? sortBy, int page = 1)
        {
            try
            {
                var result = _productRepository.GetAll(search ?? string.Empty, from, to, sortBy ?? string.Empty, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Hello World!");
            }
        }
    }
}
