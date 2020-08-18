using NUnit.Framework;

namespace Bank.Tests
{
    public class AccountServiceShould
    {
        AccountService _accountService = new AccountService();
        
        [Test]
        public void print_empty_statement()
        {
            Assert.AreEqual("Date | Amount | Balance", _accountService.PrintStatement());
        }

        [Test]
        public void store_deposit()
        {
            // Given
            
            // When
            _accountService.Deposit(100);

            // Then
            Assert.AreEqual("Date | Amount | Balance\n" +
                            "18/08/2019 | 100 | 100", _accountService.PrintStatement());
        }

        [Test]
        public void store_multiple_deposits_on_same_day()
        {
            // Given
            
            // When
            _accountService.Deposit(100);
            _accountService.Deposit(100);
            // Then
            Assert.AreEqual("Date | Amount | Balance\n" +
                            "18/08/2019 | 100 | 200\n" +
                            "18/08/2019 | 100 | 100", _accountService.PrintStatement());
        }

        [Test]
        public void deposit_then_store_withdrawal()
        {
            // Given
            _accountService.Deposit(1000);
            
            // When
            _accountService.Withdraw(200);
            
            
            // Then
            Assert.AreEqual("Date | Amount | Balance\n" +
                            "18/08/2019 | -200 | 800\n" +
                            "18/08/2019 | 1000 | 1000", _accountService.PrintStatement());
            
        }
    }
}