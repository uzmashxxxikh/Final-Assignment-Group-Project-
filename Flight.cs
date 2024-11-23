using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    public class Flight 
    {
        public int Id { get; private set; } // Unique flight ID
        public string To { get; private set; } // Destination
        public string From { get; private set; } // Origin
        public int Capacity { get; private set; } // Maximum seats on flight
        public int OccupiedSeats { get; private set; } // Current occupied seats


        // Constructor with input validation for capacity
        public Flight(int id, string from, string to, int capacity)
        {
            Id = id;
            From = from;
            To = to;
            Capacity = capacity;
            OccupiedSeats = 0; 
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
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Flight ID     : {Id}");
            Console.WriteLine($"Origin        : {From}");
            Console.WriteLine($"Destination   : {To}");
            Console.WriteLine($"Seats Filled  : {OccupiedSeats}/{Capacity}");
            Console.WriteLine("--------------------------------------------------");
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

}
