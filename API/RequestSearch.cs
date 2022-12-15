using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace API
{
    public class RequestSearch
    {
        [JsonProperty(Required = Required.AllowNull)]
        [AllowNull]
        [DefaultValue(null)]
        public string? searchRequest { get; set; } = null;
    }
}
