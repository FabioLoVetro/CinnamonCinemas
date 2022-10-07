using CinnamonCinemas.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CinnamonCinemas.Test
{
    public class ShowtimeTest
    {
        Showtime showtime;

        [SetUp]
        public void Setup()
        {
            showtime = new Showtime();
            showtime.Movie = "Avatar";
            showtime.Dates.Add(new DateTime(2022, 10, 1, 15, 00, 00));
            showtime.Dates.Add(new DateTime(2022, 10, 1, 17, 00, 00));
            showtime.Dates.Add(new DateTime(2022, 10, 1, 19, 00, 00));
            showtime.Dates.Add(new DateTime(2022, 10, 1, 21, 00, 00));
            showtime.Dates.Add(new DateTime(2022, 10, 1, 23, 00, 00));
        }

        [Test]
        public void Showtime()
        {
            showtime.Should().NotBeNull();
            showtime.Dates.Should().NotBeNull();
        }

        [Test]
        public void ShowTimeMovieTest()
        {
            showtime.Movie.Should().Be("Avatar");
        }

        [Test]
        public void ShowTimeDatesTest()
        {
            showtime.Dates[0].ToString().Should().Be("01/10/2022 15:00:00");
            showtime.Dates[1].ToString().Should().Be("01/10/2022 17:00:00");
            showtime.Dates[2].ToString().Should().Be("01/10/2022 19:00:00");
            showtime.Dates[3].ToString().Should().Be("01/10/2022 21:00:00");
            showtime.Dates[4].ToString().Should().Be("01/10/2022 23:00:00");

        }
    }
}