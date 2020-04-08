using Newtonsoft.Json;

namespace ORM
{
    public class BaseModel
    {
        public override string ToString() => JsonConvert.SerializeObject(
            this, 
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}
