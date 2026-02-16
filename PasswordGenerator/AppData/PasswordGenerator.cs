using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PasswordGenerator.AppData
{
    public class PasswordGenerator
    {
        public static int PASSWORD_LENGTH { get; set; } = 16;

        private const string LOWER_CHARACTERS = "qwertyuiopasdfghjklzxcvbnm";
        private const string UPPER_CHARACTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string NUMBERS = "1234567890";
        private const string SYMBOLS = "!@#$%^&*()";

        private readonly List<string>  _patterns = new List<string>();

        public string Start(bool useLowerCase, bool useUpperCase, bool useNumber, bool useSymbols)
        {
            _patterns.Clear();

            if (useLowerCase) _patterns.Add(LOWER_CHARACTERS);
            if (useUpperCase) _patterns.Add(UPPER_CHARACTERS);
            if (useNumber) _patterns.Add(NUMBERS);
            if (useSymbols) _patterns.Add(SYMBOLS);

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // Автоматически использует текущее значение слайдера!
            while (password.Length < PASSWORD_LENGTH)  // ← здесь значение со слайдера
            {
                int patternIndex = random.Next(_patterns.Count);
                int charIndexFromPattern = random.Next(_patterns[patternIndex].Length);
                password.Append(_patterns[patternIndex][charIndexFromPattern]);
            }

            return password.ToString();
        }
    }
}


