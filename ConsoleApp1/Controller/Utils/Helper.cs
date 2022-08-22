using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
