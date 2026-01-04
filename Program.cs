/**************************************
Written by Mohamed Khaled Tawfeek
mohamed.ibraham98@gmail.com
ITI Intensive Code Camp 2025-2026 R2
Full Stack .NET Zagazig DAY 2
***************************************/

using System.Numerics;
using System.Text.RegularExpressions;

namespace ITI_Day_2;

partial class Program
{
    private static bool IsRunning = true;
    private static readonly Regex NumRegex = MyRegexNum();
    private static readonly Regex OperatorRegex = MyRegexOperator();

    static void Main(string[] args)
    {
        while (IsRunning)
        {
            Console.Clear();
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

            ConsoleKeyInfo MenuInput = Console.ReadKey(true);
            switch(MenuInput.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine(@"
***************************
*** Student Grade Check ***
***************************
                    ");
                    StudentDegreeCheck();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine(@"
*************************
*** Even or Odd check ***
*************************
                    ");
                    EvenOddCheck();
                    break;
                
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine(@"
**************************
*** Prime Number Check ***
**************************
                    ");
                    IsPrimeNumber();
                    break;

                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine(@"
*************************
*** Simple Calculator ***
*************************
                    ");
                    Calculator();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine(@"
*****************************
*** Factorial Calculation ***
*****************************
                    ");
                    CalculateFactorial();
                    break;

                case ConsoleKey.D6:
                    Console.Clear();
                    Console.WriteLine(@"
****************************
*** Exponents Calculator ***
****************************
                    ");
                    ExponentsCalculator();
                    break;

                case ConsoleKey.D7:
                    Console.Clear();
                    Console.WriteLine(@"
************************************
*** Decimal to Binary Converter ***
************************************
                    ");
                    DecimalToBinary();
                    break;

                case ConsoleKey.D8:
                    Console.Clear();
                    Console.WriteLine(@"
********************************
*** Character & Word Counter ***
********************************
                    ");
                    CharWordCounter();
                    break;

                default:
                    if (MenuInput.Key == ConsoleKey.Escape)
                        IsRunning = false;
                    break;
            }
        }

        static void StudentDegreeCheck()
        {
            Console.Write("\nPlease Enter Student Degree: ");
            String? DegreeInput = Console.ReadLine();

            if (!ValidateNumber(DegreeInput!))
            {
                StudentDegreeCheck();
                return;
            }

            int IntDegreeInput = Convert.ToInt32(DegreeInput);

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

            ToMainMenu();
        }
        
        static void EvenOddCheck()
        {
            Console.Write("\nPlease Enter a number: ");
            String? NumberInput = Console.ReadLine();

            if (!ValidateNumber(NumberInput!))
            {
                EvenOddCheck();
                return;
            }

            int IntNumber = Convert.ToInt32(NumberInput);

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

        static void IsPrimeNumber()
        {
            Console.Write("\nPlease enter a number to check: ");
            String? NumberInput = Console.ReadLine();

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

            bool IsPrime = true;

            for (int i = IntNumber-1; i > 1; i--)
            {
                if (IntNumber % i == 0)
                {
                    IsPrime = false;
                    break;
                }
            }

            Console.WriteLine(IsPrime ? $"The number {NumberInput!} is a Prime number.": $"The number {NumberInput!} is NOT a Prime number.");

            ToMainMenu();
        }

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

            if (!ValidateNumber(FirstInput!))
            {
                Calculator();
                return;
            }

            int IntFirstInput = Convert.ToInt32(FirstInput);
            int IntSecondInput = Convert.ToInt32(SecondInput);

            object op = OperatorInput.KeyChar;
            double result = 0;

            switch (OperatorInput.Key)
            {
                case ConsoleKey.OemPlus:
                    result = IntFirstInput + IntSecondInput;
                    break;
                case ConsoleKey.OemMinus:
                    result = IntFirstInput - IntSecondInput;
                    break;
                case ConsoleKey.Oem2:
                    if (IntSecondInput == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        Calculator();
                        return;
                    }
                    result = (double)IntFirstInput / IntSecondInput;
                    break;
                case ConsoleKey.D8:
                    result = IntFirstInput * IntSecondInput;
                    break;
                case ConsoleKey.D6:
                    result = Math.Pow(IntFirstInput, IntSecondInput);
                    break;

            }

            Console.WriteLine($"Calculation: {FirstInput} {op} {SecondInput} = {result}");

            ToMainMenu();

        }

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

            if (IntNumberInput < 0)
            {
                Console.WriteLine("There is not Factorial for negative numbers.");
                ToMainMenu();
                return;
            }

            for (BigInteger i = IntNumberInput-1; i >= 1; i--)
            {
                IntNumberInput *= i;
            }

            Console.WriteLine($"The Factorial for {NumberInput} = {IntNumberInput}");

            ToMainMenu();

        }

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

            while(IntPowerInput > 1)
            {
                IntNumberInput *= Convert.ToInt32(NumberInput!);
                IntPowerInput--;
            }

            Console.WriteLine($"The Number {NumberInput} to the power of {PowerInput} = {IntNumberInput}");

            ToMainMenu();

        }

        static void DecimalToBinary()
        {
            Console.Write("\nPlease enter a decimal to covert: ");
            string? NumberInput = Console.ReadLine();

            if (!ValidateNumber(NumberInput!))
            {
                DecimalToBinary();
                return;
            }

            int IntNumberInput = Convert.ToInt32(NumberInput!);
            String result;

            if (IntNumberInput == 0)
            {
                result = "0";
            }
            else if (IntNumberInput > 0)
            {
                result = "";
                for (int i = IntNumberInput; i > 0; i /= 2)
                {
                    result = (i % 2) + result;
                }
            }
            else
            {
                int absNumber = Math.Abs(IntNumberInput);
                result = "";
                for (int i = absNumber; i > 0; i /= 2)
                {
                    result = (i % 2) + result;
                }
                result = "-" + result;
            }

            Console.WriteLine($"The Decimal {IntNumberInput} converted to Binary = {result}");

            ToMainMenu();

        }

        static void CharWordCounter()
        {
            Console.Write("\nPlease enter a word or sentence you want to count: ");
            char[]? StringInput = Console.ReadLine()!.ToCharArray();

            int ch = 0;
            int words = 0;

            foreach (char c in StringInput)
            {
                if (c != ' ')
                {
                    ch += 1;

                    if (words < 1)
                    {
                        words += 1;
                    }
                }
                
                if (c == ' ' && ch > 0)
                {
                    words += 1;
                }
            }

            Console.WriteLine($"This sentence has {words} words and a total of {ch} characters (not including spaces).");

            ToMainMenu();

        }

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

    static bool ValidateNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The required input can not be empty.");
            return false;
        }
        else if (!NumRegex.IsMatch(input))
        {
            Console.WriteLine("The required input can only accept numbers.");
            return false;
        }
        return true;
    }

    static bool ValidateOperator(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The required input can not be empty.");
            return false;
        }
        else if (!OperatorRegex.IsMatch(input))
        {
            Console.WriteLine("The required input can only accept these operators (+, -, /, *, ^).");
            return false;
        }
        return true;
    }

    [GeneratedRegex(@"^-?[0-9]+$")]
    private static partial Regex MyRegexNum();

    [GeneratedRegex(@"^[A-Za-z]+$")]
    private static partial Regex MyRegexStr();

    [GeneratedRegex(@"^[+-/*^]$")]
    private static partial Regex MyRegexOperator();
}
