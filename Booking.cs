using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    internal class Booking
    {
        public int BookingId { get; private set; }
        public string Date { get; private set; }
        public Flight FlightDetails { get; private set; }
        public Customer CustomerDetails { get; private set; }

        public Booking(int bookingId, Flight flight, Customer customer)
        {
            BookingId = bookingId;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            FlightDetails = flight;
            CustomerDetails = customer;
        }

        public void ShowBookingInfo()
        {
            Console.WriteLine($"Booking {BookingId}: Date: {Date}");
            Console.WriteLine($"Flight: {FlightDetails.Id} | {FlightDetails.From} → {FlightDetails.To}");
            Console.WriteLine($"Customer: {CustomerDetails.First} {CustomerDetails.Last}, {CustomerDetails.Contact}");
        }
    }
}
