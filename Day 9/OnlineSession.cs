using TrainingManagementSystem.Models;
namespace TrainingManagementSystem.Sessions;

public sealed class OnlineSession : CourseSession
{
    public OnlineSession(string code, DateTime start, SessionDuration duration) : base(code, start, duration) { }
    public override decimal CalculateSessionCharge() => 200m;
}
