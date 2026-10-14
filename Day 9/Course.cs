namespace TrainingManagementSystem.Models;

public sealed class Course
{
    public string CourseCode { get; }
    public string Title { get; }
    public decimal Fee { get; }
    public int DurationDays { get; }
    public int TotalSeats { get; }
    public int EnrolledCount { get; set; }
    public int AvailableSeats => TotalSeats - EnrolledCount;

    public Course(string courseCode, string title, decimal fee, int durationDays, int totalSeats)
    {
        if (string.IsNullOrWhiteSpace(courseCode) || string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Course code and title are required.");
        if (fee < 0 || durationDays <= 0 || totalSeats <= 0)
            throw new ArgumentException("Fee must be non-negative and duration/capacity must be positive.");
        CourseCode = courseCode.Trim();
        Title = title.Trim();
        Fee = fee;
        DurationDays = durationDays;
        TotalSeats = totalSeats;
    }
}
