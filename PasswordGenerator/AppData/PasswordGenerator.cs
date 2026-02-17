using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator.AppData
{
    public class PasswordGenerator
    {
        public static int PASSWORD_LENGTH { get; set; } = 16;

        private const string LOWER_CHARACTERS = "qwertyuiopasdfghjklzxcvbnm";
        private const string UPPER_CHARACTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string NUMBERS = "1234567890";
        private const string SYMBOLS = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        private static readonly Random _random = new Random();
        private static readonly List<string> _patterns = new List<string>();

        public static string Start(bool useLowerCase, bool useUpperCase, bool useNumber, bool useSymbols)
        {
            _patterns.Clear();

            if (useLowerCase) _patterns.Add(LOWER_CHARACTERS);
            if (useUpperCase) _patterns.Add(UPPER_CHARACTERS);
            if (useNumber) _patterns.Add(NUMBERS);
            if (useSymbols) _patterns.Add(SYMBOLS);

            if (_patterns.Count == 0)
                return string.Empty;

            StringBuilder password = new StringBuilder(PASSWORD_LENGTH);

            for (int i = 0; i < PASSWORD_LENGTH; i++)
            {
                int patternIndex = _random.Next(_patterns.Count);
                int charIndex = _random.Next(_patterns[patternIndex].Length);
                password.Append(_patterns[patternIndex][charIndex]);
            }

            return password.ToString();
        }
    }
}
