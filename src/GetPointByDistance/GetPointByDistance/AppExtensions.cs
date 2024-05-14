using System.Globalization;

namespace GetPointByDistance;
using static Math;

public static class AppExtensions
{
    public const int DoubleErrorDigits = 15;

    public static double DoubleErrorRound(this double d, int digits = DoubleErrorDigits) => 
        Round(d, digits);

    private static char DecimalSeparator => 
        CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

    private static string TrimZeros(string number) => number.Contains(DecimalSeparator)
        ? number.TrimEnd('0', DecimalSeparator)
        : number;

    public static string ToStringEx(this (decimal x, decimal y, decimal z) tuple) =>
        "{ " +
        $"x = {TrimZeros(tuple.x.ToString(CultureInfo.CurrentCulture))}, " +
        $"y = {TrimZeros(tuple.y.ToString(CultureInfo.CurrentCulture))}, " +
        $"z = {TrimZeros(tuple.z.ToString(CultureInfo.CurrentCulture))} " +
        "}";
}