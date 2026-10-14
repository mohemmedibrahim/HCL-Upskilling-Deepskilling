using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Services;

public sealed class LearnerService
{
    private readonly Dictionary<string, Learner> _learners = new(StringComparer.OrdinalIgnoreCase);
    public IReadOnlyDictionary<string, Learner> Learners => _learners;

    public bool Register(Learner learner, out string message)
    {
        if (string.IsNullOrWhiteSpace(learner.LearnerId) || string.IsNullOrWhiteSpace(learner.Name))
        { message = "Learner ID and name are required."; return false; }
        if (learner.ContactNumber.Length is < 10 or > 15 || !learner.ContactNumber.All(char.IsDigit))
        { message = "Contact number must contain 10–15 digits."; return false; }
        if (!learner.Email.Contains('@') || !learner.Email.Contains('.'))
        { message = "Enter a valid email address."; return false; }
        if (_learners.ContainsKey(learner.LearnerId))
        { message = "That learner ID is already registered."; return false; }
        _learners.Add(learner.LearnerId, learner);
        message = "Learner registered successfully.";
        return true;
    }

    public Learner? Find(string id) => _learners.TryGetValue(id.Trim(), out Learner? learner) ? learner : null;

    public void DisplayAll()
    {
        if (_learners.Count == 0) { Console.WriteLine("No learners registered yet."); return; }
        Console.WriteLine("\nID           NAME                     CONTACT          EMAIL");
        foreach (Learner learner in _learners.Values) Console.WriteLine(learner);
    }
}
