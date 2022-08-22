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

                bool isValidLogin = login.loginUser();

                if (isValidLogin)
                {
                    helper.PressOnlyEnter();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.mainMenuUI();
                    mainMenu.getBankingOption();
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            

          

            
           
        }
    }
}
