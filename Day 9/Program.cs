using TrainingManagementSystem.Models;
using TrainingManagementSystem.Services;
using TrainingManagementSystem.Utilities;

namespace TrainingManagementSystem;

internal static class Program
{
    private static void Main()
    {
        Course[] courses =
        [
            new Course("CS101", "C# Fundamentals", 4500m, 20, 20),
            new Course("PY201", "Python Programming", 5000m, 25, 18),
            new Course("DB301", "SQL and Database Design", 3500m, 15, 20),
            new Course("WD401", "Web Development", 6500m, 30, 15),
            new Course("AI501", "Introduction to AI", 8000m, 35, 12)
        ];

        var training = new TrainingService(courses);
        var learners = new LearnerService();
        var fees = new FeeCalculator();
        var enrollments = new EnrollmentService(training, learners, fees);
        var payments = new PaymentService(enrollments);
        var reports = new ReportService(training, enrollments, payments);
        new MenuHandler(training, learners, enrollments, payments, reports).Run();
    }
}
