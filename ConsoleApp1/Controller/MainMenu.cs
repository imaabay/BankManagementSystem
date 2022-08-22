using System;
using System.Collections.Generic;
using System.Text;
using BankManagementSystem.View;

namespace BankManagementSystem.Controller
{
    class MainMenu
    {
        public void mainMenuUI()
        {
            Console.Write(Rectangle.DrawRectangle("\n1. Create a new account \n2. Search for an account \n3. Deposit" +
                "\n4. Withdraw \n5. A/C statement \n6. Delete account \n7. Exit"));
        }

        public void getBankingOption()
        {
            Console.Write("Enter you choice (1:7) : ");
            var option = Console.ReadLine();

            if(!string.IsNullOrEmpty(option) && !string.IsNullOrWhiteSpace(option))
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine('1');
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    case "3":
                        Console.WriteLine('3');
                        break;
                    case "4":
                        Console.WriteLine('4');
                        break;
                    case "5":
                        Console.WriteLine('5');
                        break;
                    case "6":
                        Console.WriteLine('6');
                        break;
                    case "7":
                        Console.WriteLine('7');
                        break;
                }

            }
            
        }

    }
}
