
using CinnamonCinemas.Function;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;

//Cinema cinema = new Cinema();


Availability availability;
Booking booking;
availability = new Availability();
booking = new Booking(new Cinema());
Ticket matrix1 = new Ticket();
matrix1.Movie = "Matrix";
matrix1.Date = new DateOnly(2022, 10, 20);
matrix1.Time = new TimeOnly(15, 00,00);
matrix1.Seat = "A4";
Ticket matrix2 = new Ticket();
matrix2.Movie = "Matrix";
matrix2.Date = new DateOnly(2022, 10, 20);
matrix2.Time = new TimeOnly(15, 00,00);
matrix2.Seat = "A5";
Ticket matrix3 = new Ticket();
matrix3.Movie = "Matrix";
matrix3.Date = new DateOnly(2022, 10, 20);
matrix3.Time = new TimeOnly(15, 00,00);
matrix3.Seat = "B1";
Ticket arrows1 = new Ticket();
arrows1.Movie = "Arrows";
arrows1.Date = new DateOnly(2022, 10, 25);
arrows1.Time = new TimeOnly(19, 00,00);
arrows1.Seat = "A3";
Ticket arrows2 = new Ticket();
arrows2.Movie = "Arrows";
arrows2.Date = new DateOnly(2022, 10, 25);
arrows2.Time = new TimeOnly(19, 00,00);
arrows2.Seat = "B3";
Ticket arrows3 = new Ticket();
arrows3.Movie = "Arrows";
arrows3.Date = new DateOnly(2022, 10, 25);
arrows3.Time = new TimeOnly(19, 00,00);
arrows3.Seat = "C3";
booking.TicketList.Add(matrix1);
booking.TicketList.Add(matrix2);
booking.TicketList.Add(matrix3);
booking.TicketList.Add(arrows1);
booking.TicketList.Add(arrows2);
booking.TicketList.Add(arrows3);

//print ticket list
for (int i = 0; i < booking.TicketList.Count; i++)
    Console.WriteLine($"TicketList passaggio {i} {booking.TicketList.ElementAt(i).ToString()}");
//print result
for (int i = 0; i < availability.AllAvailabilityForMovie("Matrix", booking).Count; i++)
    Console.WriteLine($"Result passaggio {i} {availability.AllAvailabilityForMovie("Matrix", booking).ElementAt(i)}");
//print result
for (int i = 0; i < availability.AllAvailabilityForMovie("Arrows", booking).Count; i++)
    Console.WriteLine($"Result passaggio {i} {availability.AllAvailabilityForMovie("Arrows", booking).ElementAt(i)}");

string[] seats = {"A4","A5","B1"};
Console.WriteLine(availability.AreSpecificSeatsAvailableForMovie("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seats, booking));