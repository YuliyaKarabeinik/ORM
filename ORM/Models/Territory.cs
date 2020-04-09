using LinqToDB.Mapping;

namespace ORM.Models
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
            OtherKey = nameof(Models.Region.RegionId))]
        public Region Region { get; set; }
    }
}