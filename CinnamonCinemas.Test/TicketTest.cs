using CinnamonCinemas.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class TicketTests
    {
        
        Ticket ticket;
        [SetUp]
        public void Setup()
        {
            ticket = new Ticket();
            ticket.Movie = "Matrix";
            ticket.DateTime = new DateTime(2022,10,20,15,00,00);
            ticket.Seat = "B4";
        }

        [Test]
        public void MovieTest()
        {
            ticket.Movie.Should().Be("Matrix");
        }

        [Test]
        public void DateTest()
        {
            ticket.DateTime.ToString().Should().Be("20/10/2022 15:00:00");
        }

        [Test]
        public void SeatTest()
        {
            ticket.Seat.Should().Be("B4");
        }
    }
}