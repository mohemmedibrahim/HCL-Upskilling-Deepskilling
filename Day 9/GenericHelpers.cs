namespace TrainingManagementSystem.Utilities;

public static class GenericHelpers
{
    public static void DisplayItems<T>(IEnumerable<T> items)
    {
        foreach (T item in items) Console.WriteLine(item);
    }

    public static T? FindFirst<T>(IEnumerable<T> items, Func<T, bool> matches)
    {
        foreach (T item in items) if (matches(item)) return item;
        return default;
    }
}
