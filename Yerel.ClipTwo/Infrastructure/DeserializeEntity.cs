using Newtonsoft.Json;

namespace Yerel.ClipTwo.Infrastructure
{
    public class DeserializeEntity
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }
    }
}