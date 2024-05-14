using GetPointByDistance;
using static DecimalMath.DecimalEx;

/*
 * Из условия задачи нельзя злоупотреблять методами получения расстояния,
 * однако других методов у нас нет и имеем 3 неизвестных - x, y, z.
 * Поэтому минимально необходимо вызвать наши методы 3 раза, чтобы получить 3 у-ния с 3 неизв-ми.
 *
 * x^2 + y^2 + z^2 = r^2 - расстояние до точки - (0, 0, 0)
 * x^2 + (y - 1)^2 + z^2 = yS^2. - расстояние до точки - (0, 1, 0)
 * x^2 + y^2 + (z - r)^2 = zS^2. - расстояние до точки - (0, 0, 1)
 *
 * вычитаем из первого уравнения второе:
 * y^2 - y^2 + 2y - 1 = r^2 - yS^2
 * =>
 * y = (r^2 - yS^2 + 1) / 2
 *
 * (аналогично)=>
 * z = (r^2 - zS^2 + 1) / 2
 *
 * (подставляем в первое уравнение уже найденные y, z)=>
 * x = sqrt(r^2 - y^2 - z^2) - тут получим два решения: +/- (!)
 */

static (decimal, decimal, decimal) GetPoint(EncapsulatedPoint point)
{
    var rPow2 = point.DistanceSquared();
    var ySPow2 = point.DistanceSquared(y: 1);
    var zSPow2 = point.DistanceSquared(z: 1);

    var y = (rPow2 - ySPow2 + 1) / 2;
    var z = (rPow2 - zSPow2 + 1) / 2;
    var x = Sqrt(rPow2 - y * y - z * z);

    return point == new EncapsulatedPoint() { X = x, Y = y, Z = z }
        ? new ValueTuple<decimal, decimal, decimal>(x, y, z) 
        : new ValueTuple<decimal, decimal, decimal>((-x), y, z);
}

decimal x = -0.000_000_000_000_22m, y = 0.000_000_000_000_2_222m, z = -0.000_000_000_000_1_111m;
var point = new EncapsulatedPoint() { X = x, Y = y, Z = z };

Console.WriteLine("Искомая точка:    " + new { x, y, z });
Console.WriteLine("Полученная точка: " + GetPoint(point).ToStringEx());

Console.WriteLine("*****");

x = 20_000_000_000_000;
y = 20_000_000_000_000;
z = -10_000_000_000_000;
point = new EncapsulatedPoint() { X = x, Y = y, Z = z };

Console.WriteLine("Искомая точка:    " + new { x, y, z });
Console.WriteLine("Полученная точка: " + GetPoint(point).ToStringEx());

Console.ReadLine();