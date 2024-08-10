using System;
using System.Text;

namespace HRMS.API.Utility;

public class PasswordGenerator
{
    private static readonly Random _random = new Random();

    public string GenerateRandomPassword(int length)
    {
        const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string nonAlphanumericChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        // En az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter olacak
        string allChars = upperCaseChars + lowerCaseChars + digits + nonAlphanumericChars;
        var password = new char[length];

        password[0] = upperCaseChars[_random.Next(upperCaseChars.Length)];
        password[1] = lowerCaseChars[_random.Next(lowerCaseChars.Length)];
        password[2] = digits[_random.Next(digits.Length)];
        password[3] = nonAlphanumericChars[_random.Next(nonAlphanumericChars.Length)];

        for (int i = 4; i < length; i++)
        {
            password[i] = allChars[_random.Next(allChars.Length)];
        }

        // Şifredeki karakterleri karıştır
        return new string(password.OrderBy(x => _random.Next()).ToArray());
    }
}
