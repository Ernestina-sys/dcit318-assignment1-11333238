using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Calculator ===");
            Console.WriteLine();

            while (true)
            {
                // Prompt user for input
                Console.Write("Enter a numerical grade (0-100) or 'quit' to exit: ");
                string input = Console.ReadLine();

                // Check if user wants to quit
                if (input.ToLower() == "quit" || input.ToLower() == "q")
                {
                    Console.WriteLine("Thanks for using the Grade Calculator!");
                    break;
                }

                // Try to parse the input as a number
                if (!double.TryParse(input, out double grade))
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                    Console.WriteLine();
                    continue;
                }

                // Validate grade range
                if (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Error: Grade must be between 0 and 100.");
                    Console.WriteLine();
                    continue;
                }

                // Calculate letter grade
                string letterGrade = GetLetterGrade(grade);

                // Display result
                Console.WriteLine($"Grade: {grade:F1}");
                Console.WriteLine($"Letter Grade: {letterGrade}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Converts a numerical grade to a letter grade
        /// </summary>
        /// <param name="grade">Numerical grade between 0 and 100</param>
        /// <returns>Letter grade (A, B, C, D, or F)</returns>
        static string GetLetterGrade(double grade)
        {
            if (grade >= 90)
                return "A";
            else if (grade >= 80)
                return "B";
            else if (grade >= 70)
                return "C";
            else if (grade >= 60)
                return "D";
            else
                return "F";
        }
    }
}