using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class ResultNegative
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("decisionTree")]
    [RegularExpression(@"E_\d{4}")]
    public string? DecisionTree { get; set; }

    [JsonPropertyName("responseCode")]
    [RegularExpression(@"A[A-Z\d]{2}")]
    public string? ResponseCode { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("networkOperator")]
    public long? NetworkOperator { get; set; }
}
