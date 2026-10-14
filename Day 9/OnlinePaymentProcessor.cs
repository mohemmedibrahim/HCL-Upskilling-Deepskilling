namespace TrainingManagementSystem.Payments;

public sealed class OnlinePaymentProcessor : IPaymentProcessor
{
    public string MethodName => "Online";
    public bool Process(decimal amount)
    {
        Console.WriteLine($"Simulating online payment of ₹{amount:F2}...");
        return PaymentSimulation.AskForResult();
    }
}
