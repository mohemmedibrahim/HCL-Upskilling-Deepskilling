namespace TrainingManagementSystem.Payments;
public interface IPaymentProcessor
{
    string MethodName { get; }
    bool Process(decimal amount);
}
