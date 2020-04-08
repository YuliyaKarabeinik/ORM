using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;

namespace ORM
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
            OtherKey = nameof(ORM.Employee.EmployeeId), 
            CanBeNull = true)]
        public Employee Employee { get; set; }

        [Association(
            ThisKey = nameof(ShipperId), 
            OtherKey = nameof(ORM.Shipper.ShipperId), 
            CanBeNull = true)]
        public Shipper Shipper { get; set; }

    }
}
