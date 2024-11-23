using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    public class Customer
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public int BookingsCount { get; set; } // tracking the # of booking

        public Customer(int id, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            BookingsCount = 0;  // 0 is default booking
        }

        public void MakeBooking()
        {
            BookingsCount++;
        }

        public void CancelBooking()
        {
            if (BookingsCount > 0)
            {
                BookingsCount--;
            }
        }
    }
}