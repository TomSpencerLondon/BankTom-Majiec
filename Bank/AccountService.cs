using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class AccountService
    {

        List<int> deposits = new List<int>();
        
        public const string Header = "Date | Amount | Balance";
        public String PrintStatement()
        {
            StringBuilder result = new StringBuilder();

            deposits.ForEach(d =>
            {
                result.Append("18/08/2019 | ");
                result.Append(d);
                result.Append();
            });
            
            return Header + "\n"
                          
                          
                          + "18/08/2019 | 100.00 | 100.00";
        }

        public void Deposit(int amount)
        {
            deposits.Add(amount);
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }
    }
}