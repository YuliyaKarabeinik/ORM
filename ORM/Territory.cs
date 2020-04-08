
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace ORM
{
    [Table("Territories")]
    public class Territory
    {
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }

        [Column("TerritoryDescription")]
        public string TerritoryDescription { get; set; }

        [Column("RegionID")]
        public int RegionId { get; set; }

        [Association(
            ThisKey = nameof(RegionId),
            OtherKey = nameof(ORM.Region.RegionId))]
        public Region Region { get; set; }

        public ICollection<Employee> Employees { get; set; }

        [Association(
            ThisKey = nameof(TerritoryId),
            OtherKey = nameof(EmployeeTerritory.TerritoryId))]
        public ICollection<EmployeeTerritory> EmployeeTerritories;
    }
}