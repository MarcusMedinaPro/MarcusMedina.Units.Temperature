namespace MarcusMedina.Units.Temperature.US;

/// <summary>
/// Amerikanska temperaturenheter — Fahrenheit och Rankine.
/// <code>
/// 32.DegreesFahrenheit().ToCelsius()   // 0
/// 212.DegreesFahrenheit().ToCelsius()  // 100
/// </code>
/// </summary>
public static class USTemperatureExtensions
{
    /// <summary>Konverterar Fahrenheit till Temperature. K = (°F + 459.67) × 5/9</summary>
    public static Temperature DegreesFahrenheit(this int v) => new((v + 459.67) * 5.0 / 9.0);
    public static Temperature DegreesFahrenheit(this double v) => new((v + 459.67) * 5.0 / 9.0);

    /// <summary>Konverterar Rankine till Temperature. K = °R × 5/9</summary>
    public static Temperature DegreesRankine(this int v) => new(v * 5.0 / 9.0);
    public static Temperature DegreesRankine(this double v) => new(v * 5.0 / 9.0);

    public static double ToFahrenheit(this Temperature t) => t.Kelvin * 9.0 / 5.0 - 459.67;
    public static double ToRankine(this Temperature t) => t.Kelvin * 9.0 / 5.0;
}
