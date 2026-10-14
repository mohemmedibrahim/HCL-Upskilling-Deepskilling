namespace TrainingManagementSystem.Payments;

internal static class PaymentSimulation
{
    public static bool AskForResult()
    {
        Console.Write("Simulate success? (Y/N): ");
        return string.Equals(Console.ReadLine()?.Trim(), "Y", StringComparison.OrdinalIgnoreCase);
    }
}
