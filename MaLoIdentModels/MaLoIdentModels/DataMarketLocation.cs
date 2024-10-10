using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataMarketLocation
{
    [JsonPropertyName("maloId")]
    public string? MaloId { get; set; }

    [JsonPropertyName("energyDirection")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnergyDirection EnergyDirection { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("measurementTechnologyClassification")]
    public MeasurementTechnologyClassification MeasurementTechnologyClassification { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("optionalChangeForecastBasis")]
    public OptionalChangeForecastBasis OptionalChangeForecastBasis { get; set; }

    [JsonPropertyName("dataMarketLocationProperties")]
    public List<MarketLocationProperties>? DataMarketLocationProperties { get; set; }

    [JsonPropertyName("dataMarketLocationNetworkOperators")]
    public List<MarketLocationNetworkOperator>? DataMarketLocationNetworkOperators { get; set; }

    [JsonPropertyName("dataMarketLocationMeasuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator>? DataMarketLocationMeasuringPointOperators { get; set; }

    [JsonPropertyName("dataMarketLocationTransmissionSystemOperators")]
    public List<MarketLocationTransmissionSystemOperator>? DataMarketLocationTransmissionSystemOperators { get; set; }

    [JsonPropertyName("dataMarketLocationSuppliers")]
    public List<MarketLocationSupplier>? DataMarketLocationSuppliers { get; set; }

    [JsonPropertyName("dataMarketLocationName")]
    public Name? DataMarketLocationName { get; set; }

    [JsonPropertyName("dataMarketLocationAddress")]
    public Address? DataMarketLocationAddress { get; set; }

    [JsonPropertyName("dataMarketLocationLandParcels")]
    public List<LandParcel>? DataMarketLocationLandParcels { get; set; }

    [JsonPropertyName("dataMarketLocationGeographicCoordinates")]
    public GeographicCoordinates? DataMarketLocationGeographicCoordinates { get; set; }
}
