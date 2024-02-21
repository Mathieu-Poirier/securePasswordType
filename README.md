# Usage

The Password class in the securePasswordType library is designed to help enforce strong password policies by validating passwords against several security criteria. This document outlines how to use the Password class to validate passwords in your C# applications.

## Validating a Password

Call the Create Method: Use the Create method to attempt to create a Password object. The method checks if the input meets the security criteria and returns a Password object if it does. If the input does not meet the criteria, an ArgumentException is thrown.

Example:

```
using System;
using securePasswordType;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var password = Password.Create("ValidPassword123!");
            Console.WriteLine("Password is valid and has been successfully created.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid password: {ex.Message}");
        }
    }
}

```

## Security Criteria Enforced

Minimum Length: The password must be at least 12 characters long.
Character Diversity: It must include at least:
- One uppercase letter (A-Z)
- One lowercase letter (a-z)
- One digit (0-9)
- One special character (e.g., !, @, #, $, etc.)

## Example Usage

The following is an example of how to prompt a user for a password and validate it using the Password class:

```
Console.Write("Enter a password: ");
string userInput = Console.ReadLine();

try
{
    var password = Password.Create(userInput);
    Console.WriteLine("Password is valid.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

```

## Extension

The IsValid function is called to match characters. Separate functions can be added to handle each specific case or check for passwords that are too common.

```

private static bool IsValid(string password)
{
    // Check for minimum length of 8 characters and at least one alphanumeric character
    return password.Length >= 12 && password.Any(ch => !char.IsLetterOrDigit(ch)) && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit);
}

```