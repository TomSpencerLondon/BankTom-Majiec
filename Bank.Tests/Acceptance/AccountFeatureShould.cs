using NUnit.Framework;

namespace Bank.Tests.Acceptance




// Given a client makes a deposit of 1000 on 10-01-2012
// And a deposit of 2000 on 13-01-2012
// And a withdrawal of 500 on 14-01-2012

// Date       || Amount || Balance
// 14/01/2012 || -500   || 2500
// 13/01/2012 || 2000   || 3000
// 10/01/2012 || 1000   || 1000

{
    public class AccountFeatureShould
    {
        private AccountService _accountService;
        
        [SetUp()]
        public void Initialize()
        {
            _accountService = new AccountService();
        }
        
        [Test]
        public void print_statement()
        {
            // given
            
            // when
            _accountService.Deposit(1000);
            _accountService.Deposit(2000);
            _accountService.Withdraw(500);
            
            // then
            Assert.AreEqual(
                "Date | Amount | Balance" +
                "14/01/2012 | -500 | 2500" +
                "13/01/2012 | 2000 | 3000" +
                "10/01/2012 | 1000 | 1000",
                _accountService.PrintStatement());
        }
    }
}