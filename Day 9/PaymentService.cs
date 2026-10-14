using TrainingManagementSystem.Models;
using TrainingManagementSystem.Payments;

namespace TrainingManagementSystem.Services;

public sealed class PaymentService
{
    private readonly EnrollmentService _enrollments;
    private readonly List<Payment> _payments = [];
    private int _nextPaymentId = 1;
    public IReadOnlyList<Payment> Payments => _payments;
    public PaymentService(EnrollmentService enrollments) => _enrollments = enrollments;

    public bool Process(int enrollmentId, bool online, out string message)
    {
        Enrollment? e = _enrollments.Find(enrollmentId);
        if (e is null) { message = "Enrollment ID not found."; return false; }
        if (e.Status == EnrollmentStatus.Cancelled) { message = "Cannot pay for a cancelled enrollment."; return false; }
        if (e.IsPaid) { message = "This enrollment is already paid."; return false; }

        IPaymentProcessor processor = online ? new OnlinePaymentProcessor() : new ClassroomPaymentProcessor();
        bool success = processor.Process(e.FinalFee);
        _payments.Add(new Payment
        {
            PaymentId = _nextPaymentId++, EnrollmentId = enrollmentId, Amount = e.FinalFee,
            PaymentDate = DateTime.Now, Status = success ? PaymentStatus.Successful : PaymentStatus.Failed,
            Method = processor.MethodName
        });
        if (success) e.IsPaid = true;
        message = success ? "Payment successful; enrollment marked as paid." : "Payment failed; attempt recorded.";
        return success;
    }

    public void DisplayHistory()
    {
        if (_payments.Count == 0) { Console.WriteLine("No payment attempts recorded."); return; }
        foreach (Payment p in _payments)
            Console.WriteLine($"Payment {p.PaymentId} | Enrollment {p.EnrollmentId} | ₹{p.Amount:F2} | {p.Method} | {p.Status} | {p.PaymentDate:g}");
    }
}
