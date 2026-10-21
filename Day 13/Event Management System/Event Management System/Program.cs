using EventManagementSystem;
using EventRegistrationSystem.Models;
using EventRegistrationSystem.Services;

EventService service = new EventService();
ParticipantService serv = new ParticipantService();

RegistrationService registrationService =
    new RegistrationService(service, serv);

while (true)
{
    Console.WriteLine("\n===== EVENT REGISTRATION SYSTEM =====");
    Console.WriteLine("1. Add Event");
    Console.WriteLine("2. View Events");
    Console.WriteLine("3. Search Event");
    Console.WriteLine("4. Delete Event");
    Console.WriteLine("5. Add Participant");
    Console.WriteLine("6. View Participants");
    Console.WriteLine("7. Search Participant");
    Console.WriteLine("8. Delete Participant");
    Console.WriteLine("9. Register Participant");
    Console.WriteLine("10. View Registrations");
    Console.WriteLine("11. Search Registration");
    Console.WriteLine("12. Cancel Registration");
    Console.WriteLine("13. Mark Attendance");
    Console.WriteLine("14. Exit");
    Console.Write("Enter choice: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid choice! Enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            {
                Event e = new Event();

                Console.Write("Enter Event ID: ");
                if (!int.TryParse(Console.ReadLine(), out int eventId))
                {
                    Console.WriteLine("Invalid Event ID.");
                    break;
                }
                e.EventId = eventId;

                Console.Write("Enter Event Name: ");
                e.EventName = Console.ReadLine() ?? "";

                Console.Write("Enter Venue: ");
                e.Venue = Console.ReadLine() ?? "";

                Console.Write("Enter Event Date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
                {
                    Console.WriteLine("Invalid date.");
                    break;
                }
                e.EventDate = eventDate;

                Console.Write("Enter Capacity: ");
                if (!int.TryParse(Console.ReadLine(), out int capacity))
                {
                    Console.WriteLine("Invalid capacity.");
                    break;
                }
                e.Capacity = capacity;

                Console.Write("Enter Registration Fee: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal fee))
                {
                    Console.WriteLine("Invalid fee.");
                    break;
                }
                e.RegistrationFee = fee;

                service.AddEvent(e);
                break;
            }

        case 2:
            service.ViewEvents();
            break;

        case 3:
            Console.Write("Enter Event ID: ");
            if (int.TryParse(Console.ReadLine(), out int searchEventId))
                service.SearchEvent(searchEventId);
            else
                Console.WriteLine("Invalid Event ID.");
            break;

        case 4:
            Console.Write("Enter Event ID: ");
            if (int.TryParse(Console.ReadLine(), out int deleteEventId))
                service.DeleteEvent(deleteEventId);
            else
                Console.WriteLine("Invalid Event ID.");
            break;

        case 5:
            {
                Participant p = new Participant();

                Console.Write("Enter Participant ID: ");
                if (!int.TryParse(Console.ReadLine(), out int participantId))
                {
                    Console.WriteLine("Invalid Participant ID.");
                    break;
                }
                p.ParticipantId = participantId;

                Console.Write("Enter Full Name: ");
                p.FullName = Console.ReadLine() ?? "";

                Console.Write("Enter Email: ");
                p.Email = Console.ReadLine() ?? "";

                Console.Write("Enter Phone Number: ");
                p.PhoneNumber = Console.ReadLine() ?? "";

                serv.AddParticipant(p);
                break;
            }

        case 6:
            serv.ViewParticipants();
            break;

        case 7:
            Console.Write("Enter Participant ID: ");
            if (int.TryParse(Console.ReadLine(), out int searchParticipantId))
                serv.SearchParticipants(searchParticipantId);
            else
                Console.WriteLine("Invalid Participant ID.");
            break;

        case 8:
            Console.Write("Enter Participant ID: ");
            if (int.TryParse(Console.ReadLine(), out int deleteParticipantId))
                serv.DeleteParticipant(deleteParticipantId);
            else
                Console.WriteLine("Invalid Participant ID.");
            break;

        case 9:
            {
                Console.Write("Enter Registration ID: ");
                if (!int.TryParse(Console.ReadLine(), out int registrationId))
                {
                    Console.WriteLine("Invalid Registration ID.");
                    break;
                }

                Console.Write("Enter Event ID: ");
                if (!int.TryParse(Console.ReadLine(), out int regEventId))
                {
                    Console.WriteLine("Invalid Event ID.");
                    break;
                }

                Console.Write("Enter Participant ID: ");
                if (!int.TryParse(Console.ReadLine(), out int regParticipantId))
                {
                    Console.WriteLine("Invalid Participant ID.");
                    break;
                }

                Console.Write("Enter Amount Paid: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amountPaid))
                {
                    Console.WriteLine("Invalid amount.");
                    break;
                }

                registrationService.RegisterParticipant(
                    registrationId,
                    regEventId,
                    regParticipantId,
                    amountPaid);

                break;
            }

        case 10:
            registrationService.ViewRegistrations();
            break;

        case 11:
            Console.Write("Enter Registration ID: ");
            if (int.TryParse(Console.ReadLine(), out int searchRegistrationId))
                registrationService.SearchRegistration(searchRegistrationId);
            else
                Console.WriteLine("Invalid Registration ID.");
            break;

        case 12:
            Console.Write("Enter Registration ID: ");
            if (int.TryParse(Console.ReadLine(), out int cancelRegistrationId))
                registrationService.CancelRegistration(cancelRegistrationId);
            else
                Console.WriteLine("Invalid Registration ID.");
            break;

        case 13:
            Console.Write("Enter Registration ID: ");
            if (int.TryParse(Console.ReadLine(), out int attendanceRegistrationId))
                registrationService.MarkAttendance(attendanceRegistrationId);
            else
                Console.WriteLine("Invalid Registration ID.");
            break;

        case 14:
            Console.WriteLine("Exiting Event Registration System...");
            return;

        default:
            Console.WriteLine("Invalid choice! Enter 1-14.");
            break;
    }
}
