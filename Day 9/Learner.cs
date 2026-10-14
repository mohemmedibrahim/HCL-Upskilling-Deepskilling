namespace TrainingManagementSystem.Models;

public sealed class Learner
{
    public string LearnerId { get; }
    public string Name { get; }
    public string ContactNumber { get; }
    public string Email { get; }

    public Learner(string learnerId, string name, string contactNumber, string email)
    {
        LearnerId = learnerId.Trim();
        Name = name.Trim();
        ContactNumber = contactNumber.Trim();
        Email = email.Trim();
    }

    public override string ToString() => $"{LearnerId,-12} {Name,-24} {ContactNumber,-16} {Email}";
}
