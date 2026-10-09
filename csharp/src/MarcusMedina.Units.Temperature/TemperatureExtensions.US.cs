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
    extension(int v)
    {
        /// <summary>Konverterar Fahrenheit till Temperature. K = (°F + 459.67) × 5/9</summary>
        public Temperature DegreesFahrenheit() => new((v + 459.67) * 5.0 / 9.0);
        /// <summary>Konverterar Rankine till Temperature. K = °R × 5/9</summary>
        public Temperature DegreesRankine() => new(v * 5.0 / 9.0);
    }

    extension(double v)
    {
        public Temperature DegreesFahrenheit() => new((v + 459.67) * 5.0 / 9.0);
        public Temperature DegreesRankine() => new(v * 5.0 / 9.0);
    }

    extension(Temperature t)
    {
        public double ToFahrenheit() => t.Kelvin * 9.0 / 5.0 - 459.67;
        public double ToRankine() => t.Kelvin * 9.0 / 5.0;
    }
}
