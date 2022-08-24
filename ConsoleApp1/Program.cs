using System;
using System.Text;
using BankManagementSystem.Controller;
using BankManagementSystem.View;
using BankManagementSystem.Controller.Utils;


namespace BankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write(Rectangle.DrawRectangle("WELCOME TO SIMPLE BANKING SYSTEM"));

            try
            {
                Login login = new Login();
                Helper helper = new Helper();

                bool isValidLogin = login.LoginUser();

                if (isValidLogin)
                {
                    helper.PressOnlyEnter();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.MainMenuUI();
                    

                    BankingOptions options;
                    mainMenu.GetBankingOption();
                    options = mainMenu.UserOption;

                    //check banking option and navigate to screen
                    switch (options)
                    {
                        case BankingOptions.CreateNewAccount:
                            {
                                helper.PressOnlyEnter();
                                AccountCreation accountCreation = new AccountCreation();
                                accountCreation.AccountCreationForm();
                            }
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            

          

            
           
        }
    }
}
