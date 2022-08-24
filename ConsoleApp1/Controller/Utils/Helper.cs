using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankManagementSystem.Controller.Utils
{
    class Helper
    {
        public void PressOnlyEnter()
        {
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                Console.Clear();
            } while (key.Key != ConsoleKey.Enter);
        }

        public string GetUserInput(string prompt, List<string> validInputs)
        {
            Console.Write(prompt);

            //Capture the cursor position
            var inputCursorLeft = Console.CursorLeft;
            var inputCursorTop = Console.CursorTop;

            string userInput = Console.ReadLine();

            while(validInputs != null && !validInputs.Contains(userInput, StringComparer.OrdinalIgnoreCase))
            {
                Console.SetCursorPosition(inputCursorLeft, inputCursorTop);
                Console.Write(new string(' ', userInput.Length));
                Console.SetCursorPosition(inputCursorLeft, inputCursorTop);

                userInput = Console.ReadLine();
            }

            return userInput;


        }
    }
}
