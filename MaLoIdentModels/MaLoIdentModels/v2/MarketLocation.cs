using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

public class MarketLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierMarketLocation")]
    public string? IdentifierMarketLocation { get; set; }

    [JsonPropertyName("energyDirection")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnergyDirection EnergyDirection { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("measurementTechnologyClassification")]
    public MeasurementTechnologyClassification MeasurementTechnologyClassification { get; set; }

    [JsonPropertyName("characteristics")]
    public List<MarketLocationCharacteristic>? Characteristics { get; set; }

    [JsonPropertyName("networkOperators")]
    public List<MarketLocationNetworkOperator>? NetworkOperators { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationMeasuringPointOperator>))]
    [JsonPropertyName("measuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator>? MeasuringPointOperators { get; set; }

    [JsonPropertyName("transmissionSystemOperators")]
    public List<MarketLocationTransmissionSystemOperator>? TransmissionSystemOperators { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationSupplier>))]
    [JsonPropertyName("suppliers")]
    public List<MarketLocationSupplier>? Suppliers { get; set; }

    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<LandParcel>))]
    [JsonPropertyName("landParcels")]
    public List<LandParcel>? LandParcels { get; set; }

    [JsonPropertyName("geographicCoordinates")]
    public GeographicCoordinates? GeographicCoordinates { get; set; }
}
