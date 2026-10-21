namespace EventManagementSystem
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = "";
        public string Venue { get; set; } = "";
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
        public decimal RegistrationFee { get; set; }

        public bool isArchieved {  get; set;}

        public Event() { }

        public Event(int id, string name, string venue, DateTime date, int capacity, decimal fee)
        {
            EventId = id;
            EventName = name;
            Venue = venue;
            EventDate = date;
            Capacity = capacity;
            RegistrationFee = fee;
        }

        public override string ToString()
        {
            return $"ID: {EventId}| Name: {EventName} |"+ $"Venue: {Venue} | Date: {EventDate:dd-MM-yyyy} | " + $"Capacity: {Capacity} | Fee: {RegistrationFee}";

        }
    }
}