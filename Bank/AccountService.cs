using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace Bank
{
    public class AccountService
    {
        private int currentBalance = 0;

        List<Transaction> deposits = new List<Transaction>();
        
        public const string Header = "Date | Amount | Balance";
        public String PrintStatement()
        {
            StringBuilder result = new StringBuilder();

            deposits.Reverse();
            
            deposits.ForEach(d =>
            {
                result.Append("18/08/2019 | ");
                result.Append(d.Amount + " | ");
                result.Append(d.CurrentBalance + "\n");
            });
            
            return Header + "\n" + result.ToString().Trim();;
        }

        public void Deposit(int amount)
        {
            currentBalance += amount;
            deposits.Add(new Transaction(amount, currentBalance));
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }
    }
}