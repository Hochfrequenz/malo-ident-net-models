#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace MaLoIdentModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

public enum EnergyDirection
{
    [EnumMember(Value = "consumption")]
    [JsonStringEnumMemberName("consumption")]
    Consumption,

    [EnumMember(Value = "production")]
    [JsonStringEnumMemberName("production")]
    Production,
}

public enum MarketLocationProperty
{
    [EnumMember(Value = "customerFacility")]
    CustomerFacility,

    [EnumMember(Value = "nonActive")]
    [JsonStringEnumMemberName("nonActive")]
    NonActive,

    [EnumMember(Value = "standard")]
    [JsonStringEnumMemberName("standard")]
    Standard,
}

public enum MeasurementTechnologyClassification
{
    [EnumMember(Value = "intelligentMeasuringSystem")]
    IntelligentMeasuringSystem,

    [EnumMember(Value = "conventionalMeasuringSystem")]
    ConventionalMeasuringSystem,

    [EnumMember(Value = "noMeasurement")]
    [JsonStringEnumMemberName("noMeasurement")]
    NoMeasurement,
}

public enum OptionalChangeForecastBasis
{
    [EnumMember(Value = "possible")]
    [JsonStringEnumMemberName("possible")]
    Possible,

    [EnumMember(Value = "notPossible")]
    [JsonStringEnumMemberName("notPossible")]
    NotPossible,
}

public enum Proportion
{
    [EnumMember(Value = "bilateralAgreement")]
    BilateralAgreement,

    [EnumMember(Value = "percent")]
    [JsonStringEnumMemberName("percent")]
    Percent,
}

public enum Zone
{
    [EnumMember(Value = "UTMZone31")]
    [JsonStringEnumMemberName("UTMZone31")]
    UTMZone31,

    [EnumMember(Value = "UTMZone32")]
    [JsonStringEnumMemberName("UTMZone32")]
    UTMZone32,

    [EnumMember(Value = "UTMZone33")]
    [JsonStringEnumMemberName("UTMZone33")]
    UTMZone33,
}

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

public class MarketLocationDateTime
{
    [JsonPropertyName("maloId")]
    [RegularExpression(@"\d{11}")]
    public string MaloId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class IdentificationParameter
{
    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("identificationDateTime")]
    public DateTimeOffset IdentificationDateTime { get; set; }
    [JsonPropertyName("maloId")]
    [RegularExpression(@"\d{11}")]
    public string MaloId { get; set; }

    [JsonPropertyName("tranchenIds")]
    public List<string> TranchenIds { get; set; }

    [JsonPropertyName("meloIds")]
    public List<string> MeloIds { get; set; }

    [JsonPropertyName("meterNumbers")]
    public List<string> MeterNumbers { get; set; }

    [JsonPropertyName("customerNumber")]
    public string CustomerNumber { get; set; }
}

public class GeographicCoordinates
{
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }

    [JsonPropertyName("east")]
    public string East { get; set; }

    [JsonPropertyName("north")]
    public string North { get; set; }

    [JsonPropertyName("zone")]
    public Zone? Zone { get; set; }

    [JsonPropertyName("northing")]
    public string Northing { get; set; }

    [JsonPropertyName("easting")]
    public string Easting { get; set; }
}

public class Name
{
    [JsonPropertyName("surnames")]
    public string Surnames { get; set; }

    [JsonPropertyName("firstnames")]
    public string Firstnames { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("company")]
    public string Company { get; set; }
}

