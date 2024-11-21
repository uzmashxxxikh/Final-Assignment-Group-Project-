using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //AirlineManager manager = new AirlineManager(5, 5, 5);

            //manager.AddFlight(1001, "New York", "Los Angeles", 150);
            //manager.AddFlight(1002, "Chicago", "Miami", 200);

            //manager.AddCustomer("John", "Doe", "123-456-7890");
            //manager.AddCustomer("Jane", "Smith", "987-654-3210");

            //manager.MakeBooking(1, 1001);  // Booking for customer 1 on flight 1001
            //manager.MakeBooking(2, 1002);  // Booking for customer 2 on flight 1002


            //manager.ShowAllFlights();
            //manager.ShowAllCustomers();
            //manager.ShowAllBookings();

            //manager.CancelBooking(1);  // Cancel booking 1
            //manager.ShowAllBookings();  // View bookings after cancellation

            //Console.WriteLine("\nPress any key to exit...");

            FlightManager flightManager = new FlightManager();

            // Adding flights
            flightManager.AddFlight(101, "New York", "London", 150);
            flightManager.AddFlight(102, "Paris", "Tokyo", 200);

            // Viewing all flights
            flightManager.ListFlights();

            // Viewing details of a specific flight
            flightManager.ViewFlightDetails(101);

            // Attempt to delete a flight with booked passengers
            flightManager.DeleteFlight(101);  // Shouldn't allow if there are bookings

            // Deleting a flight with no passengers
            flightManager.DeleteFlight(102);  // Should succeed if no bookings

            Console.ReadLine();
            Console.ReadKey();

        }
    }
}
