using OnlineShopping.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
    /// <summary>
    /// Order Line Items entity
    /// </summary>
    public class OrderLineItem : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }


    }
}
