
namespace OnlineShopping.DTO
{
    /// <summary>
    /// Order Line Item Dto
    /// </summary>
    public class OrderLineItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }

    }
}
