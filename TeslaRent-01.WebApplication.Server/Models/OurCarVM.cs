using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models;

public class OurCarVM
{
    // IDs
    [JsonPropertyName("id")]
    public int Id { get; set; }
    // STRINGS
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("bodyType")]
    public string BodyType { get; init; }
    [JsonPropertyName("description")]
    public string Description { get; init; }
    // NUMBERS
    [JsonPropertyName("dailyPriceShort")]
    public decimal DailyRateShortTerm { get; set; }
    [JsonPropertyName("dailyPriceMid")]
    public decimal DailyRateMidTerm { get; set; }
    [JsonPropertyName("dailyPriceLong")]
    public decimal DailyRateLongTerm { get; set; }
    [JsonPropertyName("seats")]
    public int Seats { get; set; }
    [JsonPropertyName("maxSpeed")]
    public int MaxSpeed { get; set; }
    [JsonPropertyName("maxRange")]
    public int MaxRange { get; set; }
    [JsonPropertyName("acceleration")]
    public decimal Acceleration { get; set; }
}
