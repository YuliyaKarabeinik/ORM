using System;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Orders")]
    public class Order : BaseModel
    {
        [Identity]
        [PrimaryKey]
        [Column("OrderID")]
        public int OrderId { get; set; }

        [Column("ShipVia")]
        public int? ShipperId { get; set; }

        [Column("ShippedDate")]
        public DateTime? ShippedDate { get; set; }

        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }

        [Association(
            ThisKey = nameof(EmployeeId), 
            OtherKey = nameof(Models.Employee.EmployeeId), 
            CanBeNull = true)]
        public Employee Employee { get; set; }

        [Association(
            ThisKey = nameof(ShipperId), 
            OtherKey = nameof(Models.Shipper.ShipperId), 
            CanBeNull = true)]
        public Shipper Shipper { get; set; }

    }
}
