using System;

namespace TriangleTypeIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Triangle Type Identifier ===");
            Console.WriteLine("Enter the lengths of three sides to identify the triangle type.");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Enter the three sides of the triangle:");

                // Get the three sides from user
                double side1 = GetSideLength("Side 1");
                if (side1 == -1) break; // User wants to quit

                double side2 = GetSideLength("Side 2");
                if (side2 == -1) break; // User wants to quit

                double side3 = GetSideLength("Side 3");
                if (side3 == -1) break; // User wants to quit

                Console.WriteLine();

                // Check if the sides can form a valid triangle
                if (!IsValidTriangle(side1, side2, side3))
                {
                    Console.WriteLine("Error: These sides cannot form a valid triangle!");
                    Console.WriteLine("The sum of any two sides must be greater than the third side.");
                    Console.WriteLine();
                    continue;
                }

                // Determine triangle type
                string triangleType = DetermineTriangleType(side1, side2, side3);

                // Display results
                Console.WriteLine($"Side 1: {side1:F2}");
                Console.WriteLine($"Side 2: {side2:F2}");
                Console.WriteLine($"Side 3: {side3:F2}");
                Console.WriteLine($"Triangle Type: {triangleType}");
                Console.WriteLine();

                // Ask if user wants to continue
                Console.Write("Would you like to check another triangle? (y/n): ");
                string response = Console.ReadLine();
                if (response.ToLower() != "y" && response.ToLower() != "yes")
                {
                    Console.WriteLine("Thank you for using the Triangle Type Identifier!");
                    break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets a side length from the user with input validation
        /// </summary>
        /// <param name="sideName">Name of the side being entered</param>
        /// <returns>Valid side length, or -1 if user wants to quit</returns>
        static double GetSideLength(string sideName)
        {
            while (true)
            {
                Console.Write($"{sideName}: ");
                string input = Console.ReadLine();

                // Check if user wants to quit
                if (input.ToLower() == "quit" || input.ToLower() == "q")
                {
                    return -1;
                }

                // Try to parse the input as a number
                if (!double.TryParse(input, out double sideLength))
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                    continue;
                }

                // Validate that side length is positive
                if (sideLength <= 0)
                {
                    Console.WriteLine("Error: Side length must be greater than 0.");
                    continue;
                }

                return sideLength;
            }
        }

        /// <summary>
        /// Checks if three sides can form a valid triangle using the triangle inequality theorem
        /// </summary>
        /// <param name="side1">First side length</param>
        /// <param name="side2">Second side length</param>
        /// <param name="side3">Third side length</param>
        /// <returns>True if sides can form a valid triangle</returns>
        static bool IsValidTriangle(double side1, double side2, double side3)
        {
            // Triangle inequality theorem: sum of any two sides must be greater than the third
            return (side1 + side2 > side3) &&
                   (side1 + side3 > side2) &&
                   (side2 + side3 > side1);
        }

        /// <summary>
        /// Determines the type of triangle based on side lengths
        /// </summary>
        /// <param name="side1">First side length</param>
        /// <param name="side2">Second side length</param>
        /// <param name="side3">Third side length</param>
        /// <returns>Triangle type as string</returns>
        static string DetermineTriangleType(double side1, double side2, double side3)
        {
            // Use small epsilon for floating point comparison
            const double epsilon = 1e-10;

            bool side12Equal = Math.Abs(side1 - side2) < epsilon;
            bool side13Equal = Math.Abs(side1 - side3) < epsilon;
            bool side23Equal = Math.Abs(side2 - side3) < epsilon;

            // Check for equilateral (all sides equal)
            if (side12Equal && side13Equal && side23Equal)
            {
                return "Equilateral - All three sides are equal";
            }
            // Check for isosceles (exactly two sides equal)
            else if (side12Equal || side13Equal || side23Equal)
            {
                return "Isosceles - Two sides are equal";
            }
            // Otherwise it's scalene (no sides equal)
            else
            {
                return "Scalene - No sides are equal";
            }
        }
    }
}