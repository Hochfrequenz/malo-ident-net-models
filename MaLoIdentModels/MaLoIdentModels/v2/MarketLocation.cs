using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <summary>
/// The market location entity in a positive identification result.
/// </summary>
/// <seealso cref="v1.DataMarketLocation">v1 equivalent (DataMarketLocation)</seealso>
public class MarketLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The market location identifier. Was <see cref="v1.DataMarketLocation.MaloId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierMarketLocation")]
    public string? IdentifierMarketLocation { get; set; }

    [JsonPropertyName("energyDirection")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnergyDirection EnergyDirection { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("measurementTechnologyClassification")]
    public MeasurementTechnologyClassification MeasurementTechnologyClassification { get; set; }

    /// <summary>
    /// Was <see cref="v1.DataMarketLocation.DataMarketLocationProperties"/> in v1.
    /// </summary>
    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationCharacteristic>))]
    [JsonPropertyName("characteristics")]
    public List<MarketLocationCharacteristic>? Characteristics { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationNetworkOperator>))]
    [JsonPropertyName("networkOperators")]
    public List<MarketLocationNetworkOperator>? NetworkOperators { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationMeasuringPointOperator>))]
    [JsonPropertyName("measuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator>? MeasuringPointOperators { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MarketLocationTransmissionSystemOperator>))]
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
