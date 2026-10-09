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
    extension(int v)
    {
        /// <summary>Konverterar grader Celsius till Temperature. K = °C + 273.15</summary>
        public Temperature DegreesCelsius() => new(v + 273.15);
        /// <summary>Konverterar Kelvin till Temperature.</summary>
        public Temperature Kelvin() => new(v);
    }

    extension(double v)
    {
        public Temperature DegreesCelsius() => new(v + 273.15);
        public Temperature Kelvin() => new(v);
    }

    extension(Temperature t)
    {
        public double ToCelsius() => t.Kelvin - 273.15;
        public double ToKelvin() => t.Kelvin;
    }
}
