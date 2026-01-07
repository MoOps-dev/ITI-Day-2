# ITI Day 1 – C# Console Application

A simple **C# console-based application** developed as part of **ITI Intensive Code Camp 2025–2026 (Round 2)** – *Full Stack .NET, Zagazig*.
This project demonstrates fundamental **C# and .NET console programming concepts** through a menu-driven interactive application.

---

## 📌 Author

**Mohamed Khaled Tawfeek**
📧 Email: [mohamed.ibraham98@gmail.com](mailto:mohamed.ibraham98@gmail.com)
🎓 Program: ITI Intensive Code Camp 2025–2026 (R2)
💻 Track: Full Stack .NET – Zagazig
📅 Day: 1

---

## 🧩 Project Overview

The application presents a menu that allows the user to perform multiple basic operations related to:

* Character encoding
* Keyboard input handling
* Number system conversion
* C# operators knowledge assessment
* OOP

The program runs in a loop until the user chooses to exit.

---

## ⚙️ Features

### 1️⃣ Get ASCII / Unicode Value

* Reads a single character using `Console.Read()`
* Outputs its corresponding **Unicode (ASCII) value**
* Demonstrates input buffering and cleanup using `Console.ReadLine()`

### 2️⃣ Capture Pressed Key

* Uses `Console.ReadKey(true)` to capture key input
* Displays:

  * Key index (`ConsoleKey`)
  * Actual character pressed (`KeyChar`)
* Demonstrates secure input handling (hidden input)

### 3️⃣ Convert Binary to Decimal

* Accepts a **binary number** as input
* Converts it to decimal using:

  ```csharp
  Convert.ToInt32(value, 2)
  ```

### 4️⃣ Convert Decimal to Binary

* Accepts a **decimal number** as input
* Converts it to binary using:

  ```csharp
  Convert.ToString(value, 2)
  ```

### 5️⃣ C# Operators Quiz

* Interactive quiz covering common **C# operators**:

  * Arithmetic
  * Relational
  * Logical
  * Unary
* Uses a `Dictionary<string, string>` for question–answer mapping
* Randomizes questions using `Random.Shared.Shuffle()`
* Provides immediate feedback for each answer

---

## 🖥️ How to Run

### Prerequisites

* .NET SDK 7.0 or later
* Any C# compatible IDE (Visual Studio / VS Code)

### Steps

```bash
# Clone the repository
git clone https://github.com/MoOps-dev/ITI-Day-1

# Navigate to project directory
cd ITI_Day_1

# Run the application
dotnet run
```

---

## 📚 Concepts Demonstrated

* Console input/output handling
* Menu-driven program structure
* Loop control using boolean flags
* Method decomposition
* Dictionaries and collections
* Randomization
* Conditional (ternary) operators
* Base number system conversions

---

## 🧪 Sample Menu

```
1. Get ASCII/UNICODE Value
2. Capture Pressed Key
3. Convert a Decimal into Binary
4. Convert a Binary into Decimal
5. C# Operators Quiz
Any other key to exit
```

---

## 🚀 Future Improvements

* Input validation and exception handling
* Score tracking for quiz
* Modular separation into multiple files
* Unit testing

---

## 📄 License

This project is created for **educational purposes** as part of ITI training.

---

If you find this project useful or are reviewing it as part of ITI activities, feel free to ⭐ the repository.
