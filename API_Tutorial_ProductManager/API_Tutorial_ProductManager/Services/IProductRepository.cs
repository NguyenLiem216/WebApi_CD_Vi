using API_Tutorial_ProductManager.Models;

namespace API_Tutorial_ProductManager.Services
{
    public interface IProductRepository
    {
        List<ProductsModel> GetAll(string search, decimal? from, decimal? to, string sortBy, int page = 1);
    }
}
