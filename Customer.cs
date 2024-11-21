using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    internal class Customer
    {
        public int Id { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }
        public string Contact { get; private set; }
        public int BookingCount { get; private set; }

        public Customer(int id, string first, string last, string contact)
        {
            Id = id;
            First = first;
            Last = last;
            Contact = contact;
            BookingCount = 0;
        }

        public static bool IsDuplicate(Customer[] customers, string first, string last, string contact)
        {
            foreach (var customer in customers)
            {
                if (customer != null && customer.First == first && customer.Last == last && customer.Contact == contact)
                    return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Customer {Id}: {First} {Last}, Contact: {Contact} | Bookings: {BookingCount}");
        }
    }
}
