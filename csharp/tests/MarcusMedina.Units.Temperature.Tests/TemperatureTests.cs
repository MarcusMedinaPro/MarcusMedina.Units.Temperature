using FluentAssertions;
using MarcusMedina.Units.Temperature.Metric;
using MarcusMedina.Units.Temperature.US;
using MarcusMedina.Units.Temperature.Historical;
using Xunit;

namespace MarcusMedina.Units.Temperature.Tests;

public class MetricTemperatureTests
{
    [Fact]
    public void ZeroCelsius_ToKelvin_Is273point15()
        => 0.DegreesCelsius().ToKelvin().Should().BeApproximately(273.15, 0.001);

    [Fact]
    public void HundredCelsius_ToKelvin_Is373point15()
        => 100.DegreesCelsius().ToKelvin().Should().BeApproximately(373.15, 0.001);

    [Fact]
    public void AbsoluteZero_ToCelsius_IsMinus273point15()
        => 0.Kelvin().ToCelsius().Should().BeApproximately(-273.15, 0.001);

    [Fact]
    public void RoundTrip_Celsius()
        => 42.5.DegreesCelsius().ToCelsius().Should().BeApproximately(42.5, 0.0001);
}

public class USTemperatureTests
{
    [Fact]
    public void ThirtyTwoFahrenheit_ToCelsius_IsZero()
        => 32.DegreesFahrenheit().ToCelsius().Should().BeApproximately(0, 0.0001);

    [Fact]
    public void HundredTwelveFahrenheit_ToCelsius_IsHundred()
        => 212.DegreesFahrenheit().ToCelsius().Should().BeApproximately(100, 0.0001);

    [Fact]
    public void HundredCelsius_ToFahrenheit_Is212()
        => 100.DegreesCelsius().ToFahrenheit().Should().BeApproximately(212, 0.0001);

    [Fact]
    public void ZeroCelsius_ToRankine_Is491point67()
        => 0.DegreesCelsius().ToRankine().Should().BeApproximately(491.67, 0.01);

    [Fact]
    public void RoundTrip_Fahrenheit()
        => 98.6.DegreesFahrenheit().ToFahrenheit().Should().BeApproximately(98.6, 0.0001);
}

public class HistoricalTemperatureTests
{
    [Fact]
    public void ZeroCelsius_ToReaumur_IsZero()
        => 0.DegreesCelsius().ToReaumur().Should().BeApproximately(0, 0.0001);

    [Fact]
    public void HundredCelsius_ToReaumur_Is80()
        => 100.DegreesCelsius().ToReaumur().Should().BeApproximately(80, 0.0001);

    [Fact]
    public void EightyReaumur_ToCelsius_IsHundred()
        => 80.DegreesReaumur().ToCelsius().Should().BeApproximately(100, 0.0001);

    [Fact]
    public void HundredCelsius_ToDelisle_IsZero()
        => 100.DegreesCelsius().ToDelisle().Should().BeApproximately(0, 0.0001);

    [Fact]
    public void ZeroCelsius_ToDelisle_Is150()
        => 0.DegreesCelsius().ToDelisle().Should().BeApproximately(150, 0.0001);

    [Fact]
    public void ZeroCelsius_ToNewton_IsZero()
        => 0.DegreesCelsius().ToNewton().Should().BeApproximately(0, 0.0001);

    [Fact]
    public void HundredCelsius_ToNewton_Is33()
        => 100.DegreesCelsius().ToNewton().Should().BeApproximately(33, 0.0001);

    [Fact]
    public void ZeroCelsius_ToRomer_Is7point5()
        => 0.DegreesCelsius().ToRomer().Should().BeApproximately(7.5, 0.0001);

    [Fact]
    public void HundredCelsius_ToRomer_Is60()
        => 100.DegreesCelsius().ToRomer().Should().BeApproximately(60, 0.0001);

    [Fact]
    public void RoundTrip_Reaumur()
        => 80.0.DegreesReaumur().ToReaumur().Should().BeApproximately(80, 0.0001);

    [Fact]
    public void RoundTrip_Romer()
        => 7.5.DegreesRomer().ToRomer().Should().BeApproximately(7.5, 0.0001);
}

public class CrossSystemTemperatureTests
{
    [Fact]
    public void BoilingPoint_AllSystems()
    {
        var boiling = 100.DegreesCelsius();
        boiling.ToFahrenheit().Should().BeApproximately(212, 0.001);
        boiling.ToKelvin().Should().BeApproximately(373.15, 0.001);
        boiling.ToReaumur().Should().BeApproximately(80, 0.001);
        boiling.ToRankine().Should().BeApproximately(671.67, 0.01);
    }
}
