using Final_Assignment__Group_Project_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    public class FlightManager
    {

        private Flight[] flights;
        private int flightCount;

        public FlightManager(int maxFlights)
        {
            flights = new Flight[maxFlights];
            flightCount = 0;
        }

        public void ShowFlightMenu()
        {
            //Flight f = new Flight();

            int choice;
            do
            {
                Console.WriteLine("\n--- Flight Manager ---");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. View All Flights");
                Console.WriteLine("3. View Flight Details");
                Console.WriteLine("4. Delete Flight");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear(); 
                switch (choice)
                {
                    case 1:
                        AddFlight();
                        break;
                    case 2:
                        ListFlights();
                        break;
                    case 3:
                        ViewFlightDetails();

                        break;
                    case 4:
                        DeleteFlight();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Flight Manager.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 5);

        }

            public void AddFlight()
            {
                if (flightCount >= flights.Length)
                {
                    Console.WriteLine("Cannot add more flights. Maximum capacity reached.");
                    return;
                }

                Console.Write("Enter Flight Number: ");
                int flightNumber = int.Parse(Console.ReadLine());

                if (FindFlightByNumber(flightNumber) != null)
                {
                    Console.WriteLine("Flight with this number already exists.");
                    return;
                }

                Console.Write("Enter Origin: ");
                string origin = Console.ReadLine();

                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter Maximum Seats: ");
                int maxSeats = int.Parse(Console.ReadLine());

                flights[flightCount++] = new Flight(flightNumber, origin, destination, maxSeats); // Create a new Flight object
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Flight added successfully!");
                Console.WriteLine("-----------------------------------------------");
                
            }

            // List all flights
            public void ListFlights()
            {
                if (flightCount == 0)
                {
                    Console.WriteLine("No flights available.");
                    return;
                }

            //Console.WriteLine("\n--- All Flights ---");
            //for (int i = 0; i < flightCount; i++)
            //{
            //    if (flights[i] != null)
            //    {
            //        Console.WriteLine($"Flight {flights[i].Id}: {flights[i].From} → {flights[i].To}");
            //    }
            //}

                for (int i = 0; i < flightCount; i++)
                {
                    // Only access flight[i] if it is not null
                    if (flights[i] != null)
                    {
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine($"Flight ID     : {flights[i].Id}");
                        Console.WriteLine($"Origin        : {flights[i].From}");
                        Console.WriteLine($"Destination   : {flights[i].To}");
                        Console.WriteLine("--------------------------------------------------");
                    }
                }

            }

        // View flight details
        public void ViewFlightDetails()
            {
                Console.Write("Enter Flight Number: ");
                int flightNumber = int.Parse(Console.ReadLine());

                Flight flight = FindFlightByNumber(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine("Flight not found.");
                    return;
                }

                flight.ShowDetails();
            }

            // Delete a flight
            public void DeleteFlight()
            {

                Console.Write("Enter Flight Number to Delete: ");
                int flightNumber = int.Parse(Console.ReadLine());

                for (int i = 0; i < flightCount; i++)
                {
                    if (flights[i] != null && flights[i].Id == flightNumber)
                    {
                        if (!flights[i].CanDelete())
                        {
                            return;
                        }

                        // Shift flights after the deleted one
                        for (int j = i; j < flightCount - 1; j++)
                        {
                            flights[j] = flights[j + 1];
                        }

                        flights[flightCount - 1] = null; // Set the last element to null
                        flightCount--; // Decrease flight count
                        Console.WriteLine("Flight deleted successfully!");
                        return;
                    }
                }

                Console.WriteLine("Flight not found.");

            }

            // Find a flight by its number
            private Flight FindFlightByNumber(int flightNumber)
            {
                for (int i = 0; i < flightCount; i++)
                {
                    if (flights[i] != null && flights[i].Id == flightNumber)
                    {
                        return flights[i];
                    }
                }
                return null;
            }

    }
}
