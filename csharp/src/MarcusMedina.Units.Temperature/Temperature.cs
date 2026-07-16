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
    /// <summary>
    /// Adding two absolute temperatures together is physically meaningless — 100°C + 10°C is not 110°C,
    /// since Kelvin values don't compose that way for an affine scale. If you're modeling heat transfer
    /// (e.g. a hot coffee cooled by a room-temperature spoon), you need a weighted blend based on mass
    /// and heat capacity, not a raw sum — this struct alone can't do that. Use <see cref="Kelvin"/>
    /// directly if you specifically need this arithmetic anyway.
    /// </summary>
    [Obsolete("Adding two absolute Temperature values is physically meaningless — 100°C + 10°C is not 110°C. Use the Kelvin property directly if you really need this.")]
    public static Temperature operator +(Temperature a, Temperature b) => new(a.Kelvin + b.Kelvin);
    public static Temperature operator -(Temperature a, Temperature b) => new(a.Kelvin - b.Kelvin);
    public static Temperature operator *(Temperature t, double factor) => new(t.Kelvin * factor);
    public static Temperature operator /(Temperature t, double divisor) => new(t.Kelvin / divisor);
    public static double operator /(Temperature a, Temperature b) => a.Kelvin / b.Kelvin;
}
