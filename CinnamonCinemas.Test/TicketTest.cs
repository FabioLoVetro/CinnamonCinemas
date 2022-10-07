using CinnamonCinemas.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class TicketTest
    {
        
        Ticket ticket;
        [SetUp]
        public void Setup()
        {
            ticket = new Ticket();
            ticket.Movie = "Matrix";
            ticket.Date = new DateOnly(2022,10,20);
            ticket.Time = new TimeOnly(15,00);
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
            ticket.Date.ToString().Should().Be("20/10/2022");
        }

        [Test]
        public void TimeTest()
        {
            ticket.Time.ToString().Should().Be("15:00");
        }

        [Test]
        public void SeatTest()
        {
            ticket.Seat.Should().Be("B4");
        }
    }
}