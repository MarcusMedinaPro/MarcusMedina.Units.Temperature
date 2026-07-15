using System.Globalization;

namespace MarcusMedina.Units.Temperature;

/// <summary>
/// Representerar en temperatur med Kelvin som basenhet.
/// Alla konverteringar sker genom att omvandla till/från Kelvin.
/// </summary>
public readonly struct Temperature : IComparable<Temperature>, IEquatable<Temperature>
{
    /// <summary>Värdet i Kelvin (basenhet).</summary>
    public double Kelvin { get; }

    public Temperature(double kelvin) { Kelvin = kelvin; }

    public int CompareTo(Temperature other) => Kelvin.CompareTo(other.Kelvin);
    public bool Equals(Temperature other) => Kelvin.Equals(other.Kelvin);
    public override bool Equals(object? obj) => obj is Temperature t && Equals(t);
    public override int GetHashCode() => HashCode.Combine(Kelvin);
    public override string ToString() => $"{Kelvin.ToString("G", CultureInfo.InvariantCulture)} K";

    public static bool operator ==(Temperature a, Temperature b) => a.Equals(b);
    public static bool operator !=(Temperature a, Temperature b) => !(a == b);
    public static bool operator <(Temperature a, Temperature b) => a.Kelvin < b.Kelvin;
    public static bool operator >(Temperature a, Temperature b) => a.Kelvin > b.Kelvin;
    public static bool operator <=(Temperature a, Temperature b) => a.Kelvin <= b.Kelvin;
    public static bool operator >=(Temperature a, Temperature b) => a.Kelvin >= b.Kelvin;
    public static Temperature operator +(Temperature a, Temperature b) => new(a.Kelvin + b.Kelvin);
    public static Temperature operator -(Temperature a, Temperature b) => new(a.Kelvin - b.Kelvin);
    public static Temperature operator *(Temperature t, double factor) => new(t.Kelvin * factor);
    public static Temperature operator /(Temperature t, double divisor) => new(t.Kelvin / divisor);
    public static double operator /(Temperature a, Temperature b) => a.Kelvin / b.Kelvin;
}
