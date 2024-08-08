namespace API_Tutorial_ProductManager.Data
{
    public enum OrdStatus
    {
        New = 0, Payment=1, Complete = 2, Cancelled = -1
    }
    public class Order
    {
        public int Id_Ord { get; set; }
        public DateTime OrdDate { get; set; }
        public DateTime? DelDate { get; set; }
        public OrdStatus OrdStatus { get; set; }
        public string Receiver { get; set; } = null!;
        public string ReceiverAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Detailed_Orders> Detailed_Orders { get; set; } = null!;

        public Order() {
            Detailed_Orders = new List<Detailed_Orders>();
        }
    }
}
