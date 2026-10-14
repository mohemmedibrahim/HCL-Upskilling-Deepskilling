namespace TrainingManagementSystem.Models;

public sealed class Payment
{
    public int PaymentId { get; init; }
    public int EnrollmentId { get; init; }
    public decimal Amount { get; init; }
    public DateTime PaymentDate { get; init; }
    public PaymentStatus Status { get; init; }
    public string Method { get; init; } = "";
}
