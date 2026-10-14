# TrainingManagementSystem

A C# .NET 10 console project demonstrating course catalogue, learner registration, enrollment/cancellation, fee calculations, simulated payments, reports, records, structs, inheritance, interfaces, generic helpers, collections, and exception handling.

## Requirements
- .NET 10 SDK
- Visual Studio 2022 with a .NET 10-capable installation, or VS Code with C# Dev Kit

## Suggested first test
1. Enter `1` to view the five sample courses.
2. Enter `4` and register a learner with a unique ID, name, 10–15 digit contact number, and email.
3. Enter `7`, use that learner ID, a course code such as `CS101`, and a future start date.
4. Note the enrollment reference.
5. Enter `8` to view enrollments.
6. Enter `11`, enter the enrollment reference, select a payment method, then type `Y` to simulate success or `N` to simulate failure.
7. Enter `12` for payment history and `13` for reports.
8. Enter `9` and the enrollment reference to cancel; try cancelling again to verify it will not release another seat.
9. Enter `0` to exit.

## Menu
0 Exit; 1 list courses; 2 search; 3 sort; 4 register learner; 5 list learners; 6 search learner;
7 enroll; 8 list enrollments; 9 cancel; 10 fee breakdown; 11 simulated payment; 12 payment history;
13 reports; 14 record/struct demo.

## Notes
- All data is in memory and resets when the app exits.
- Payment processing is simulated; no real money is collected.
- No database, third-party dependencies, or LINQ is used in the main application logic.
- The group discount is selected as a demo flag; choose it only when at least three eligible learners enroll together.
- Early-bird discount applies when the course start date is at least 14 days away.
- Contact validation is intentionally basic for this educational project.
