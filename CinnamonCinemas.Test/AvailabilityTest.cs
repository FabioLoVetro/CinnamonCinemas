using CinnamonCinemas.Function;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class AvailabilityTests
    {
        Availability availability;
        Booking booking;

        [SetUp]
        public void Setup()
        {
            availability = new Availability();
            booking = new Booking(new Cinema());
            Ticket matrix1 = new Ticket();
            matrix1.Movie = "Matrix";
            matrix1.Date = new DateOnly(2022, 10, 20);
            matrix1.Time = new TimeOnly(15, 00);
            matrix1.Seat = "A4";
            Ticket matrix2 = new Ticket();
            matrix2.Movie = "Matrix";
            matrix2.Date = new DateOnly(2022, 10, 20);
            matrix2.Time = new TimeOnly(15, 00);
            matrix2.Seat = "A5";
            Ticket matrix3 = new Ticket();
            matrix3.Movie = "Matrix";
            matrix3.Date = new DateOnly(2022, 10, 20);
            matrix3.Time = new TimeOnly(15, 00);
            matrix3.Seat = "B1";
            Ticket arrows1 = new Ticket();
            arrows1.Movie = "Arrows";
            arrows1.Date = new DateOnly(2022, 10, 25);
            arrows1.Time = new TimeOnly(19, 00);
            arrows1.Seat = "A3";
            Ticket arrows2 = new Ticket();
            arrows2.Movie = "Arrows";
            arrows2.Date = new DateOnly(2022, 10, 25);
            arrows2.Time = new TimeOnly(19, 00);
            arrows2.Seat = "B3";
            Ticket arrows3 = new Ticket();
            arrows3.Movie = "Arrows";
            arrows3.Date = new DateOnly(2022, 10, 25);
            arrows3.Time = new TimeOnly(19, 00);
            arrows3.Seat = "C3";
            booking.TicketList.Add(matrix1);
            booking.TicketList.Add(matrix2);
            booking.TicketList.Add(matrix3);
            booking.TicketList.Add(arrows1);
            booking.TicketList.Add(arrows2);
            booking.TicketList.Add(arrows3);
        }

        [Test]
        public void AllAvailabilityForMovieTest()
        {
            availability.AllAvailabilityForMovie("Matrix",booking).Count().Should().Be(1);
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[0].ToString().Should().Be("20/10/2022 15:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[0]].Should().Be("A1 A2 A3 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking).Count().Should().Be(1);
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[0].ToString().Should().Be("25/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[0]].Should().Be("A1 A2 A4 A5 B1 B2 B4 B5 C1 C2 C4 C5");
        }

        [Test]
        public void AreSpecificSeatsAvailableForMovieTest()
        {
            string[] seatsAvailableForMatrix = { "A1", "B4", "C2" };
            string[] seatsNotAvailableForMatrix = { "A1", "A4", "C2" };
            string[] seatsAvailableForArrows = { "B4", "B5", "C1" };
            string[] seatsNotAvailableForArrows = { "C1", "C2", "C3" };
            availability.AreSpecificSeatsAvailableForMovie("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsAvailableForMatrix, booking).Should().BeTrue();
            availability.AreSpecificSeatsAvailableForMovie("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsNotAvailableForMatrix, booking).Should().BeFalse();
            availability.AreSpecificSeatsAvailableForMovie("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsAvailableForArrows, booking).Should().BeTrue();
            availability.AreSpecificSeatsAvailableForMovie("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsNotAvailableForArrows, booking).Should().BeFalse();
        }

        [Test]
        public void EnoughSeatsAvailableTest()
        {
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00),5, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 10, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 13, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 2, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 7, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 14, booking).Should().BeFalse();
        }
    }
}