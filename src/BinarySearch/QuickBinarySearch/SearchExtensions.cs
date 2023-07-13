namespace QuickBinarySearch;

public static class SearchExtensions
{
    public static int BinarySearchWithRotation<T>(this T[] array, int key)
        where T : IComparable
    {
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            var middle = (left + right) >> 1;

            if (array[middle].CompareTo(key) == 0) return middle;

            if (array[left].CompareTo(array[middle]) <= 0)
            {
                if (key.CompareTo(array[middle]) > 0 || key.CompareTo(array[left]) < 0)
                    left = middle + 1;
                else right = middle - 1;
                continue;
            }

            if (key.CompareTo(array[middle]) < 0 || key.CompareTo(array[right]) > 0)
                right = middle - 1;
            else left = middle + 1;
        }

        return -1;
    }
}