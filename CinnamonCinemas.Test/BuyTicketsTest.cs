using CinnamonCinemas.Function;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class BuyTicketsTests
    {

        BuyTickets buyTicket;
        Booking booking;
        Availability availability;
        Cinema cinema;

        [SetUp]
        public void Setup()
        {
            buyTicket = new BuyTickets();
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
            arrows.Dates.Add(new DateTime(2022, 10, 02, 15, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 02, 17, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 02, 19, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 02, 21, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 02, 23, 00, 00));
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
            availability = new Availability();
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

            //for (int i = 0; i < booking.TicketList.Count(); i++)
            //{ Console.WriteLine($"indice {i} - {booking.TicketList[i]}"); }
        }

        [Test]
        public void BuyRandomNumberOfSeatsTest()
        {
            //Matrix
            buyTicket.BuyRandomNumberOfSeats("Matrix",new DateTime(2022, 10, 20, 15, 00, 00),booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Matrix", new DateTime(2022, 10, 20, 17, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Matrix", new DateTime(2022, 10, 20, 17, 00, 00), booking).Should().BeTrue();
            //Arrows
            buyTicket.BuyRandomNumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Arrows", new DateTime(2022, 10, 02, 21, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Arrows", new DateTime(2022, 10, 02, 23, 00, 00), booking).Should().BeTrue();
            //Cars
            buyTicket.BuyRandomNumberOfSeats("Cars", new DateTime(2022, 10, 03, 15, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Cars", new DateTime(2022, 10, 03, 17, 00, 00), booking).Should().BeTrue();
            //Star wars
            buyTicket.BuyRandomNumberOfSeats("Star wars", new DateTime(2022, 10, 03, 19, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Star wars", new DateTime(2022, 10, 03, 21, 00, 00), booking).Should().BeTrue();
            buyTicket.BuyRandomNumberOfSeats("Star wars", new DateTime(2022, 10, 03, 23, 00, 00), booking).Should().BeTrue();
        }

        [Test]
        public void BuyANumberOfSeatsTest()
        {
            //Matrix
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(3);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00),5,booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(8);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 7, booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(15);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 1, booking).Should().BeFalse();
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(15);
            //Arrows
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(3);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 8, booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(11);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 4, booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(15);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 1, booking).Should().BeFalse();
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(15);
        }

        [Test]
        public void BuySpecificSeatsTest()
        {
            string[] seatsAvailableForMatrix = { "A1", "B4", "C2" };
            string[] seatsNotAvailableForMatrix = { "A1", "A4", "C2" };
            string[] seatsAvailableForArrows = { "B4", "B5", "C1" };
            string[] seatsNotAvailableForArrows = { "C1", "C2", "C3" };

            //Matrix
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(3);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A4 A5 B1");
            buyTicket.BuySpecificSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsAvailableForMatrix, booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(6);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A4 A5 B1 A1 B4 C2");
            buyTicket.BuySpecificSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsNotAvailableForMatrix, booking).Should().BeFalse();
            booking.TicketList.Where(ticket => ticket.Movie == "Matrix").Count().Should().Be(6);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A4 A5 B1 A1 B4 C2");
            //Arrows
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(3);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 C3");
            buyTicket.BuySpecificSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsAvailableForArrows, booking).Should().BeTrue();
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(6);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 C3 B4 B5 C1");
            buyTicket.BuySpecificSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsNotAvailableForArrows, booking).Should().BeFalse();
            booking.TicketList.Where(ticket => ticket.Movie == "Arrows").Count().Should().Be(6);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 C3 B4 B5 C1");
        }
    }
}