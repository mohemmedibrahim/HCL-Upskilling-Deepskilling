using TrainingManagementSystem.Models;
using TrainingManagementSystem.Services;

namespace TrainingManagementSystem.Utilities;

public sealed class MenuHandler
{
    private readonly TrainingService _training;
    private readonly LearnerService _learners;
    private readonly EnrollmentService _enrollments;
    private readonly PaymentService _payments;
    private readonly ReportService _reports;

    public MenuHandler(TrainingService training, LearnerService learners, EnrollmentService enrollments,
        PaymentService payments, ReportService reports)
    { _training = training; _learners = learners; _enrollments = enrollments; _payments = payments; _reports = reports; }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n===== TRAINING MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. List courses  2. Search courses  3. Sort courses by fee");
            Console.WriteLine("4. Register learner  5. List learners  6. Search learner");
            Console.WriteLine("7. Enroll in course  8. View enrollments  9. Cancel enrollment");
            Console.WriteLine("10. Fee breakdown  11. Simulated payment  12. Payment history");
            Console.WriteLine("13. Reports  14. Records/struct demo  0. Exit");
            int choice = InputValidator.ReadInt("Choose an option: ");
            try
            {
                switch (choice)
                {
                    case 1: _training.DisplayCourses(); break;
                    case 2: SearchCourses(); break;
                    case 3: _training.SortByFee(InputValidator.YesNo("Ascending order? (Y/N): ")); break;
                    case 4: RegisterLearner(); break;
                    case 5: _learners.DisplayAll(); break;
                    case 6:
                        Learner? learner = _learners.Find(InputValidator.Required("Learner ID: "));
                        Console.WriteLine(learner?.ToString() ?? "Learner not found.");
                        break;
                    case 7: Enroll(); break;
                    case 8: _enrollments.DisplayAll(); break;
                    case 9:
                        _enrollments.Cancel(InputValidator.ReadInt("Enrollment ID: "), out string cancelMessage);
                        Console.WriteLine(cancelMessage); break;
                    case 10: FeeBreakdown(); break;
                    case 11:
                        int id = InputValidator.ReadInt("Enrollment ID: ");
                        bool online = InputValidator.YesNo("Pay online? (Y/N; N = classroom counter): ");
                        _payments.Process(id, online, out string payMessage);
                        Console.WriteLine(payMessage); break;
                    case 12: _payments.DisplayHistory(); break;
                    case 13: _reports.DisplayReports(); break;
                    case 14: RecordDemo(); break;
                    case 0: running = false; Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid option. Choose 0–14."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Operation could not be completed: {ex.Message}"); }
        }
    }

    private void SearchCourses()
    {
        string query = InputValidator.Required("Enter course code or part of title: ");
        Course? c = _training.FindCourse(query) ?? _training.SearchTitle(query);
        Console.WriteLine(c is null ? "No matching course found." :
            $"{c.CourseCode} | {c.Title} | ₹{c.Fee:F2} | Available seats: {c.AvailableSeats}");
    }

    private void RegisterLearner()
    {
        var learner = new Learner(InputValidator.Required("Learner ID: "), InputValidator.Required("Name: "),
            InputValidator.Required("Contact number (10-15 digits): "), InputValidator.Required("Email: "));
        _learners.Register(learner, out string message);
        Console.WriteLine(message);
    }

    private void Enroll()
    {
        string learnerId = InputValidator.Required("Learner ID: ");
        string code = InputValidator.Required("Course code: ");
        DateTime start = InputValidator.ReadDate("Course start date (yyyy-mm-dd): ");
        bool online = InputValidator.YesNo("Online session? (Y/N; N = classroom): ");
        bool group = InputValidator.YesNo("Eligible for group discount? (Y/N): ");
        if (_enrollments.Create(learnerId, code, start, online, group, out Enrollment? e, out string message))
        {
            Console.WriteLine(message);
            Console.WriteLine($"Base ₹{e!.BaseFee:F2} - Discount ₹{e.DiscountAmount:F2} + Session ₹{e.SessionCharge:F2} = Final ₹{e.FinalFee:F2}");
        }
        else Console.WriteLine(message);
    }

    private void FeeBreakdown()
    {
        Enrollment? e = _enrollments.Find(InputValidator.ReadInt("Enrollment ID: "));
        if (e is null) { Console.WriteLine("Enrollment not found."); return; }
        Console.WriteLine($"Base fee       : ₹{e.BaseFee:F2}");
        Console.WriteLine($"Discount       : ₹{e.DiscountAmount:F2}");
        Console.WriteLine($"Session charge : ₹{e.SessionCharge:F2}");
        Console.WriteLine($"Final fee      : ₹{e.FinalFee:F2}");
    }

    private void RecordDemo()
    {
        Course c = _training.GetAllCourses()[0];
        CourseSummary a = _training.CreateSummary(c);
        CourseSummary b = new(a.CourseCode, a.Title, a.Fee, a.AvailableSeats);
        CourseSummary modified = a with { AvailableSeats = a.AvailableSeats + 1 };
        Console.WriteLine($"Record equality: {a == b}");
        Console.WriteLine($"Original seats: {a.AvailableSeats}; modified copy seats: {modified.AvailableSeats}");
        SessionDuration original = new(c.DurationDays);
        SessionDuration copy = original;
        copy = new SessionDuration(copy.Days + 1);
        Console.WriteLine($"Struct value copy: original {original}; changed copy {copy}");
    }
}
