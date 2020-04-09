using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [Identity]
        [PrimaryKey]
        [Column("ProductID")]
        public int ProductId { get; set; }

        [Column("ProductName")]
        [NotNull]
        public string ProductName { get; set; }

        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }

        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Column("SupplierID")]
        public int SupplierId { get; set; }

        [Association(
            ThisKey = nameof(CategoryId),
            OtherKey = nameof(Models.Category.CategoryId),
            CanBeNull = true)]
        public Category Category { get; set; }


        [Association(
            ThisKey = nameof(SupplierId),
            OtherKey = nameof(Models.Supplier.SupplierId),
            CanBeNull = true)]
        public Supplier Supplier { get; set; }

    }
}