namespace TrainingManagementSystem.Models;

public readonly struct SessionDuration
{
    public int Days { get; }
    public SessionDuration(int days)
    {
        if (days <= 0) throw new ArgumentOutOfRangeException(nameof(days));
        Days = days;
    }
    public override string ToString() => $"{Days} day(s)";
}
