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
        [SetUp]
        public void Setup()
        {
            buyTicket = new BuyTickets();
            booking = new Booking(new Cinema());
            availability = new Availability();
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
        public void BuyRandomNumberOfSeatsTest()
        {
            //Matrix
            buyTicket.BuyRandomNumberOfSeats("Matrix",new DateTime(2022, 10, 20, 15, 00, 00)).Should().BeTrue();
            //Arrows
            buyTicket.BuyRandomNumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00)).Should().BeTrue();
        }

        [Test]
        public void BuyANumberOfSeatsTest()
        {
            //Matrix
            booking.TicketList.Count.Should().Be(3);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00),5).Should().BeTrue();
            booking.TicketList.Count.Should().Be(8);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 7).Should().BeTrue();
            booking.TicketList.Count.Should().Be(15);
            buyTicket.BuyANumberOfSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), 1).Should().BeFalse();
            booking.TicketList.Count.Should().Be(15);
            //Arrows
            booking.TicketList.Count.Should().Be(3);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 8).Should().BeTrue();
            booking.TicketList.Count.Should().Be(11);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 4).Should().BeTrue();
            booking.TicketList.Count.Should().Be(15);
            buyTicket.BuyANumberOfSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), 1).Should().BeFalse();
            booking.TicketList.Count.Should().Be(15);
        }

        [Test]
        public void BuySpecificSeatsTest()
        {
            string[] seatsAvailableForMatrix = { "A1", "B4", "C2" };
            string[] seatsNotAvailableForMatrix = { "A1", "A4", "C2" };
            string[] seatsAvailableForArrows = { "B4", "B5", "C1" };
            string[] seatsNotAvailableForArrows = { "C1", "C2", "C3" };

            //Matrix
            booking.TicketList.Count.Should().Be(3);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A4 A5 B1");
            buyTicket.BuySpecificSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsAvailableForMatrix).Should().BeTrue();
            booking.TicketList.Count.Should().Be(6);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A1 A4 A5 B1 B4 C2");
            buyTicket.BuySpecificSeats("Matrix", new DateTime(2022, 10, 20, 15, 00, 00), seatsNotAvailableForMatrix).Should().BeFalse();
            booking.TicketList.Count.Should().Be(6);
            availability.SeatsAllocatedForMovie("Matrix", booking)[new DateTime(2022, 10, 20, 15, 00, 00)].Should().Be("A1 A4 A5 B1 B4 C2");
            //Arrows
            booking.TicketList.Count.Should().Be(3);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 C3");
            buyTicket.BuySpecificSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsAvailableForArrows).Should().BeTrue();
            booking.TicketList.Count.Should().Be(6);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 B4 B5 C1 C3");
            buyTicket.BuySpecificSeats("Arrows", new DateTime(2022, 10, 25, 19, 00, 00), seatsNotAvailableForArrows).Should().BeFalse();
            booking.TicketList.Count.Should().Be(6);
            availability.SeatsAllocatedForMovie("Arrows", booking)[new DateTime(2022, 10, 25, 19, 00, 00)].Should().Be("A3 B3 B4 B5 C1 C3");
        }
    }
}