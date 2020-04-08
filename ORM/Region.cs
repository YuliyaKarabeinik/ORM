using LinqToDB.Mapping;

namespace ORM
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