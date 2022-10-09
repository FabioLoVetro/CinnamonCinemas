# Cinnamon Cinemas Movie Theater
A program to allocate seats to customers purchasing tickets for a movie theatre.

## Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Installing](#installing)
- [Usage](#usage)
- [Contributing](#contributing)

## About
The Cinnamon Cinemas Movie Theatre has 15 seats, arranged in 3 rows of 5

● Rows are assigned a letter from A to C
● Seats are assigned a number from 1 to 5

The user can choose among 3 options to buy tickets:
- 1 - I want buy a random number of tickets(1 to 3) for a movie
- 2 - I want buy # number of tickets for a movie
- 3 - I want buy tickets specific seats for a movie
- 4 - I want stop and get out!

## Getting Started
Fork and copy the repository at https://github.com/FabioLoVetro/CinnamonCinemas.git.

## Installing
No need installation!
Start the program.

## Usage
The program starts with a series of information!
here an exemple:
-------------------------------------------------------------------------------------------------------------------------------
Welcome to Cinnamon Cinema Movie Theatre

Our seats are really comfortable! Have a look!
A1 A2 A3 A4 A5 B1 B2 B3 B4 B5 C1 C2 C3 C4 C5

Here our movie schedule:

Arrows
2022-10-02
 - 15:00 - 17:00 - 19:00 - 21:00 - 23:00
2022-10-25
 - 19:00
Cars
2022-10-03
 - 15:00 - 17:00
Star wars
2022-10-03
 - 19:00 - 21:00 - 23:00

Seats sold for: Cars
 - 2022-10-03 15:00 -
 - 2022-10-03 17:00 -

Seats sold for: Star wars
 - 2022-10-03 19:00 -
 - 2022-10-03 21:00 -
 - 2022-10-03 23:00 -


Please choose an option:
- 1 - I want buy a random number of tickets(1 to 3) for a movie
- 2 - I want buy # number of tickets for a movie
- 3 - I want buy tickets specific seats for a movie
- 4 - I want stop and get out!
-------------------------------------------------------------------------------------------------------------------------------
At this point the user need to digit some information to buy the ticket!
The program will guides the user asking the information what it needs:

Example:

by user:		1
by program:		Option 1: what movie would you like watch? (Matrix)
by user:		Matrix
by program:		Choose date and time of the show: (Ex: 2022-10-20 15:00)
by user:		2022-10-20 15:00
-------------------------------------------------------------------------------------------------------------------------------
When all the information are inputted, the program will respond with an info about the result of the operation:

Example:

Well done! you bought the tickets. Thank you!
-------------------------------------------------------------------------------------------------------------------------------
And it will update all the information

Example:

Seats sold for: Cars
 - 2022-10-03 15:00 - A1 A2
 - 2022-10-03 17:00 -

## Contributing
Fabio Lo Vetro