namespace EventRegistrationSystem.Models
{
    public enum RegistrationStatus
    {
        Registered, Cancelled,Attended
    }

    public class Registration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public RegistrationStatus Status { get; set; } = RegistrationStatus.Registered;
        public decimal AmountPaid { get; set; }

        public Registration()
        {
        }
        public Registration(int registrationId, int eventId, int participantId, DateTime registrationDate, decimal amountPaid)
        {
            RegistrationId = registrationId;
            EventId = eventId;
            ParticipantId = participantId;
            RegistrationDate = registrationDate;
            Status = RegistrationStatus.Registered;
            AmountPaid = amountPaid;
        }
        public override string ToString()
        {
            return $"Registration ID: {RegistrationId} | " + $"Event ID: {EventId} | " + $"Participant ID: {ParticipantId} | " +  $"Date: {RegistrationDate:dd-MM-yyyy} | " +
                   $"Status: {Status} | " + $"Amount Paid: {AmountPaid}";
        }
    }
}