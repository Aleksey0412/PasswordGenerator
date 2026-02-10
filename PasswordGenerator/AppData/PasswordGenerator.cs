using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.AppData
{
    public class PasswordGenerator
    {
        private const int PASSWORD_LENGTH = 16;

        private const string LOWER_CHARACTERS = "qwertyuiopasdfghjklzxcvbnm";
        private const string UPPER_CHARACTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string NUMBERS = "1234567890";
        private const string SYMBOLS = "!@#$%^&*()";

        private readonly List<string>  _patterns = new List<string>();

        public PasswordGenerator(bool useLowerCase, bool useUpperCase, bool useNumber, bool useSymbols) 
        {
            if (useLowerCase) _patterns.Add(LOWER_CHARACTERS);
            if (useUpperCase) _patterns.Add(UPPER_CHARACTERS);
            if (useNumber) _patterns.Add(NUMBERS);
            if (useSymbols) _patterns.Add(SYMBOLS);
            
        
        }

        public string Start()
        {
            //генерируемый пароль
            string Password = string.Empty;
            //генератор случайных чисел
            Random random = new Random();

           while (Password.Length <= PASSWORD_LENGTH)
            {
                int patternIndex = random.Next(_patterns.Count);
                int charIndexFromPattern = random.Next(_patterns[patternIndex].Length);

                Password += _patterns[patternIndex][charIndexFromPattern];
            }

           return Password;
        }
    }
}


