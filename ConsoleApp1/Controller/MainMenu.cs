using System;
using System.Collections.Generic;
using System.Text;
using BankManagementSystem.View;
using BankManagementSystem.Controller.Utils;

namespace BankManagementSystem.Controller
{
    public enum BankingOptions
    {
        CreateNewAccount = 1,
        SearchAccount = 2,
        Deposit = 3,
        Withdraw = 4,
        AccountStatement = 5,
        DeleteAccount = 6,
        Exit = 7
    }
    class MainMenu
    {
        private BankingOptions userOption;

        public BankingOptions UserOption { get => userOption; set => userOption = value; }
        public void MainMenuUI()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔=================================================╗");
            Console.WriteLine("\t\t|      WELCOME TO SIMPLE BANKING SYSTEM           |");
            Console.WriteLine("\t\t|=================================================|");
            Console.WriteLine("\t\t|             LOGIN TO START                      |");
            Console.WriteLine("\t\t|                                                 |");
            Console.WriteLine("\t\t|        1. Create a new account                  |");
            Console.WriteLine("\t\t|        2. Search for an account                 |");
            Console.WriteLine("\t\t|        3. Deposit                               |");
            Console.WriteLine("\t\t|        4. Withdraw                              |");
            Console.WriteLine("\t\t|        5. A/C statement                         |");
            Console.WriteLine("\t\t|        6. Delete account                        |");
            Console.WriteLine("\t\t|        7. Exit                                  |");
            Console.WriteLine("\t\t╚=================================================╝");
        }

        public void GetBankingOption()
        {
            Helper helper = new Helper();

            var validResponses = new List<string> { "1", "2", "3", "4", "5", "6", "7" };
            var userInput = helper.GetUserInput("\n\t\tEnter you choice (1:7) : ", validResponses);

            int i;
            bool success = int.TryParse(userInput, out i); //check if user input is an integer


            if (success && !string.IsNullOrEmpty(userInput) && !string.IsNullOrWhiteSpace(userInput))
            {
                userOption = (BankingOptions)Convert.ToInt32(userInput);
            }
        }

    }
}
