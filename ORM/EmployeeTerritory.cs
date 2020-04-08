using LinqToDB.Mapping;

namespace ORM
{
    //[Table("EmployeeTerritories")]
    //public class EmployeeTerritory : BaseModel
    //{
    //    [Column("EmployeeID")]
    //    public int EmployeeId { get; set; }

    //    [Column("TerritoryID")]
    //    public int TerritoryId { get; set; }

    //    [Association(
    //        ThisKey = nameof(EmployeeId),
    //        OtherKey = nameof(ORM.Employee.EmployeeId))]
    //    public Employee Employee { get; set; }

    //    [Association(
    //        ThisKey = nameof(TerritoryId),
    //        OtherKey = nameof(ORM.Territory.TerritoryId))]
    //    public Territory Territory { get; set; }
    //}

    [Table("EmployeeTerritories")]
    public class EmployeeTerritory : BaseModel
    {
        [Column("EmployeeID")]
        [NotNull]
        public int EmployeeId { get; set; }

        [Column("TerritoryID")]
        [NotNull]
        public int TerritoryId { get; set; }

        [Association(
            ThisKey = nameof(EmployeeId), 
            OtherKey = nameof(ORM.Employee.EmployeeId))]
        public Employee Employee { get; set; }

        [Association(
            ThisKey = nameof(TerritoryId), 
            OtherKey = nameof(ORM.Territory.TerritoryId))]
        public Territory Territory { get; set; }
    }
}
