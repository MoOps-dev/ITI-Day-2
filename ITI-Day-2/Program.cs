/**************************************
Written by Mohamed Khaled Tawfeek
mohamed.ibraham98@gmail.com
ITI Intensive Code Camp 2025-2026 R2
Full Stack .NET Zagazig DAY 2
***************************************/

using System.Numerics;            // Needed for BigInteger (for large factorials)
using System.Text.RegularExpressions; // Needed for regex validation

namespace ITI_Day_2;

partial class Program
{
    // Program control flag
    private static bool IsRunning = true;

    // Regex for validating numeric input (integer numbers, positive or negative)
    private static readonly Regex NumRegex = MyRegexNum();

    // Regex for validating operators in calculator (+, -, *, /, ^)
    private static readonly Regex OperatorRegex = MyRegexOperator();

    static void Main(string[] args)
    {
        // Main program loop, keeps running until user presses ESC
        while (IsRunning)
        {
            Console.Clear();

            // Display menu options
            Console.WriteLine(@"
*******************************************************
*** Welcome to Day-2, Choose an action to continue: ***
*******************************************************
** 1. Student Grade Check.                          ***
** 2. Even or Odd Check.                            ***
** 3. Prime Number Check.                           ***
** 4. Simple Calculator.                            ***
** 5. Factorial Calculation.                        ***
** 6. Exponents Calculation.                        ***
** 7. Decimal to Binary Converter.                  ***
** 8. Character & Word Counter.                     ***
** Or press ESC to exit the program.                ***
*******************************************************
            ");

            // Read a single key from the user without displaying it
            ConsoleKeyInfo MenuInput = Console.ReadKey(true);

            // Handle the menu selection using a switch statement
            switch(MenuInput.Key)
            {
                case ConsoleKey.D1: // Student Grade Check
                    Console.Clear();
                    Console.WriteLine(@"
***************************
*** Student Grade Check ***
***************************
                    ");
                    StudentDegreeCheck();
                    break;

                case ConsoleKey.D2: // Even or Odd check
                    Console.Clear();
                    Console.WriteLine(@"
*************************
*** Even or Odd check ***
*************************
                    ");
                    EvenOddCheck();
                    break;

                case ConsoleKey.D3: // Prime Number Check
                    Console.Clear();
                    Console.WriteLine(@"
**************************
*** Prime Number Check ***
**************************
                    ");
                    IsPrimeNumber();
                    break;

                case ConsoleKey.D4: // Simple Calculator
                    Console.Clear();
                    Console.WriteLine(@"
*************************
*** Simple Calculator ***
*************************
                    ");
                    Calculator();
                    break;

                case ConsoleKey.D5: // Factorial Calculation
                    Console.Clear();
                    Console.WriteLine(@"
*****************************
*** Factorial Calculation ***
*****************************
                    ");
                    CalculateFactorial();
                    break;

                case ConsoleKey.D6: // Exponents Calculation
                    Console.Clear();
                    Console.WriteLine(@"
****************************
*** Exponents Calculator ***
****************************
                    ");
                    ExponentsCalculator();
                    break;

                case ConsoleKey.D7: // Decimal to Binary Converter
                    Console.Clear();
                    Console.WriteLine(@"
************************************
*** Decimal to Binary Converter ***
************************************
                    ");
                    DecimalToBinary();
                    break;

                case ConsoleKey.D8: // Character & Word Counter
                    Console.Clear();
                    Console.WriteLine(@"
********************************
*** Character & Word Counter ***
********************************
                    ");
                    CharWordCounter();
                    break;

                default:
                    // If ESC is pressed, exit program
                    if (MenuInput.Key == ConsoleKey.Escape)
                        IsRunning = false;
                    break;
            }
        }

        // ====================== Feature Methods ======================

        // Student grade checker
        static void StudentDegreeCheck()
        {
            Console.Write("\nPlease Enter Student Degree: ");
            String? DegreeInput = Console.ReadLine();

            // Validate numeric input
            if (!ValidateNumber(DegreeInput!))
            {
                StudentDegreeCheck(); // Recursive call on invalid input
                return;
            }

            int IntDegreeInput = Convert.ToInt32(DegreeInput);

            // Determine grade based on degree ranges
            if (IntDegreeInput <= 100 && IntDegreeInput >= 85)
            {
                Console.WriteLine("Student Grade is: Excellent.");
            }
            else if (IntDegreeInput <= 84 && IntDegreeInput >= 75)
            {
                Console.WriteLine("Student Grade is: Very Good.");
            }
            else if (IntDegreeInput <= 74 && IntDegreeInput >= 65)
            {
                Console.WriteLine("Student Grade is: Good.");
            }
            else
            {
                Console.WriteLine("The entered student degree in not being tracked.");
            }

            ToMainMenu(); // Wait for ESC to return
        }
        
        // Even or Odd checker
        static void EvenOddCheck()
        {
            Console.Write("\nPlease Enter a number: ");
            String? NumberInput = Console.ReadLine();

            // Validate numeric input
            if (!ValidateNumber(NumberInput!))
            {
                EvenOddCheck();
                return;
            }

            int IntNumber = Convert.ToInt32(NumberInput);

            // Check parity
            if (IntNumber % 2 == 0)
            {
                Console.WriteLine($"The number {IntNumber} is an Even number.");
            }
            else
            {
                Console.WriteLine($"The number {IntNumber} is an Odd number.");
            }

            ToMainMenu();
        }

        // Prime number checker
        static void IsPrimeNumber()
        {
            Console.Write("\nPlease enter a number to check: ");
            String? NumberInput = Console.ReadLine();

            // Validate numeric input
            if (!ValidateNumber(NumberInput!))
            {
                IsPrimeNumber();
                return;
            }

            int IntNumber = Convert.ToInt32(NumberInput);

            if (IntNumber <= 1)
            {
                Console.WriteLine("The number must be greater than 1, please try again.");
                IsPrimeNumber();
                return;
            }
            else if (IntNumber == 2)
            {
                Console.WriteLine($"The number {IntNumber!} is a Prime number.");
                ToMainMenu();
                return;
            }

            // Check divisibility for numbers > 2
            bool IsPrime = true;
            for (int i = IntNumber-1; i > 1; i--)
            {
                if (IntNumber % i == 0)
                {
                    IsPrime = false;
                    break;
                }
            }

            Console.WriteLine(IsPrime ? $"The number {NumberInput!} is a Prime number."
                                      : $"The number {NumberInput!} is NOT a Prime number.");

            ToMainMenu();
        }

        // Simple calculator
        static void Calculator()
        {
            Console.Write("\nPlease enter the first number: ");
            string? FirstInput = Console.ReadLine();

            if (!ValidateNumber(FirstInput!))
            {
                Calculator();
                return;
            }

            Console.Write("Please enter the desired operator (+, -, /, *, ^): ");
            ConsoleKeyInfo OperatorInput = Console.ReadKey();

            if (!ValidateOperator(Convert.ToString(OperatorInput.KeyChar)))
            {
                Calculator();
                return;
            }

            Console.Write("\nPlease enter second number: ");
            String? SecondInput = Console.ReadLine();

            if (!ValidateNumber(SecondInput!))
            {
                Calculator();
                return;
            }

            int IntFirstInput = Convert.ToInt32(FirstInput);
            int IntSecondInput = Convert.ToInt32(SecondInput);

            object op = OperatorInput.KeyChar; // Store operator for display
            double result = 0;

            // Perform operation based on key pressed
            switch (OperatorInput.Key)
            {
                case ConsoleKey.OemPlus: // +
                    result = IntFirstInput + IntSecondInput;
                    break;
                case ConsoleKey.OemMinus: // -
                    result = IntFirstInput - IntSecondInput;
                    break;
                case ConsoleKey.Oem2: // / (divide)
                    if (IntSecondInput == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        Calculator();
                        return;
                    }
                    result = (double)IntFirstInput / IntSecondInput;
                    break;
                case ConsoleKey.D8: // * (multiply)
                    result = IntFirstInput * IntSecondInput;
                    break;
                case ConsoleKey.D6: // ^ (exponent)
                    result = Math.Pow(IntFirstInput, IntSecondInput);
                    break;
            }

            Console.WriteLine($"Calculation: {FirstInput} {op} {SecondInput} = {result}");

            ToMainMenu();
        }

        // Factorial calculation
        static void CalculateFactorial()
        {
            Console.Write("\nPlease enter the number: ");
            string? NumberInput = Console.ReadLine();

            if (!ValidateNumber(NumberInput!))
            {
                CalculateFactorial();
                return;
            }

            BigInteger IntNumberInput = BigInteger.Parse(NumberInput!);

            // Factorial not defined for negatives
            if (IntNumberInput < 0)
            {
                Console.WriteLine("There is no Factorial for negative numbers.");
                ToMainMenu();
                return;
            }

            // Multiply numbers from n down to 1
            for (BigInteger i = IntNumberInput-1; i >= 1; i--)
            {
                IntNumberInput *= i;
            }

            Console.WriteLine($"The Factorial for {NumberInput} = {IntNumberInput}");

            ToMainMenu();
        }

        // Exponent calculator (manual loop)
        static void ExponentsCalculator()
        {
            Console.Write("\nPlease enter the number to calculate: ");
            string? NumberInput = Console.ReadLine();

            if (!ValidateNumber(NumberInput!))
            {
                ExponentsCalculator();
                return;
            }

            Console.Write("Please enter the power of number: ");
            string? PowerInput = Console.ReadLine();

            if (!ValidateNumber(PowerInput!))
            {
                ExponentsCalculator();
                return;
            }

            int IntNumberInput = Convert.ToInt32(NumberInput!);
            int IntPowerInput = Convert.ToInt32(PowerInput!);

            // Multiply the base by itself power-1 times
            while(IntPowerInput > 1)
            {
                IntNumberInput *= Convert.ToInt32(NumberInput!);
                IntPowerInput--;
            }

            Console.WriteLine($"The Number {NumberInput} to the power of {PowerInput} = {IntNumberInput}");

            ToMainMenu();
        }

        // Decimal to binary converter
        static void DecimalToBinary()
        {
            Console.Write("\nPlease enter a decimal to convert: ");
            string? NumberInput = Console.ReadLine();

            if (!ValidateNumber(NumberInput!))
            {
                DecimalToBinary();
                return;
            }

            int IntNumberInput = Convert.ToInt32(NumberInput!);
            String result;

            // Handle zero
            if (IntNumberInput == 0)
            {
                result = "0";
            }
            else if (IntNumberInput > 0) // Positive numbers
            {
                result = "";
                for (int i = IntNumberInput; i > 0; i /= 2)
                {
                    result = (i % 2) + result; // Prepend remainder
                }
            }
            else // Negative numbers, human-readable format
            {
                int absNumber = Math.Abs(IntNumberInput);
                result = "";
                for (int i = absNumber; i > 0; i /= 2)
                {
                    result = (i % 2) + result;
                }
                result = "-" + result; // Add minus sign
            }

            Console.WriteLine($"The Decimal {IntNumberInput} converted to Binary = {result}");

            ToMainMenu();
        }

        // Character & Word Counter
        static void CharWordCounter()
        {
            Console.Write("\nPlease enter a word or sentence you want to count: ");
            char[]? StringInput = Console.ReadLine()!.ToCharArray(); // Convert input to char array

            int ch = 0;    // Character count (excluding spaces)
            int words = 0; // Word count

            // Loop through each character
            foreach (char c in StringInput)
            {
                if (c != ' ') // If character is not a space
                {
                    ch += 1; // Count character

                    if (words < 1) // First word detected
                    {
                        words += 1;
                    }
                }

                if (c == ' ' && ch > 0) // Space after characters = new word
                {
                    words += 1;
                }
            }

            Console.WriteLine($"This sentence has {words} words and a total of {ch} characters (not including spaces).");

            ToMainMenu();
        }

        // Wait for ESC key to return to main menu
        static void ToMainMenu()
        {
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("\nPress ESC to return to the main menu...");
                key = Console.ReadKey(true);

            } while (key.Key != ConsoleKey.Escape);
        }

    }

    // ====================== Validation Methods ======================

    // Validate numeric input using regex
    static bool ValidateNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The required input cannot be empty.");
            return false;
        }
        else if (!NumRegex.IsMatch(input))
        {
            Console.WriteLine("The required input can only accept numbers.");
            return false;
        }
        return true;
    }

    // Validate operator input using regex
    static bool ValidateOperator(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The required input cannot be empty.");
            return false;
        }
        else if (!OperatorRegex.IsMatch(input))
        {
            Console.WriteLine("The required input can only accept these operators (+, -, /, *, ^).");
            return false;
        }
        return true;
    }

    // ====================== Regex Definitions ======================

    // Regex for integers, including negative numbers
    [GeneratedRegex(@"^-?[0-9]+$")]
    private static partial Regex MyRegexNum();

    // Regex for letters (not currently used in this program)
    [GeneratedRegex(@"^[A-Za-z]+$")]
    private static partial Regex MyRegexStr();

    // Regex for arithmetic operators
    [GeneratedRegex(@"^[+-/*^]$")]
    private static partial Regex MyRegexOperator();
}
