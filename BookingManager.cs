using Final_Assignment__Group_Project_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{


    public class BookingManager
    {
        private Booking[] bookings;
        private int bookingCount;

        public BookingManager(int capacity)
        {
            bookings = new Booking[capacity];
            bookingCount = 0;
        }

        // Method to add a booking
        public bool AddBooking(Flight flight, Customer customer)
        {
            if (bookingCount >= bookings.Length)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Booking limit reached. Cannot add more bookings.");
                Console.WriteLine("--------------------------------------------------------");
                return false;
            }

            
            if (flight.BookSeat())
            {
                // Create a new booking
                int bookingNumber = bookingCount + 1; 
                Booking newBooking = new Booking(bookingNumber, flight, customer);
                bookings[bookingCount] = newBooking;
                bookingCount++;

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"Booking successful! Booking Number: {newBooking.BookingNumber}");
                Console.WriteLine("------------------------------------------------------");
                return true;
            }
            return false; 
        }

        public void ViewBookings()
        {           
            Console.WriteLine("Bookings:");

            for (int i = 0; i < bookingCount; i++)
            {
                Booking booking = bookings[i];
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"Date: {booking.Date}, Booking Number: {booking.BookingNumber}, Customer: {booking.Customer.FirstName} {booking.Customer.LastName}, Flight ID: {booking.Flight.Id}");
                Console.WriteLine("-----------------------------------------------------------");
            }
        }

        public void ShowBookingMenu(Flight flight, Customer[] customers)
        {
            while (true)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Add Booking");
                Console.WriteLine("2. View Bookings");
                Console.WriteLine("3. Exit Booking Menu");
                Console.WriteLine("---------------------------------");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Booking
                        Console.WriteLine("Available Customers:");
                        for (int i = 0; i < customers.Length; i++)
                        {
                            if (customers[i] != null)
                            {
                                Console.WriteLine($"{i + 1}. {customers[i].FirstName} {customers[i].LastName}");
                            }
                        }
                        Console.Write("Select customer by number: ");
                        int customerIndex = int.Parse(Console.ReadLine()) - 1;

                        if (customerIndex >= 0 && customerIndex < customers.Length && customers[customerIndex] != null)
                        {
                            AddBooking(flight, customers[customerIndex]);
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine("Invalid customer selection.");
                            Console.WriteLine("---------------------------------");
                        }
                        break;

                    case "2":
                        ViewBookings();
                        break;

                    case "3":
                        Console.WriteLine("Exiting Booking Menu.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

       
    }
}