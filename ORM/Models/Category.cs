using System.Collections.Generic;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table("Categories")]
    public class Category : BaseModel
    {
        [PrimaryKey]
        [Identity]
        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Column("CategoryName")]
        public string CategoryName { get; set; }

        [Column("Description")]
        public string Description { get; set; }
        
        [Association(
            ThisKey = nameof(CategoryId), 
            OtherKey = nameof(Product.ProductId), 
            CanBeNull = true)]
        public IEnumerable<Product> Products { get; set; }
    }
}
