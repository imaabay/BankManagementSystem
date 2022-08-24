using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq; //LINQ offers common syntax for querying any type of data source
using BankManagementSystem.Model;


namespace BankManagementSystem.Controller
{
    class Login
    {
        public bool LoginUser()
        {
            string fileName = "login.txt";

            Console.WriteLine("User Name: ");
            var userName = Console.ReadLine();

            Console.WriteLine("Password: ");
            //var password = Console.ReadLine();

            var password = MaskPassword();

            Console.WriteLine(" ");

            //Read the file
            try
            {
                //Check if the username of password is empty
                if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    List<UserCredentials> credentials = File.ReadAllLines($@"..\..\..\Database\{fileName}")
                        .Where(item => !string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        .Select(item => item.Split('|'))
                        .Select(item => new UserCredentials() { userName = item[0], password = item[1] }).ToList();

                    if(credentials.Count > 0) //check if file is empty
                    {
                        //compare input values with values in login.txt
                        bool validUsername = credentials.Where(item => item.userName == userName).Count() == 1;
                        bool validPassword = credentials.Where(item => item.password == password).Count() == 1;

                        if(validUsername && validPassword)
                        {
                            Console.WriteLine("Valid credentials!... Please enter");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Login Unsuccessful!");
                            return false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("File Empty");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    return false;
                }

            }
            catch
            {
                Console.WriteLine("Login Unsuccessful!");
                return false;
            }

            
        }

        private string MaskPassword()
        {
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");

                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return password;
        }

        public bool IsValidLogin(bool isvalidLogin)
        {
            return isvalidLogin;
        }
    }
}
