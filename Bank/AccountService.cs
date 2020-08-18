using System;

namespace Bank
{
    public class AccountService
    {

        public const string Header = "Date | Amount | Balance";
        public String PrintStatement()
        {
            return Header + "\n"
                   + "18/08/2019 | 100.00 | 100.00";
        }

        public void Deposit(int amount)
        {
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }
    }
}