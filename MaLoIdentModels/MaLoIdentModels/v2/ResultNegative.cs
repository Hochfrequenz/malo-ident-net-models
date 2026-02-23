using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

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

    [JsonPropertyName("identifierNetworkOperator")]
    public long? IdentifierNetworkOperator { get; set; }
}
