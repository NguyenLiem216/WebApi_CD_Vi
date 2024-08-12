namespace API_Tutorial_ProductManager.Models
{
    public class ProductsVM
    {        
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }        
    }
    public class Products : ProductsVM
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public string? Img { get; set; }
    }
    public class ProductsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string TypeName { get; set; } = null!;
    }
}
