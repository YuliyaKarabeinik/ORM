using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Order Details")]
    public class OrderDetail : BaseModel
    {
        [PrimaryKey]
        [Column("OrderID")]
        public int OrderId { get; set; }

        [PrimaryKey]
        [Column("ProductID")]
        public int ProductId { get; set; }

        [Association(
            ThisKey = nameof(ProductId), 
            OtherKey = nameof(Models.Product.ProductId))]
        public Product Product { get; set; }

        [Association(
            ThisKey = nameof(OrderId), 
            OtherKey = nameof(Models.Order.OrderId))]
        public Order Order { get; set; }
    }
}
