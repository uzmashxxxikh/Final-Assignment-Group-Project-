using Final_Assignment__Group_Project_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    public class Booking
    {
        public int BookingNumber { get; private set; }
        public string Date { get; private set; }
        public Flight Flight { get; private set; }
        public Customer Customer { get; private set; }

        public Booking(int bookingNumber, Flight flight, Customer customer)
        {
            BookingNumber = bookingNumber;
            Date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            Flight = flight;
            Customer = customer;
        }
    }

}