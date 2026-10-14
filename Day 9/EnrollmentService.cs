using TrainingManagementSystem.Models;
using TrainingManagementSystem.Sessions;

namespace TrainingManagementSystem.Services;

public sealed class EnrollmentService
{
    private readonly TrainingService _training;
    private readonly LearnerService _learners;
    private readonly FeeCalculator _fees;
    private readonly List<Enrollment> _enrollments = [];
    private int _nextId = 1001;
    public List<Enrollment> Enrollments => _enrollments;

    public EnrollmentService(TrainingService training, LearnerService learners, FeeCalculator fees)
    { _training = training; _learners = learners; _fees = fees; }

    public Enrollment? Find(int id)
    {
        foreach (Enrollment e in _enrollments) if (e.EnrollmentId == id) return e;
        return null;
    }

    public bool Create(string learnerId, string courseCode, DateTime startDate, bool online, bool groupDiscount,
        out Enrollment? created, out string message)
    {
        created = null;
        if (_learners.Find(learnerId) is null) { message = "Learner ID was not found."; return false; }
        Course? course = _training.FindCourse(courseCode);
        if (course is null) { message = "Course code was not found."; return false; }
        foreach (Enrollment e in _enrollments)
            if (e.LearnerId.Equals(learnerId, StringComparison.OrdinalIgnoreCase) &&
                e.CourseCode.Equals(courseCode, StringComparison.OrdinalIgnoreCase) && e.Status == EnrollmentStatus.Active)
            { message = "This learner already has an active enrollment for that course."; return false; }
        if (course.AvailableSeats <= 0) { message = "This course is full; no seats are available."; return false; }

        CourseSession session = online
            ? new OnlineSession(course.CourseCode, startDate, new SessionDuration(course.DurationDays))
            : new ClassroomSession(course.CourseCode, startDate, new SessionDuration(course.DurationDays));
        bool earlyBird = (startDate.Date - DateTime.Today).TotalDays >= 14;
        var fee = _fees.Calculate(course.Fee, session.CalculateSessionCharge(), earlyBird, groupDiscount);
        created = new Enrollment
        {
            EnrollmentId = _nextId++, LearnerId = learnerId.Trim(), CourseCode = course.CourseCode,
            EnrollmentDate = DateTime.Now, CourseStartDate = startDate, BaseFee = fee.BaseFee,
            DiscountAmount = fee.TotalDiscount, SessionCharge = session.CalculateSessionCharge(), FinalFee = fee.FinalFee
        };
        _enrollments.Add(created);
        course.EnrolledCount++;
        message = $"Enrollment successful. Reference: {created.EnrollmentId}";
        return true;
    }

    public bool Cancel(int id, out string message)
    {
        Enrollment? e = Find(id);
        if (e is null) { message = "Enrollment ID not found."; return false; }
        if (e.Status == EnrollmentStatus.Cancelled) { message = "This enrollment is already cancelled."; return false; }
        if (e.Status != EnrollmentStatus.Active) { message = "Only active enrollments can be cancelled."; return false; }
        e.Status = EnrollmentStatus.Cancelled;
        Course? course = _training.FindCourse(e.CourseCode);
        if (course is not null && course.EnrolledCount > 0) course.EnrolledCount--;
        message = $"Enrollment {id} cancelled. One seat has been released.";
        return true;
    }

    public void DisplayAll()
    {
        if (_enrollments.Count == 0) { Console.WriteLine("No enrollment records found."); return; }
        Console.WriteLine("\nID     LEARNER      COURSE   DATE       STATUS     FINAL FEE  PAYMENT");
        foreach (Enrollment e in _enrollments) Console.WriteLine(e);
    }
}
