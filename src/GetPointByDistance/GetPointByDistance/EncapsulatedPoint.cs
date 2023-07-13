using static DecimalMath.DecimalEx;

namespace GetPointByDistance;

public readonly record struct EncapsulatedPoint()
{
    public decimal X { private get; init; } 
    public decimal Y { private get; init; }
    public decimal Z { private get; init; }

    // Заметим, что этот метод нам не пригодился
    public decimal Distance(decimal x = 0, decimal y = 0, decimal z = 0) => Sqrt(DistanceSquared(x, y, z));

    // 
    public decimal DistanceSquared(decimal x = 0, decimal y = 0, decimal z = 0) => 
        Pow(X - x, 2) + Pow(Y - y, 2) + Pow(Z - z, 2);
}