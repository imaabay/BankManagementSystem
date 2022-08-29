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
            Console.WriteLine("CREATE A NEW ACCOUNT\n");
            Console.WriteLine("ENTER THE DETAILS\n");

         
            AccountDetails accountDetails = new AccountDetails();

            AccountDetailsFields(accountDetails);

            bool inputValidation = isValidAccountDetails(accountDetails);

            Console.WriteLine(inputValidation);

            if (inputValidation)
            {
                CreateNewAccount(accountDetails);
            }
            



        }

        public void AccountDetailsFields(AccountDetails accountDetails)
        {
            Console.Write("First Name: ");
            int firstNameCursorX = Console.CursorTop;
            int firstNameCursorY = Console.CursorLeft;

            Console.Write("\nLast Name: ");
            int lastNameCursorX = Console.CursorTop;
            int lastNameCursorY = Console.CursorLeft;

            Console.Write("\nAddress: ");
            int addressCursorX = Console.CursorTop;
            int addressCursorY = Console.CursorLeft;

            Console.Write("\nPhone: ");
            int phoneCursorX = Console.CursorTop;
            int phoneCursorY = Console.CursorLeft;

            Console.Write("\nEmail: ");
            int emailCursorX = Console.CursorTop;
            int emailCursorY = Console.CursorLeft;

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
            if(!string.IsNullOrEmpty(accountDetails.firstName) && !string.IsNullOrWhiteSpace(accountDetails.firstName))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(accountDetails.lastName) && !string.IsNullOrWhiteSpace(accountDetails.lastName))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(accountDetails.address) && !string.IsNullOrWhiteSpace(accountDetails.address))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(accountDetails.phone) && !string.IsNullOrWhiteSpace(accountDetails.phone))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(accountDetails.email) && !string.IsNullOrWhiteSpace(accountDetails.email))
            {
                return true;
            }

            return false;
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
