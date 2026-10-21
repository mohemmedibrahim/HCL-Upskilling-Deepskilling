namespace EventManagementSystem
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public Participant() { }

        public Participant(int id, string name, string email, string phone)
        {
            ParticipantId = id;
            FullName = name;
            Email = email;
            PhoneNumber = phone;
        }
        public override string ToString()
        {
            return $"ID: {ParticipantId} | Name: {FullName} | " + $"Email: {Email} | Phone: {PhoneNumber}";
        }

    }
}

    
    
    

    