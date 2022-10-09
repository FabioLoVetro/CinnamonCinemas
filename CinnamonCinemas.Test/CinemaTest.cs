using CinnamonCinemas.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class CinemaTests
    {
        Cinema cinema;
        [SetUp]
        public void Setup()
        {
            cinema = new Cinema();
            Showtime matrix = new Showtime();
            matrix.Movie = "Matrix";
            matrix.Dates.Add(new DateTime(2022, 10, 1, 15, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 17, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 19, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 21, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 1, 23, 00, 00));
            Showtime arrows = new Showtime();
            arrows.Movie = "Arrows";
            arrows.Dates.Add(new DateTime(2022, 10, 2, 15, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 17, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 19, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 21, 00, 00));
            arrows.Dates.Add(new DateTime(2022, 10, 2, 23, 00, 00));
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
        }

        [Test]
        public void CinemaTest()
        {
            cinema.Should().NotBeNull();
            cinema.ShowTimeList.Should().NotBeNull();
        }

        [Test]
        public void ShowTimeListTest()
        {
            cinema.ShowTimeList.Count.Should().Be(4);
            cinema.ShowTimeList[0].Movie.Should().Be("Matrix");
            cinema.ShowTimeList[0].Dates.Count.Should().Be(5);
            cinema.ShowTimeList[1].Movie.Should().Be("Arrows");
            cinema.ShowTimeList[1].Dates.Count.Should().Be(5);
            cinema.ShowTimeList[2].Movie.Should().Be("Cars");
            cinema.ShowTimeList[2].Dates.Count.Should().Be(2);
            cinema.ShowTimeList[3].Movie.Should().Be("Star wars");
            cinema.ShowTimeList[3].Dates.Count.Should().Be(3);
        }

        [Test]
        public void CinemaNameTest()
        {
            cinema.CinemaName.Should().Be("Cinnamon Cinemas Movie Theatre");
        }

        [Test]
        public void SeatsNumberTest()
        {
            cinema.SeatsNumber.Should().Be(15);
        }

        [Test]
        public void SeatsTest()
        {
            cinema.Seats.Contains("A1").Should().BeTrue();
            cinema.Seats.Contains("A2").Should().BeTrue();
            cinema.Seats.Contains("A3").Should().BeTrue();
            cinema.Seats.Contains("A4").Should().BeTrue();
            cinema.Seats.Contains("A5").Should().BeTrue();
            cinema.Seats.Contains("B1").Should().BeTrue();
            cinema.Seats.Contains("B2").Should().BeTrue();
            cinema.Seats.Contains("B3").Should().BeTrue();
            cinema.Seats.Contains("B4").Should().BeTrue();
            cinema.Seats.Contains("B5").Should().BeTrue();
            cinema.Seats.Contains("C1").Should().BeTrue();
            cinema.Seats.Contains("C2").Should().BeTrue();
            cinema.Seats.Contains("C3").Should().BeTrue();
            cinema.Seats.Contains("C4").Should().BeTrue();
            cinema.Seats.Contains("C5").Should().BeTrue();
        }
    }
}