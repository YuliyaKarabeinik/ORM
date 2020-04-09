using Newtonsoft.Json;

namespace ORM.Models
{
    public class BaseModel
    {
        public override string ToString() => JsonConvert.SerializeObject(
            this, 
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}
