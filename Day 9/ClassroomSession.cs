using TrainingManagementSystem.Models;
namespace TrainingManagementSystem.Sessions;

public sealed class ClassroomSession : CourseSession
{
    public ClassroomSession(string code, DateTime start, SessionDuration duration) : base(code, start, duration) { }
    public override decimal CalculateSessionCharge() => 800m;
}
