using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.ResultNegative">v1 equivalent</seealso>
public class ResultNegative
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("decisionTree")]
    [RegularExpression(@"^E_\d{4}$")] // anchors added; spec pattern is unanchored: https://github.com/EDI-Energy/api-electricity/issues/46
    public string? DecisionTree { get; set; }

    [JsonPropertyName("responseCode")]
    [RegularExpression(@"^A[A-Z\d]{2}$")] // anchors added; spec pattern is unanchored: https://github.com/EDI-Energy/api-electricity/issues/46
    public string? ResponseCode { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// The network operator's 13-digit market partner ID as string per v2 spec.
    /// Serialized as <c>identifierNetworkOperator</c> on the wire.
    /// Was <see cref="v1.ResultNegative.NetworkOperator"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierNetworkOperator")]
    [RegularExpression(@"^\d{13}$")]
    public string? IdentifierNetworkOperator { get; set; }
}
