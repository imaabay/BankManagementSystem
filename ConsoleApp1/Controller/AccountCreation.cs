using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using BankManagementSystem.Model;
using BankManagementSystem.Controller.Utils;

namespace BankManagementSystem.Controller
{
    class AccountCreation
    {
        public void AccountCreationForm(Helper helper)
        {
         
            AccountDetails accountDetails = new AccountDetails();

            AccountDetailsUI(accountDetails);

            Console.Write("\n\t\t Is the information correct (y/n)? ");
            int optionCursorX = Console.CursorTop;
            int optionCursorY = Console.CursorLeft;

            Console.SetCursorPosition(optionCursorY, optionCursorX);
            string optionYN = Console.ReadLine();

            try
            {
                do
                {
                    if (optionYN.ToLower() == "y")
                    {

                        bool inputValidation = isValidAccountDetails(accountDetails);

                        if (inputValidation)
                        {
                            CreateNewAccount(accountDetails);
                        }
                        else
                        {
                            Console.WriteLine("\t\t Error ");
                        }

                    }
                } while (optionYN.ToLower() == "n");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           

            

        }

        public void AccountDetailsUI(AccountDetails accountDetails)
        {
            Console.Clear();
            Console.WriteLine("\t\t╔=================================================╗");
            Console.WriteLine("\t\t|             CREATE A NEW ACCOUNT                |");
            Console.WriteLine("\t\t|=================================================|");
            Console.WriteLine("\t\t|              ENTER THE DETAILS                  |");
            Console.WriteLine("\t\t|                                                 |");
            Console.Write("\t\t|  First Name: ");
            int firstNameCursorX = Console.CursorTop;
            int firstNameCursorY = Console.CursorLeft;
            Console.Write("\t\t                          |");
            Console.Write("\n\t\t|  Last Name: ");
            int lastNameCursorX = Console.CursorTop;
            int lastNameCursorY = Console.CursorLeft;
            Console.Write("                                    |");
            Console.Write("\n\t\t|  Address: ");
            int addressCursorX = Console.CursorTop;
            int addressCursorY = Console.CursorLeft;
            Console.Write("\t\t                          |");
            Console.Write("\n\t\t|  Phone:    ");
            int phoneCursorX = Console.CursorTop;
            int phoneCursorY = Console.CursorLeft;
            Console.Write("                                     |");
            Console.Write("\n\t\t|  Email:    ");
            int emailCursorX = Console.CursorTop;
            int emailCursorY = Console.CursorLeft;
            Console.Write("\t\t                          |");
            Console.WriteLine("\n\t\t╚=================================================╝");

            Console.SetCursorPosition(firstNameCursorY, firstNameCursorX);
            string firstName = Console.ReadLine();

            Console.SetCursorPosition(lastNameCursorY, lastNameCursorX);
            string lastName = Console.ReadLine();

            Console.SetCursorPosition(addressCursorY, addressCursorX);
            string address = Console.ReadLine();

            Console.SetCursorPosition(phoneCursorY, phoneCursorX);
            string phone = Console.ReadLine();

            Console.SetCursorPosition(emailCursorY, emailCursorX);
            string email = Console.ReadLine();

            accountDetails.firstName = firstName;
            accountDetails.lastName = lastName;
            accountDetails.address = address;
            accountDetails.phone = phone;
            accountDetails.email = email;
        }

        private bool isValidAccountDetails(AccountDetails accountDetails)
        {
            if(string.IsNullOrEmpty(accountDetails.firstName) && string.IsNullOrWhiteSpace(accountDetails.firstName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(accountDetails.lastName) && string.IsNullOrWhiteSpace(accountDetails.lastName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(accountDetails.address) && string.IsNullOrWhiteSpace(accountDetails.address))
            {
                return false;
            }

            if (string.IsNullOrEmpty(accountDetails.phone) && string.IsNullOrWhiteSpace(accountDetails.phone))
            {
                return false;
            }

            if (string.IsNullOrEmpty(accountDetails.email) && string.IsNullOrWhiteSpace(accountDetails.email))
            {
                return false;
            }

            return true;
        }

        private bool CreateNewAccount(AccountDetails account)
        {
            try
            {
                //get all existing account numbers
                IEnumerable<int> existingAccountNumbers = Directory.GetFiles(@"..\..\..\Database\AccountDetails", "*.txt")
                    .Select(file => int.Parse(Regex.Replace(Path.GetFileName(file), @".txt$", "")));

                string accountNumber = GenerateUniqueAccountNumber(existingAccountNumbers);

                string filePath = $@"..\..\..\Database\AccountDetails\{accountNumber}.txt";

                File.Create(filePath).Close(); //create a blank file

                string[] accountDetails =
                {
                    $"Account Number|{accountNumber}",
                    $"Account Balance|0",
                    $"First Name|{account.firstName}",
                    $"Last Name|{account.lastName}",
                    $"Address|{account.address}",
                    $"Phone|{account.phone}",
                    $"Email|{account.email}"
                };

                File.WriteAllLines(filePath, accountDetails);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateUniqueAccountNumber(IEnumerable<int> existingAccountNumbers)
        {
            Random generateNumber = new Random();
            int uniqueAccountNumber;

            do
            {
                uniqueAccountNumber = generateNumber.Next(100000, 10000000);
            } while (existingAccountNumbers != null && existingAccountNumbers.Any() && existingAccountNumbers.Contains(uniqueAccountNumber));

            return uniqueAccountNumber.ToString();
        }
    }
}
