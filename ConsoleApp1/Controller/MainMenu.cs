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
            Console.Write(Rectangle.DrawRectangle("\n1. Create a new account \n2. Search for an account \n3. Deposit" +
                "\n4. Withdraw \n5. A/C statement \n6. Delete account \n7. Exit"));
        }

        public void GetBankingOption()
        {
            Helper helper = new Helper();

            var validResponses = new List<string> { "1", "2", "3", "4", "5", "6", "7" };
            var userInput = helper.GetUserInput("Enter you choice (1:7) : ", validResponses);

            int i;
            bool success = int.TryParse(userInput, out i); //check if user input is an integer


            if (success && !string.IsNullOrEmpty(userInput) && !string.IsNullOrWhiteSpace(userInput))
            {
                userOption = (BankingOptions)Convert.ToInt32(userInput);
            }
        }

    }
}
