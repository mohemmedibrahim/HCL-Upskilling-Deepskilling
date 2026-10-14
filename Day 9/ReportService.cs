using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Services;

public sealed class ReportService
{
    private readonly TrainingService _training;
    private readonly EnrollmentService _enrollments;
    private readonly PaymentService _payments;
    public ReportService(TrainingService training, EnrollmentService enrollments, PaymentService payments)
    { _training = training; _enrollments = enrollments; _payments = payments; }

    public void DisplayReports()
    {
        Console.WriteLine("\n--- Course Occupancy ---");
        foreach (Course c in _training.GetAllCourses())
        {
            decimal pct = c.TotalSeats == 0 ? 0 : (decimal)c.EnrolledCount / c.TotalSeats * 100m;
            Console.WriteLine($"{c.CourseCode}: total {c.TotalSeats}, occupied {c.EnrolledCount}, available {c.AvailableSeats}, occupancy {pct:F1}%");
        }

        decimal expected = 0m;
        foreach (Enrollment e in _enrollments.Enrollments)
            if (e.Status == EnrollmentStatus.Active) expected += e.FinalFee;
        Console.WriteLine($"Expected fees from active enrollments (including unpaid): ₹{expected:F2}");

        int successful = 0, failed = 0;
        decimal collected = 0m;
        foreach (Payment p in _payments.Payments)
        {
            if (p.Status == PaymentStatus.Successful) { successful++; collected += p.Amount; }
            else if (p.Status == PaymentStatus.Failed) failed++;
        }
        Console.WriteLine($"Payment attempts: successful {successful}, failed {failed}; collected ₹{collected:F2}");
        Console.WriteLine("--- Active Enrollment by Course ---");
        foreach (Course c in _training.GetAllCourses())
            Console.WriteLine($"{c.CourseCode}: {c.EnrolledCount} active enrollment(s)" + (c.AvailableSeats == 0 ? " [FULL]" : ""));
    }
}
