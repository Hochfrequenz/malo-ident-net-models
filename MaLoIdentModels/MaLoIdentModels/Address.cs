#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace MaLoIdentModels;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Address
{
    [JsonPropertyName("countryCode")]
    [RegularExpression(@"[A-Z]{2}")]
    public string CountryCode { get; set; }

    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("houseNumber")]
    public int HouseNumber { get; set; }

    [JsonPropertyName("houseNumberAddition")]
    public string HouseNumberAddition { get; set; }
}
