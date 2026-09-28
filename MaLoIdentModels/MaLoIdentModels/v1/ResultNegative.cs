using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.ResultNegative">v2 equivalent</seealso>
public class ResultNegative
{
    [JsonIgnore]
    [Key]
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