// Full Models Incorporating Other Models
public class MarketLocationMeasuringPointOperator
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class MarketLocationNetworkOperator
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class MarketLocationProperties
{
    [JsonPropertyName("marketLocationProperty")]
    public MarketLocationProperty MarketLocationProperty { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class MarketLocationSupplier
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class MarketLocationTransmissionSystemOperator
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}

public class ResultNegative
{
    [JsonPropertyName("decisionTree")]
    [RegularExpression(@"E_\d{4}")]
    public string DecisionTree { get; set; }

    [JsonPropertyName("responseCode")]
    [RegularExpression(@"A[A-Z\d]{2}")]
    public string ResponseCode { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    [JsonPropertyName("networkOperator")]
    public long? NetworkOperator { get; set; }
}

public class DataMarketLocation
{
    [JsonPropertyName("maloId")]
    [RegularExpression(@"\d{11}")]
    public string MaloId { get; set; }

    [JsonPropertyName("energyDirection")]
    public EnergyDirection EnergyDirection { get; set; }

    [JsonPropertyName("measurementTechnologyClassification")]
    public MeasurementTechnologyClassification MeasurementTechnologyClassification { get; set; }

    [JsonPropertyName("optionalChangeForecastBasis")]
    public OptionalChangeForecastBasis OptionalChangeForecastBasis { get; set; }

    // Change this to a list to match the JSON structure
    [JsonPropertyName("dataMarketLocationProperties")]
    public List<MarketLocationProperties> DataMarketLocationProperties { get; set; }

    [JsonPropertyName("dataMarketLocationNetworkOperators")]
    public List<MarketLocationNetworkOperator> DataMarketLocationNetworkOperators { get; set; }

    [JsonPropertyName("dataMarketLocationMeasuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator> DataMarketLocationMeasuringPointOperators { get; set; }

    [JsonPropertyName("dataMarketLocationTransmissionSystemOperators")]
    public List<MarketLocationTransmissionSystemOperator> DataMarketLocationTransmissionSystemOperators { get; set; }

    [JsonPropertyName("dataMarketLocationSuppliers")]
    public List<MarketLocationSupplier> DataMarketLocationSuppliers { get; set; }

    [JsonPropertyName("dataMarketLocationName")]
    public Name DataMarketLocationName { get; set; }

    [JsonPropertyName("dataMarketLocationAddress")]
    public Address DataMarketLocationAddress { get; set; }

    [JsonPropertyName("dataMarketLocationGeographicCoordinates")]
    public GeographicCoordinates DataMarketLocationGeographicCoordinates { get; set; }
}

public class DataTranche
{
    [JsonPropertyName("tranchenId")]
    [RegularExpression(@"\d{11}")]
    public string TranchenId { get; set; }

    [JsonPropertyName("proportion")]
    public Proportion Proportion { get; set; }

    [JsonPropertyName("percent")]
    public float? Percent { get; set; }

    [JsonPropertyName("dataTrancheSuppliers")]
    public List<MarketLocationSupplier> DataTrancheSuppliers { get; set; }
}

public class DataMeterLocation
{
    [JsonPropertyName("meloId")]
    [RegularExpression(@"DE\d{11}[A-Z,\d]{20}")]
    public string MeloId { get; set; }

    [JsonPropertyName("meterNumber")]
    public string MeterNumber { get; set; }

    [JsonPropertyName("dataMeterLocationMeasuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator> DataMeterLocationMeasuringPointOperators { get; set; }
}

public class DataControllableResource
{
    [JsonPropertyName("srId")]
    [RegularExpression(@"C[A-Z\d]{9}\d")]
    public string SrId { get; set; }

    [JsonPropertyName("dataControllableResourceMeasuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator> DataControllableResourceMeasuringPointOperators { get; set; }
}

public class DataNetworkLocation
{
    [JsonPropertyName("neloId")]
    [RegularExpression(@"E[A-Z\d]{9}\d")]
    public string NeloId { get; set; }

    [JsonPropertyName("dataNetworkLocationMeasuringPointOperators")]
    public List<MarketLocationMeasuringPointOperator> DataNetworkLocationMeasuringPointOperators { get; set; }
}

public class DataTechnicalResource
{
    [JsonPropertyName("trId")]
    [RegularExpression(@"D[A-Z\d]{9}\d")]
    public string TrId { get; set; }
}

public class ResultPositive
{
    [JsonPropertyName("dataMarketLocation")]
    public DataMarketLocation DataMarketLocation { get; set; }

    [JsonPropertyName("dataTranches")]
    public List<DataTranche> DataTranches { get; set; }

    [JsonPropertyName("dataMeterLocations")]
    public List<DataMeterLocation> DataMeterLocations { get; set; }

    [JsonPropertyName("dataTechnicalResources")]
    public List<DataTechnicalResource> DataTechnicalResources { get; set; }

    [JsonPropertyName("dataControllableResources")]
    public List<DataControllableResource> DataControllableResources { get; set; }

    [JsonPropertyName("dataNetworkLocations")]
    public List<DataNetworkLocation> DataNetworkLocations { get; set; }
}
