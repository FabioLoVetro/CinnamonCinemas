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
        Cinema cinema;
        Booking booking;

        [SetUp]
        public void Setup()
        {
            availability = new Availability();
            cinema = new Cinema();
            booking = new Booking(cinema);
            Showtime matrix = new Showtime();
            matrix.Movie = "Matrix";
            matrix.Dates.Add(new DateTime(2022, 10, 1, 15, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 17, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 19, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 21, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 23, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 20, 15, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 20, 17, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 20, 19, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 20, 21, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 20, 23, 00, 00));
            Showtime arrows = new Showtime();
            arrows.Movie = "Arrows";
            arrows.Dates.Add(new DateTime(2022, 10, 2, 15, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 17, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 19, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 21, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 23, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 25, 19, 00, 00));
            Showtime cars = new Showtime();
            cars.Movie = "Cars";
            cars.Dates.Add(new DateTime(2022, 10, 3, 15, 00, 00));
            cars.Dates.Add(new DateTime(2022, 10, 3, 17, 00, 00));
            Showtime star_wars = new Showtime();
            star_wars.Movie = "Star wars";
            star_wars.Dates.Add(new DateTime(2022, 10, 3, 19, 00, 00));
            star_wars.Dates.Add(new DateTime(2022, 10, 3, 21, 00, 00));
            star_wars.Dates.Add(new DateTime(2022, 10, 3, 23, 00, 00));
            cinema.ShowTimeList.Add(matrix);
            cinema.ShowTimeList.Add(arrows);
            cinema.ShowTimeList.Add(cars);
            cinema.ShowTimeList.Add(star_wars);
            Ticket matrix1 = new Ticket();
            matrix1.Movie = "Matrix";
            matrix1.DateTime = new DateTime(2022, 10, 20, 15, 00, 00);
            matrix1.Seat = "A4";
            Ticket matrix2 = new Ticket();
            matrix2.Movie = "Matrix";
            matrix2.DateTime = new DateTime(2022, 10, 20, 15, 00, 00);
            matrix2.Seat = "A5";
            Ticket matrix3 = new Ticket();
            matrix3.Movie = "Matrix";
            matrix3.DateTime = new DateTime(2022, 10, 20, 15, 00, 00);
            matrix3.Seat = "B1";
            Ticket arrows1 = new Ticket();
            arrows1.Movie = "Arrows";
            arrows1.DateTime = new DateTime(2022, 10, 25, 19, 00, 00);
            arrows1.Seat = "A3";
            Ticket arrows2 = new Ticket();
            arrows2.Movie = "Arrows";
            arrows2.DateTime = new DateTime(2022, 10, 25, 19, 00, 00);
            arrows2.Seat = "B3";
            Ticket arrows3 = new Ticket();
            arrows3.Movie = "Arrows";
            arrows3.DateTime = new DateTime(2022, 10, 25, 19, 00, 00);
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
            availability.AllAvailabilityForMovie("Matrix",booking).Count().Should().Be(10);
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[0].ToString().Should().Be("01/10/2022 15:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[1].ToString().Should().Be("01/10/2022 17:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[2].ToString().Should().Be("01/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[3].ToString().Should().Be("01/10/2022 21:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[4].ToString().Should().Be("01/10/2022 23:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[5].ToString().Should().Be("20/10/2022 15:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[6].ToString().Should().Be("20/10/2022 17:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[7].ToString().Should().Be("20/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[8].ToString().Should().Be("20/10/2022 21:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[9].ToString().Should().Be("20/10/2022 23:00:00");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[0]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[1]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[2]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[3]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[4]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[5]].Should().Be("A1 A2 A3 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[6]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[7]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[8]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Matrix", booking)[availability.AllAvailabilityForMovie("Matrix", booking).Keys.ToList()[9]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");

            availability.AllAvailabilityForMovie("Arrows", booking).Count().Should().Be(6);
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[0].ToString().Should().Be("02/10/2022 15:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[1].ToString().Should().Be("02/10/2022 17:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[2].ToString().Should().Be("02/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[3].ToString().Should().Be("02/10/2022 21:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[4].ToString().Should().Be("02/10/2022 23:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[5].ToString().Should().Be("25/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[0]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[1]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[2]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[3]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[4]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Arrows", booking)[availability.AllAvailabilityForMovie("Arrows", booking).Keys.ToList()[5]].Should().Be("A1 A2 A4 A5 B1 B2 B4 B5 C1 C2 C4 C5");

            availability.AllAvailabilityForMovie("Cars", booking).Count().Should().Be(2);
            availability.AllAvailabilityForMovie("Cars", booking).Keys.ToList()[0].ToString().Should().Be("03/10/2022 15:00:00");
            availability.AllAvailabilityForMovie("Cars", booking).Keys.ToList()[1].ToString().Should().Be("03/10/2022 17:00:00");
            availability.AllAvailabilityForMovie("Cars", booking)[availability.AllAvailabilityForMovie("Cars", booking).Keys.ToList()[0]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Cars", booking)[availability.AllAvailabilityForMovie("Cars", booking).Keys.ToList()[1]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            
            availability.AllAvailabilityForMovie("Star wars", booking).Count().Should().Be(3);
            availability.AllAvailabilityForMovie("Star wars", booking).Keys.ToList()[0].ToString().Should().Be("03/10/2022 19:00:00");
            availability.AllAvailabilityForMovie("Star wars", booking).Keys.ToList()[1].ToString().Should().Be("03/10/2022 21:00:00");
            availability.AllAvailabilityForMovie("Star wars", booking).Keys.ToList()[2].ToString().Should().Be("03/10/2022 23:00:00");
            availability.AllAvailabilityForMovie("Star wars", booking)[availability.AllAvailabilityForMovie("Star wars", booking).Keys.ToList()[0]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
            availability.AllAvailabilityForMovie("Star wars", booking)[availability.AllAvailabilityForMovie("Star wars", booking).Keys.ToList()[1]].Should().Be("A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5");
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
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 12, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 13, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 14, booking).Should().BeFalse();

            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 2, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 7, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 12, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 13, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 14, booking).Should().BeFalse();

            availability.EnoughSeatsAvailable("Cars", new DateTime(2022, 10, 03, 15, 00, 00), 15, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Cars", new DateTime(2022, 10, 03, 15, 00, 00), 16, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Cars", new DateTime(2022, 10, 03, 17, 00, 00), 15, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Cars", new DateTime(2022, 10, 03, 17, 00, 00), 16, booking).Should().BeFalse();

            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 19, 00, 00), 15, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 19, 00, 00), 16, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 21, 00, 00), 15, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 21, 00, 00), 16, booking).Should().BeFalse();
            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 23, 00, 00), 15, booking).Should().BeTrue();
            availability.EnoughSeatsAvailable("Star wars", new DateTime(2022, 10, 03, 23, 00, 00), 16, booking).Should().BeFalse();
        }

        [Test]
        public void SeatsAllocatedForMovieTest()
        {
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A4 A5 B1");

            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 C3");

            availability.SeatsAllocatedForMovie("Cars", booking)[new DateTime(2022, 10, 03, 15, 00, 00)].Should().Be("");
            availability.SeatsAllocatedForMovie("Cars", booking)[new DateTime(2022, 10, 03, 17, 00, 00)].Should().Be("");

            availability.SeatsAllocatedForMovie("Star wars", booking)[new DateTime(2022, 10, 03, 19, 00, 00)].Should().Be("");
            availability.SeatsAllocatedForMovie("Star wars", booking)[new DateTime(2022, 10, 03, 21, 00, 00)].Should().Be("");
            availability.SeatsAllocatedForMovie("Star wars", booking)[new DateTime(2022, 10, 03, 23, 00, 00)].Should().Be("");

            availability.SeatsAllocatedForMovie("Avatar", booking).Should().BeNull();
            availability.SeatsAllocatedForMovie("Resident Evil", booking).Should().BeNull();
        }

        [Test]
        public void IsMovieAvailableTest()
        {
            availability.IsMovieAvailable("Matrix", booking).Should().BeTrue();
            availability.IsMovieAvailable("Matri", booking).Should().BeFalse();

            availability.IsMovieAvailable("Arrows", booking).Should().BeTrue();
            availability.IsMovieAvailable("arrows", booking).Should().BeFalse();

            availability.IsMovieAvailable("Avatar", booking).Should().BeFalse();

            availability.IsMovieAvailable("Cars", booking).Should().BeTrue();

            availability.IsMovieAvailable("Star wars", booking).Should().BeTrue();

            availability.IsMovieAvailable("Resident Evil", booking).Should().BeFalse();
        }
        
    }
}