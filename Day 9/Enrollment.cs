namespace TrainingManagementSystem.Models;

public sealed class Enrollment
{
    public int EnrollmentId { get; init; }
    public string LearnerId { get; init; } = "";
    public string CourseCode { get; init; } = "";
    public DateTime EnrollmentDate { get; init; }
    public DateTime CourseStartDate { get; init; }
    public decimal BaseFee { get; init; }
    public decimal DiscountAmount { get; init; }
    public decimal SessionCharge { get; init; }
    public decimal FinalFee { get; init; }
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
    public bool IsPaid { get; set; }

    public override string ToString() =>
        $"{EnrollmentId,-6} {LearnerId,-12} {CourseCode,-8} {EnrollmentDate:yyyy-MM-dd} {Status,-10} ₹{FinalFee,9:F2} {(IsPaid ? "Paid" : "Unpaid")}";
}
