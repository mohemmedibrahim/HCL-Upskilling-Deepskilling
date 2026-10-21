using EventManagementSystem;
using EventRegistrationSystem.Models;
using System.Xml.Linq;

namespace EventRegistrationSystem.Services
{
    public class EventService
    {
        public Event? GetEventById(int eventId)
        {
            return events.Find(e => e.EventId == eventId);
        }
        private List<Event> events = new List<Event>();

        public void AddEvent(Event e)
        {
            events.Add(e);
            Console.WriteLine("Event added successfully!");
        }

        public void ViewEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return;
            }

            foreach (Event e in events)
            {
                Console.WriteLine(e);
            }
        }

        public void SearchEvent(int id)
        {
            Event? e = events.Find(x => x.EventId == id);

            if (e == null)
                Console.WriteLine("Event not found.");
            else
                Console.WriteLine(e);
        }

        public void DeleteEvent(int id)
        {
            Event? e = events.Find(x => x.EventId == id);

            if (e == null)
            {
                Console.WriteLine("Event not found.");
                return;
            }

            events.Remove(e);
            Console.WriteLine("Event deleted successfully!");
        }
    }
}