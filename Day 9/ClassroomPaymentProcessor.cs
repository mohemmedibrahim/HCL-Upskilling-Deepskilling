namespace TrainingManagementSystem.Payments;

public sealed class ClassroomPaymentProcessor : IPaymentProcessor
{
    string IPaymentProcessor.MethodName => "Classroom counter";
    bool IPaymentProcessor.Process(decimal amount)
    {
        Console.WriteLine($"Simulating classroom-counter payment of ₹{amount:F2}...");
        return PaymentSimulation.AskForResult();
    }
}
