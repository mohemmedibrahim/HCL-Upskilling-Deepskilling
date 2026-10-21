using EventManagementSystem;
using EventRegistrationSystem.Models;
using System.Xml.Linq;
namespace EventRegistrationSystem.Services
{
    public class ParticipantService
    {

        public Participant? GetParticipantById(int participantId)
        {
            return participants.Find(p => p.ParticipantId == participantId);
        }
        private List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant p)
        {
            participants.Add(p);
            Console.WriteLine("Participant added successfully!");
        }

        public void ViewParticipants()
        {
            if (participants.Count == 0)
            {
                Console.WriteLine("No Participants");
                return;
            }

            foreach (Participant p in participants)
            {
                Console.WriteLine(p);
            }
        }

        public void SearchParticipants(int id)
        {
            Participant? p = participants.Find(x => x.ParticipantId == id);

            if (p == null)
                Console.WriteLine("Participant Not Found");
            else
                Console.WriteLine(p);
        }

        public void DeleteParticipant(int id)
        {
            Participant? p = participants.Find(x => x.ParticipantId == id);

            if (p == null)
            {
                Console.WriteLine("Participant Not Found");
                return;
            }

            participants.Remove(p);
            Console.WriteLine("Participant deleted successfully!");
        }
    }
}


