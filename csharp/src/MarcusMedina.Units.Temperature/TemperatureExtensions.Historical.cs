namespace MarcusMedina.Units.Temperature.Historical;

/// <summary>
/// Historiska temperaturskalor — Réaumur, Delisle, Newton, Rømer.
/// <code>
/// 80.DegreesReaumur().ToCelsius()   // 100
/// 0.DegreesNewton().ToCelsius()     // 0
/// </code>
/// </summary>
public static class HistoricalTemperatureExtensions
{
    /// <summary>Réaumur. K = °Ré × 5/4 + 273.15</summary>
    public static Temperature DegreesReaumur(this int v) => new(v * 5.0 / 4.0 + 273.15);
    public static Temperature DegreesReaumur(this double v) => new(v * 5.0 / 4.0 + 273.15);

    /// <summary>Delisle (inverterad — 0°De = 100°C). K = 373.15 - °De × 2/3</summary>
    public static Temperature DegreesDelisle(this int v) => new(373.15 - v * 2.0 / 3.0);
    public static Temperature DegreesDelisle(this double v) => new(373.15 - v * 2.0 / 3.0);

    /// <summary>Newton. K = °N × 100/33 + 273.15</summary>
    public static Temperature DegreesNewton(this int v) => new(v * 100.0 / 33.0 + 273.15);
    public static Temperature DegreesNewton(this double v) => new(v * 100.0 / 33.0 + 273.15);

    /// <summary>Rømer. K = (°Rø - 7.5) × 40/21 + 273.15</summary>
    public static Temperature DegreesRomer(this int v) => new((v - 7.5) * 40.0 / 21.0 + 273.15);
    public static Temperature DegreesRomer(this double v) => new((v - 7.5) * 40.0 / 21.0 + 273.15);

    public static double ToReaumur(this Temperature t) => (t.Kelvin - 273.15) * 4.0 / 5.0;
    public static double ToDelisle(this Temperature t) => (373.15 - t.Kelvin) * 3.0 / 2.0;
    public static double ToNewton(this Temperature t) => (t.Kelvin - 273.15) * 33.0 / 100.0;
    public static double ToRomer(this Temperature t) => (t.Kelvin - 273.15) * 21.0 / 40.0 + 7.5;
}
