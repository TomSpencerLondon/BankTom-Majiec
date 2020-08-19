using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace Bank
{
    public class AccountService
    {
        private DateProvider _dateProvider;
        public const string Header = "Date | Amount | Balance";
        
        private int currentBalance = 0;
        private List<Transaction> transactions = new List<Transaction>();

        public AccountService(DateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        public String PrintStatement()
        {
            StringBuilder result = new StringBuilder();

            transactions.Reverse();
            
            transactions.ForEach(transaction =>
            {
                result.Append("\n");
                result.Append(transaction.Date);
                result.Append(" | ");
                result.Append(transaction.Amount);
                result.Append(" | ");
                result.Append(transaction.CurrentBalance);
            });
            
            return Header + result;
        }

        public void Deposit(int amount)
        {
            currentBalance += amount;
            transactions.Add(new Transaction(amount, currentBalance, _dateProvider.getCurrentDate()));
        }

        public void Withdraw(int amount)
        {
            if (currentBalance - amount < 0)
            {
                throw new NotEnoughFundsOnTheAccountException();
            }
            
            currentBalance -= amount;
            transactions.Add(new Transaction(-amount, currentBalance, _dateProvider.getCurrentDate()));
        }
    }
}