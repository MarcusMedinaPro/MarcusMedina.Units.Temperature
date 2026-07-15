namespace MarcusMedina.Units.Temperature.Metric;

/// <summary>
/// Metriska temperaturenheter — Celsius och Kelvin.
/// <code>
/// 100.DegreesCelsius().ToFahrenheit()  // 212
/// 0.DegreesCelsius().ToKelvin()        // 273.15
/// </code>
/// </summary>
public static class MetricTemperatureExtensions
{
    /// <summary>Konverterar grader Celsius till Temperature. K = °C + 273.15</summary>
    public static Temperature DegreesCelsius(this int v) => new(v + 273.15);
    public static Temperature DegreesCelsius(this double v) => new(v + 273.15);

    /// <summary>Konverterar Kelvin till Temperature.</summary>
    public static Temperature Kelvin(this int v) => new(v);
    public static Temperature Kelvin(this double v) => new(v);

    public static double ToCelsius(this Temperature t) => t.Kelvin - 273.15;
    public static double ToKelvin(this Temperature t) => t.Kelvin;
}
