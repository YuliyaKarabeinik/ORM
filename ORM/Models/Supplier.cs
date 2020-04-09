using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Suppliers")]
    public class Supplier : BaseModel
    {
        [Identity]
        [PrimaryKey]
        [Column("SupplierID")]
        public int SupplierId { get; set; }

        [Column("CompanyName")]
        [NotNull]
        public string CompanyName { get; set; }

        [Column("ContactName")]
        public string ContactName { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("Region")]
        public string Region { get; set; }
    }
}