using EventManagementSystem;
using EventRegistrationSystem.Models;
using EventRegistrationSystem.Services;

namespace EventRegistrationSystem.Services
{
    public class RegistrationService
    {


        private List<Registration> registrations = new List<Registration>();

        private EventService eventService;
        private ParticipantService participantService;

        public RegistrationService(
            EventService eventService,
            ParticipantService participantService)
        {
            this.eventService = eventService;
            this.participantService = participantService;
        }

        public void RegisterParticipant(
            int registrationId,
            int eventId,
            int participantId,
            decimal amountPaid)
        {
            Event? e = eventService.GetEventById(eventId);
            Participant? p = participantService.GetParticipantById(participantId);

            if (e == null)
            {
                Console.WriteLine("Event not found.");
                return;
            }

            if (p == null)
            {
                Console.WriteLine("Participant not found.");
                return;
            }

            if (registrations.Any(r =>
                r.EventId == eventId &&
                r.ParticipantId == participantId &&
                r.Status != RegistrationStatus.Cancelled))
            {
                Console.WriteLine("Participant already registered.");
                return;
            }

            int activeCount = registrations.Count(r =>
                r.EventId == eventId &&
                r.Status != RegistrationStatus.Cancelled);

            if (activeCount >= e.Capacity)
            {
                Console.WriteLine("Event capacity is full.");
                return;
            }

            if (registrations.Any(r => r.RegistrationId == registrationId))
            {
                Console.WriteLine("Registration ID already exists.");
                return;
            }

            if (registrationId <= 0)
            {
                Console.WriteLine("Invalid Registration ID.");
                return;
            }

            if (amountPaid < 0 || amountPaid > e.RegistrationFee)
            {
                Console.WriteLine("Invalid payment amount.");
                return;
            }

            Registration registration = new Registration(
                registrationId,
                eventId,
                participantId,
                DateTime.Now,
                amountPaid);

            registrations.Add(registration);

            Console.WriteLine("Registration successful!");
        }

        public void ViewRegistrations()
        {
            if (registrations.Count == 0)
            {
                Console.WriteLine("No registrations available.");
                return;
            }

            foreach (Registration r in registrations)
            {
                Console.WriteLine(r);
            }
        }

        public void SearchRegistration(int registrationId)
        {
            Registration? r = registrations.Find(
                x => x.RegistrationId == registrationId);

            if (r == null)
            {
                Console.WriteLine("Registration not found.");
                return;
            }

            Console.WriteLine(r);
        }

        public void CancelRegistration(int registrationId)
        {
            Registration? r = registrations.Find(
                x => x.RegistrationId == registrationId);

            if (r == null)
            {
                Console.WriteLine("Registration not found.");
                return;
            }

            if (r.Status == RegistrationStatus.Cancelled)
            {
                Console.WriteLine("Registration already cancelled.");
                return;
            }

            r.Status = RegistrationStatus.Cancelled;

            Console.WriteLine("Registration cancelled successfully.");
        }

        public void MarkAttendance(int registrationId)
        {
            Registration? r = registrations.Find(
                x => x.RegistrationId == registrationId);

            if (r == null)
            {
                Console.WriteLine("Registration not found.");
                return;
            }

            if (r.Status != RegistrationStatus.Registered)
            {
                Console.WriteLine("Only registered participants can attend.");
                return;
            }

            r.Status = RegistrationStatus.Attended;

            Console.WriteLine("Attendance marked successfully.");
        }
    }
}