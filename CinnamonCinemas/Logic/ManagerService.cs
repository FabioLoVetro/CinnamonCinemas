using CinnamonCinemas.Function;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemas.Logic
{
    public class ManagerService
    {
        Cinema cinema;
        Booking booking;
        BuyTickets buyTickets;
        Availability availability;

        /// <summary>
        /// Constructor
        /// </summary>
        public ManagerService()
        {
            cinema = new Cinema();
            booking = new Booking(cinema);
            buyTickets = new BuyTickets();
            availability = new Availability();
            this.inizialization();
            this.Start();
        }
        /// <summary>
        /// Inizialization 
        /// </summary>
        public void inizialization()
        {
            Showtime matrix = new Showtime();
            matrix.Movie = "Matrix";
            matrix.Dates.Add(new DateTime(2022, 10, 01, 15, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 01, 17, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 01, 19, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 01, 21, 00, 00));
            matrix.Dates.Add(new DateTime(2022, 10, 01, 23, 00, 00));
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
            cars.Dates.Add(new DateTime(2022, 10, 03, 15, 00, 00));
            cars.Dates.Add(new DateTime(2022, 10, 03, 17, 00, 00));
            Showtime star_wars = new Showtime();
            star_wars.Movie = "Star wars";
            star_wars.Dates.Add(new DateTime(2022, 10, 03, 19, 00, 00));
            star_wars.Dates.Add(new DateTime(2022, 10, 03, 21, 00, 00));
            star_wars.Dates.Add(new DateTime(2022, 10, 03, 23, 00, 00));
            cinema.ShowTimeList.Add(matrix);
            cinema.ShowTimeList.Add(arrows);
            cinema.ShowTimeList.Add(cars);
            cinema.ShowTimeList.Add(star_wars);
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to Cinnamon Cinema Movie Theatre");
            Console.WriteLine();
            Console.WriteLine("Our seats are really comfortable! Have a look!");
            Console.WriteLine(string.Join(' ', cinema.Seats));
            Console.WriteLine();
            Console.WriteLine("Here our movie schedule:");
            Console.WriteLine();
            Console.WriteLine(this.cinema.ShowTimeListToString());
            Console.WriteLine();
            int option = 0;
            while (option != 4)
            {
                foreach (string movie in cinema.AllMovie())
                {
                    Console.WriteLine(this.availability.ToString(movie, booking));
                }
                Console.WriteLine();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("- 1 - I want buy a random number of tickets(1 to 3) for a movie");
                Console.WriteLine("- 2 - I want buy # number of tickets for a movie");
                Console.WriteLine("- 3 - I want buy tickets specific seats for a movie");
                Console.WriteLine("- 4 - I want stop and get out!");
                string inputString = Console.ReadLine();
                option = int.Parse(inputString);
                if (option == 1) this.Option1();
                else if (option == 2) this.Option2();
                else if (option == 3) this.Option3();
                else this.Option4();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Buy a random number of tickets (1 to 3)
        /// </summary>
        public void Option1()
        {
            Console.WriteLine("Option 1: what movie would you like watch? (Matrix)");
            string movie = Console.ReadLine();
            Console.WriteLine("Choose date and time of the show: (Ex: 2022-10-20 15:00)");
            string dateTimeString = Console.ReadLine();
            DateTime dateTime = DateTime.Parse(dateTimeString);
            bool result = this.buyTickets.BuyRandomNumberOfSeats(movie, dateTime, booking);
            if (result)
            {
                Console.WriteLine();
                Console.WriteLine("Well done! you bought the tickets. Thank you!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("The movie or the date and time are invalid, please try again!");
            }
        }
        /// <summary>
        /// Buy a specific number of seats
        /// </summary>
        public void Option2()
        {
            Console.WriteLine("Option 2: what movie would you like watch? (Matrix)");
            string movie = Console.ReadLine();
            Console.WriteLine("Choose date and time of the show: (Ex: 2022-10-20 15:00)");
            string dateTimeString = Console.ReadLine();
            DateTime dateTime = DateTime.Parse(dateTimeString);
            Console.WriteLine("How many tickets do you want buy?");
            string inputString = Console.ReadLine();
            int numberOfTickets = int.Parse(inputString);
            bool result = this.buyTickets.BuyANumberOfSeats(movie, dateTime, numberOfTickets, booking);
            if (result)
            {
                Console.WriteLine();
                Console.WriteLine("Well done! you bought the tickets. Thank you!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("The movie or the date and time are invalid, please try again!");
            }
        }
        /// <summary>
        /// Buy specific seats
        /// </summary>
        public void Option3()
        {
            Console.WriteLine("Option 3: what movie would you like watch? (Matrix)");
            string movie = Console.ReadLine();
            Console.WriteLine("Choose date and time of the show: (Ex: 2022-10-20 15:00)");
            string dateTimeString = Console.ReadLine();
            DateTime dateTime = DateTime.Parse(dateTimeString);
            Console.WriteLine("Which seats would you like buy? (Ex: A1 A2 B1 B2)");
            string inputString = Console.ReadLine();
            string[] seats = inputString.Split(' ');
            bool result = this.buyTickets.BuySpecificSeats(movie, dateTime, seats, booking);
            if (result)
            {
                Console.WriteLine();
                Console.WriteLine("Well done! you bought the tickets. Thank you!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("The movie or the date and time are invalid, please try again!");
            }
        }
        /// <summary>
        /// Stops the program
        /// </summary>
        public void Option4()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you! bye bye");
        }
    }
}
