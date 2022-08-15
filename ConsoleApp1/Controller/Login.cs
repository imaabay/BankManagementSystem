using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace BankManagementSystem.Controller
{
    class Login
    {
        public void loginUser()
        {
            string fileName = "login.txt";

            Console.WriteLine("User Name: ");
            var userName = Console.ReadLine();

            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            //Read the file
            try
            {
                //Check if the username of password is empty
                if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Entered");
                    string[] name = File.ReadAllLines(@"G:\UTS\.NET\Assignment1\BankManagementSystem\ConsoleApp1\Database\login.txt");

                    Console.WriteLine(name);
                }
                else
                {
                    Console.WriteLine("Invalid");
                }

            }
            catch
            {

            }
            //Create a flag if login is a success
            //Navigate to main ui


        }
    }
}
