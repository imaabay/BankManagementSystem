using System;
using System.Text;
using BankManagementSystem.Controller;


namespace BankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO SIMPLE BANKING SYSTEM");
            Login login = new Login();

            login.loginUser();
            
           
        }
    }
}
