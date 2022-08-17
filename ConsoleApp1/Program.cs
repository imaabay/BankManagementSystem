using System;
using System.Text;
using BankManagementSystem.Controller;
using BankManagementSystem.View;


namespace BankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //nsole.WriteLine("WELCOME TO SIMPLE BANKING SYSTEM");
            Login login = new Login();
            //Rectangle rectangle = new Rectangle();

            //ctangle.DrawRectangle("hellhghjghjgjghjgjhghjgjhghghghgjhgjgjggjg");
            Console.Write(Rectangle.DrawRectangle("WELCOME TO SIMPLE BANKING SYSTEM"));
            login.loginUser();
            
           
        }
    }
}
