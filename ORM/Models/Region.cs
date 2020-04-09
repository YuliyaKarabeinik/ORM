using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Region")]
    public class Region : BaseModel
    {
        [PrimaryKey]
        [Column("RegionID")]
        public int RegionId { get; set; }

        [Column("RegionDescription")]
        public string RegionDescription { get; set; }
    }
}