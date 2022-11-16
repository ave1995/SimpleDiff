using System.Text.Json.Serialization;

namespace SimpleDiff.Models
{
    public sealed class DiffGetModel
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;
    }
}
