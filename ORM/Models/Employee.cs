using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Employees")]
    public class Employee : BaseModel
    {
        [Identity]
        [PrimaryKey]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }
        
        [Column("FirstName")]
        public string FirstName { get; set; }

        //[Column("LastName")]
        //public string City { get; set; }

        //[Column("ReportsTo")]
        //public int ReportsTo { get; set; }

        //[Association(
        //    ThisKey = nameof(ReportsTo),
        //    OtherKey = nameof(EmployeeId),
        //    CanBeNull = true)]
        //public Employee Supervisor { get; set; }
    }
}
