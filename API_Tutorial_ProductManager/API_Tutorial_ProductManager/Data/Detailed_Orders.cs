namespace API_Tutorial_ProductManager.Data
{
    public class Detailed_Orders
    {
        public int Id { get; set; }
        public int Id_Ord { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public byte Discount { get; set; }

        //Relationship
        public Product_data Products { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}
