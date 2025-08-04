using System;

namespace TicketPriceCalculator
{
    class Program
    {
        // Constants for ticket prices
        const decimal REGULAR_PRICE = 10.00m;
        const decimal DISCOUNTED_PRICE = 7.00m;
        const int CHILD_AGE_LIMIT = 12;
        const int SENIOR_AGE_LIMIT = 65;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Theater Ticket Price Calculator ===");
            Console.WriteLine($"Regular ticket price: GHC{REGULAR_PRICE:F2}");
            Console.WriteLine($"Discounted price (Child/Senior): GHC{DISCOUNTED_PRICE:F2}");
            Console.WriteLine();

            while (true)
            {
                // Prompt user for input
                Console.Write("Enter your age or 'quit' to exit: ");
                string input = Console.ReadLine();

                // Check if user wants to quit
                if (input.ToLower() == "quit" || input.ToLower() == "q")
                {
                    Console.WriteLine("Thank you for using the Ticket Price Calculator!");
                    break;
                }

                // Try to parse the input as an integer
                if (!int.TryParse(input, out int age))
                {
                    Console.WriteLine("Error: Please enter a valid age (whole number).");
                    Console.WriteLine();
                    continue;
                }

                // Validate age range
                if (age < 0 || age > 150)
                {
                    Console.WriteLine("Error: Please enter a realistic age (0-150).");
                    Console.WriteLine();
                    continue;
                }

                // Calculate ticket price and category
                var ticketInfo = CalculateTicketPrice(age);

                // Display result
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Category: {ticketInfo.Category}");
                Console.WriteLine($"Ticket Price: GHC{ticketInfo.Price:F2}");

                if (ticketInfo.Price == DISCOUNTED_PRICE)
                {
                    decimal savings = REGULAR_PRICE - DISCOUNTED_PRICE;
                    Console.WriteLine($"You saved: GHC{savings:F2}!");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Calculates ticket price based on age and returns price with category information
        /// </summary>
        /// <param name="age">Customer's age</param>
        /// <returns>Tuple containing the ticket price and customer category</returns>
        static (decimal Price, string Category) CalculateTicketPrice(int age)
        {
            if (age <= CHILD_AGE_LIMIT)
            {
                return (DISCOUNTED_PRICE, "Child");
            }
            else if (age >= SENIOR_AGE_LIMIT)
            {
                return (DISCOUNTED_PRICE, "Senior Citizen");
            }
            else
            {
                return (REGULAR_PRICE, "Regular Adult");
            }
        }
    }
}