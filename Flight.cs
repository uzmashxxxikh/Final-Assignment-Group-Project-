using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    internal class Flight
    {
        public int Id { get; private set; } // Unique flight ID
        public string To { get; private set; } // Destination
        public string From { get; private set; } // Origin
        public int Capacity { get; private set; } // Maximum seats on flight
        public int OccupiedSeats { get; private set; } // Current occupied seats

        // Constructor with input validation for capacity
        public Flight(int id, string from, string to, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than 0.");

            Id = id;
            From = from;
            To = to;
            Capacity = capacity;
            OccupiedSeats = 0; // Initialize with no passengers
        }

        // Book a seat, ensuring there is availability
        public bool BookSeat()
        {
            if (OccupiedSeats < Capacity)
            {
                OccupiedSeats++;
                return true;
            }
            Console.WriteLine("No available seats for booking.");
            return false;
        }

        // Cancel a seat, ensuring there are passengers to remove
        public bool CancelSeat()
        {
            if (OccupiedSeats > 0)
            {
                OccupiedSeats--;
                return true;
            }
            Console.WriteLine("No passengers to cancel.");
            return false;
        }

        // Display flight details in a formatted way
        public void ShowDetails()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Flight ID: {Id}");
            Console.WriteLine($"Route: {From} → {To}");
            Console.WriteLine($"Seats Filled: {OccupiedSeats}/{Capacity}");
            Console.WriteLine(new string('-', 40));
        }

        // Prevent deletion of flights that have booked passengers
        public bool CanDelete()
        {
            if (OccupiedSeats > 0)
            {
                Console.WriteLine("Cannot delete this flight. There are booked passengers.");
                return false;
            }
            return true;
        }
    }

    // Manager class for handling the flights
    internal class FlightManager
    {
        private List<Flight> flights = new List<Flight>(); // List to store flights

        // Method to add a flight, ensuring no duplicates
        public void AddFlight(int id, string from, string to, int capacity)
        {
            // Check for existing flight with the same ID
            foreach (var flight in flights)
            {
                if (flight.Id == id)
                {
                    Console.WriteLine($"Flight with ID {id} already exists.");
                    return;
                }
            }

            Flight newFlight = new Flight(id, from, to, capacity);
            flights.Add(newFlight);
            Console.WriteLine($"Flight {id} added successfully.");
        }

        // Method to list all flights
        public void ListFlights()
        {
            if (flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            Console.WriteLine("All Flights:");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight ID: {flight.Id}, {flight.From} → {flight.To}");
            }
        }

        // Method to view detailed info about a specific flight
        public void ViewFlightDetails(int flightId)
        {
            var flight = flights.Find(f => f.Id == flightId);
            if (flight != null)
            {
                flight.ShowDetails();
            }
            else
            {
                Console.WriteLine($"Flight with ID {flightId} not found.");
            }
        }

        // Method to delete a flight, ensuring there are no booked passengers
        public void DeleteFlight(int flightId)
        {
            var flight = flights.Find(f => f.Id == flightId);
            if (flight != null)
            {
                if (flight.CanDelete())
                {
                    flights.Remove(flight);
                    Console.WriteLine($"Flight {flightId} deleted successfully.");
                }
            }
            else
            {
                Console.WriteLine($"Flight with ID {flightId} not found.");
            }
        }
    }
}
