using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Services;

public sealed class TrainingService
{
    private readonly Course[] _courses;
    public TrainingService(Course[] courses) => _courses = courses;
    public Course[] GetAllCourses() => _courses;

    public Course? FindCourse(string code)
    {
        foreach (Course course in _courses)
            if (string.Equals(course.CourseCode, code.Trim(), StringComparison.OrdinalIgnoreCase)) return course;
        return null;
    }

    public Course? SearchTitle(string title)
    {
        foreach (Course course in _courses)
            if (course.Title.Contains(title.Trim(), StringComparison.OrdinalIgnoreCase)) return course;
        return null;
    }

    public void DisplayCourses()
    {
        Console.WriteLine("\nCODE   COURSE                         FEE       DAYS  TOTAL  ENROLLED  AVAILABLE");
        foreach (Course c in _courses)
            Console.WriteLine($"{c.CourseCode,-6} {c.Title,-30} ₹{c.Fee,7:F2} {c.DurationDays,5} {c.TotalSeats,6} {c.EnrolledCount,9} {c.AvailableSeats,10}");
    }

    public void SortByFee(bool ascending)
    {
        Course[] sorted = (Course[])_courses.Clone();
        Array.Sort(sorted, (a, b) => ascending ? a.Fee.CompareTo(b.Fee) : b.Fee.CompareTo(a.Fee));
        foreach (Course c in sorted) Console.WriteLine($"{c.CourseCode} | {c.Title} | ₹{c.Fee:F2}");
    }

    public CourseSummary CreateSummary(Course c) => new(c.CourseCode, c.Title, c.Fee, c.AvailableSeats);
}
