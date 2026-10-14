namespace TrainingManagementSystem.Utilities;

public static class InputValidator
{
    public static string Required(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(value)) return value;
            Console.WriteLine("Input cannot be empty.");
        }
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value)) return value;
            Console.WriteLine("Enter a valid whole number.");
        }
    }

    public static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime value)) return value.Date;
            Console.WriteLine("Enter a valid date, for example 2026-11-20.");
        }
    }

    public static bool YesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine()?.Trim();
            if (string.Equals(value, "Y", StringComparison.OrdinalIgnoreCase)) return true;
            if (string.Equals(value, "N", StringComparison.OrdinalIgnoreCase)) return false;
            Console.WriteLine("Enter Y or N.");
        }
    }
}
