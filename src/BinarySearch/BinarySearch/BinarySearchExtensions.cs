namespace BinarySearch;

public static class BinarySearchExtensions
{
    public static int BinarySearchWithRotation<T>(this T[] array, T key)
        where T : IComparable =>
        BinarySearch(array, key, GetPivot(array), array.Length);

    private static int BinarySearch<T>(T[] array, T key, int pivot, int length) 
        where T : IComparable
    {
        var left = 0;
        var right = length - 1;

        while (left <= right)
        {
            var middle = (left + right) >> 1;
            var actualMiddle = (middle + pivot) % length;

            switch (array[actualMiddle].CompareTo(key))
            {
                case < 0:
                    left = middle + 1;
                    break;
                case > 0:
                    right = middle - 1;
                    break;
                default:
                    return actualMiddle;
            }
        }

        return -1;
    }

    private static int GetPivot<T>(T[] array) 
        where T : IComparable
    {
        var start = 0;
        var end = array.Length - 1;

        while (start < end)
        {
            var mid = (start + end) >> 1;

            if (array[mid].CompareTo(array[end]) < 0)
                end = mid;
            else
                start = mid + 1;
        }

        return start;
    }
}
