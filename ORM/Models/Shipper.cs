using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Shippers")]
    public class Shipper : BaseModel
    {
        [Identity]
        [PrimaryKey]
        [Column("ShipperID")]
        public int ShipperId { get; set; }

        [NotNull]
        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }
    }
}