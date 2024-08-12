using API_Tutorial_ProductManager.Data;
using API_Tutorial_ProductManager.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tutorial_ProductManager.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(DContext context) 
        {
            _context = context;
        }
        public List<ProductsModel> GetAll(string search, decimal? from, decimal? to, string sortBy, int page = 1)
        {
            var allProduct = _context.Product_Datas.Include(p=>p.Products_Type).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(pd => pd.Name.Contains(search));
            }
            if(from.HasValue)
            {
                allProduct = allProduct.Where(pd => pd.Price >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(pd => pd.Price <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name
            allProduct = allProduct.OrderBy(pd => pd.Name);

            if (sortBy != null)
            {
                switch(sortBy)
                {
                    case "name":
                        allProduct = allProduct.OrderBy(p => p.Name);
                        break;
                    case "price":
                        allProduct = allProduct.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        allProduct = allProduct.OrderByDescending(p => p.Price);
                        break;
                    default:
                        allProduct = allProduct.OrderBy(p => p.Id);
                        break;
                }
            }
            #endregion

            //#region Paging
            //allProduct = allProduct.Skip((page-1)*PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProduct.Select(pd => new ProductsModel
            //{
            //    Id = pd.Id,
            //    Name = pd.Name,
            //    Price = pd.Price,
            //    TypeName = pd.Products_Type.TypeName,
            //});
            //return result.ToList();
            #region Paging
            var result = PaginatedList<Product_data>.Create(allProduct,page,PAGE_SIZE);

            return result.Select(p => new ProductsModel {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                TypeName = p.Products_Type != null ? p.Products_Type.TypeName : "Unknown",
            }).ToList();
            #endregion

        }
    }
}
