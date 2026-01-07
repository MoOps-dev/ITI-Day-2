# ITI Day 2: Multi-Purpose Console Utility

Developed as part of the **ITI Intensive Code Camp 2025-2026 R2** (Full Stack .NET - Zagazig), this project is a comprehensive C# console application that demonstrates fundamental programming concepts, input validation, and algorithmic logic.

---

## 📌 Author

**Mohamed Khaled Tawfeek**
*Full Stack .NET Developer Student at ITI*

📧 Email: [mohamed.ibraham98@gmail.com](mailto:mohamed.ibraham98@gmail.com)

🎓 Program: ITI Intensive Code Camp 2025–2026 (R2)

💻 Track: Full Stack .NET – Zagazig

📅 Day: 2

---

## 🚀 Features

The application provides a centralized menu for eight distinct utilities:

1. **Student Grade Check:** Categorizes scores into Excellent, Very Good, or Good.
2. **Even or Odd Check:** Determines the parity of any given integer.
3. **Prime Number Check:** Efficiently verifies if a number is prime.
4. **Simple Calculator:** Supports Addition, Subtraction, Multiplication, Division, and Exponents.
5. **Factorial Calculation:** Uses `BigInteger` to calculate factorials of large numbers without overflow.
6. **Exponents Calculation:** A manual implementation of power calculations.
7. **Decimal to Binary Converter:** Converts decimal integers to their binary string representation (supports negatives).
8. **Character & Word Counter:** Analyzes strings to count words and non-space characters.

---

## 🛠 Technical Highlights

* **Robust Input Validation:** Uses `RegularExpressions` (Regex) with Source Generators (`[GeneratedRegex]`) for high-performance numeric and operator validation.
* **Large Number Support:** Utilizes `System.Numerics.BigInteger` to handle factorial results that exceed the capacity of a standard `Int64`.
* **User Interface:** Features a clean console-based menu system with recursive error handling to ensure a smooth user experience.
* **Flow Control:** Implements `ConsoleKeyInfo` to allow navigation and program termination via the `ESC` key.

---

## 📋 How to Run

### Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later.

### Installation & Execution

1. Clone the repository or copy the source code.
2. Open your terminal in the project directory.
3. Run the following command:
```bash
dotnet run

```



### Navigation

* Use numeric keys **1-8** to select a feature.
* Press **ESC** while inside a feature to return to the Main Menu.
* Press **ESC** on the Main Menu to exit the application.

---

## 📄 License

This project is created for **educational purposes** as part of ITI training.

---

If you find this project useful or are reviewing it as part of ITI activities, feel free to ⭐ the repository.