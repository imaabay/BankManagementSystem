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
            Console.Clear();
            Console.WriteLine("\t\t╔=================================================╗");
            Console.WriteLine("\t\t|      WELCOME TO SIMPLE BANKING SYSTEM           |");
            Console.WriteLine("\t\t|=================================================|");
            Console.WriteLine("\t\t|             LOGIN TO START                      |");
            Console.WriteLine("\t\t|                                                 |");
            Console.Write("\t\t|  User Name:  ");
            int userNameCursorX = Console.CursorTop;
            int userNameCursorY = Console.CursorLeft;
            Console.Write("\t\t                          |");
            Console.Write("\n\t\t|  Password: ");
            int passwordCursorX = Console.CursorTop;
            int passwordCursorY = Console.CursorLeft;
            Console.Write("                                     |");
            Console.WriteLine("\n\t\t╚=================================================╝");

            string fileName = "login.txt";

            Console.SetCursorPosition(userNameCursorY, userNameCursorX);
            string userName = Console.ReadLine();

            Console.SetCursorPosition(passwordCursorY, passwordCursorX);
            string password = MaskPassword();
            
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
                            Console.WriteLine("\n\n\t\t  Valid credentials!... Please enter");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("\n\n\t\t  Invalid credentials!... Please retry!");
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
                Console.WriteLine("Invalid credentials!... Please retry!");
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
