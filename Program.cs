using Final_Assignment__Group_Project_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Assignment__Group_Project_;

namespace Final_Assignment__Group_Project_
{
    public class Program
    {
        static void Main(string[] args)
        {

            FlightManager Fm = new FlightManager(10);
            CustomerManager customerManager = new CustomerManager();
            BookingManager bookingManager = new BookingManager(10);

            // Create a Flight object
            Flight flight = new Flight(1, "New York", "Los Angeles", 100);

            // Create an array of Customers and populate it
            Customer[] customers = new Customer[3];
            customers[0] = new Customer(1, "John", "Doe", "123-456-7890");
            customers[1] = new Customer(2, "Jane", "Smith", "098-765-4321");
            customers[2] = new Customer(3, "Alice", "Johnson", "555-555-5555");


            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Flight Management System");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1.  Customer");
                Console.WriteLine("2.  Booking");
                Console.WriteLine("3.  Flights");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        customerManager.ShowCustomerMenu();
                        break;
                    case "2":
                        bookingManager.ShowBookingMenu(flight, customers);
                        break;
                    case "3":
                        Fm.ShowFlightMenu();
                        break;
                    case "4":
                        exit = true;
                        break;
                    case "":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                // if (!exit)
                { 
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                }
            }
        }
    }
}
