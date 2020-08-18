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
                            "18/08/2019 | 100.00 | 100.00", _accountService.PrintStatement());
        }
    }
}