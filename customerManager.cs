using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment__Group_Project_
{
    public class CustomerManager
    {
        private List<Customer> customers;

        public CustomerManager()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer()
        {
            Console.Write("Enter Customer First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Customer Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Customer Phone: ");
            string phone = Console.ReadLine();

            // check to see if customer was already added
            if (customers.Any(c => c.FirstName == firstName && c.LastName == lastName && c.Phone == phone))
            {
                Console.WriteLine("A customer with the same name and phone already exists.");
                return;
            }

            int id = customers.Count + 1; // this automatically assigns an ID 
            customers.Add(new Customer(id, firstName, lastName, phone));
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Customer added successfully!");
            Console.WriteLine("-----------------------------------------------");
        }

        public void ListCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available.");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}, Phone: {customer.Phone}");
            }
        }

        public void DeleteCustomer()
        {
            int id;
            Console.Write("Enter Customer ID to delete: ");
            while (!int.TryParse(Console.ReadLine(), out id))  //input validation
            {
                Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            }

            Customer customer = customers.Find(c => c.Id == id);
            if (customer != null && customer.BookingsCount == 0) //does a booking already exist?
            {
                customers.Remove(customer);
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found or has active bookings.");
            }
        }

        public void ShowCustomerMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Exit");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Enter your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice))  // input validation
                {
                    Console.WriteLine("Invalid input. Please enter a number (1-4).");
                    Console.Write("Enter your choice: ");
                }

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        ListCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Customer Manager.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (choice != 4);
        }
    }
}