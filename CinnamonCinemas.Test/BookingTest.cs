using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Net.Sockets;

namespace CinnamonCinemas.Test
{
    public class BookingTests
    {
        
        Booking booking;
        [SetUp]
        public void Setup()
        {
            booking = new Booking();
            Ticket matrix = new Ticket();
            matrix.Movie = "Matrix";
            matrix.Date = new DateOnly(2022, 10, 20);
            matrix.Time = new TimeOnly(15, 00);
            matrix.Seat = "B4";
            Ticket arrows = new Ticket();
            arrows.Movie = "Arrows";
            arrows.Date = new DateOnly(2022, 10, 25);
            arrows.Time = new TimeOnly(19, 00);
            arrows.Seat = "A3";
            booking.TicketList.Add(matrix);
            booking.TicketList.Add(arrows);
        }

        [Test]
        public void BookingTest()
        {
            booking.Should().NotBeNull();
            booking.TicketList.Should().NotBeNull();
        }

        [Test]
        public void TicketListTest()
        {
            booking.TicketList.Count.Should().Be(2);
            booking.TicketList[0].Movie.Should().Be("Matrix");
            booking.TicketList[1].Movie.Should().Be("Arrows");
        }
    }
}