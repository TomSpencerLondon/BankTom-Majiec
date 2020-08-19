using System;
using Moq;
using NUnit.Framework;

namespace Bank.Tests
{
    public class AccountServiceShould
    {
        private AccountService _accountService;
        private Mock<DateProvider> _dateProviderMock;

        [SetUp]
        public void Init()
        {
            _dateProviderMock = new Mock<DateProvider>();
            
            _dateProviderMock.Setup(dateProvider => dateProvider.getCurrentDate())
                .Returns("18/08/2019");
            
            _accountService = new AccountService(_dateProviderMock.Object);
        }
        
        [Test]
        public void print_empty_statement()
        {
            Assert.AreEqual("Date | Amount | Balance", _accountService.PrintStatement());
        }

        [Test]
        public void store_deposit()
        {
            // When
            _accountService.Deposit(100);

            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n18/08/2019 | 100 | 100", _accountService.PrintStatement());
        }
        
        [Test]
        public void store_deposit_on_different_days()
        {
            // Given
            _dateProviderMock.SetupSequence(dateProvider => dateProvider.getCurrentDate())
                .Returns("18/08/2019")
                .Returns("19/08/2019");
            
            // When
            _accountService.Deposit(100);
            _accountService.Deposit(100);

            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n19/08/2019 | 100 | 200" +
                            "\n18/08/2019 | 100 | 100", _accountService.PrintStatement());
        }

        [Test]
        public void store_multiple_deposits_on_same_day()
        {
            // Given
            
            // When
            _accountService.Deposit(100);
            _accountService.Deposit(100);
            
            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n18/08/2019 | 100 | 200" +
                            "\n18/08/2019 | 100 | 100", _accountService.PrintStatement());
        }

        [Test]
        public void deposit_then_store_withdrawal()
        {
            // Given
            _accountService.Deposit(1000);
            
            // When
            _accountService.Withdraw(200);
            
            
            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n18/08/2019 | -200 | 800" +
                            "\n18/08/2019 | 1000 | 1000", _accountService.PrintStatement());
            
        }
        
        [Test]
        public void deposit_then_store_multiple_withdrawals()
        {
            // Given
            _accountService.Deposit(1000);
            
            // When
            _accountService.Withdraw(200);
            _accountService.Withdraw(500);
            _accountService.Withdraw(300);
            
            
            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n18/08/2019 | -300 | 0" +
                            "\n18/08/2019 | -500 | 300" +
                            "\n18/08/2019 | -200 | 800" +
                            "\n18/08/2019 | 1000 | 1000", _accountService.PrintStatement());
            
        }

        [Test]
        public void deposit_then_withdraw_multiple_times()
        {
            // Given
            _accountService.Deposit(1000);
            _accountService.Deposit(1000);
            
            // When
            _accountService.Withdraw(200);
            _accountService.Withdraw(100);
            
            // Then
            Assert.AreEqual("Date | Amount | Balance" +
                            "\n18/08/2019 | -100 | 1700" +
                            "\n18/08/2019 | -200 | 1800" +
                            "\n18/08/2019 | 1000 | 2000" +
                            "\n18/08/2019 | 1000 | 1000", _accountService.PrintStatement());

        }

        [Test]
        public void fail_to_complete_withdrawal_transaction()
        {
            // When
            // Then
            Assert.Catch<NotEnoughFundsOnTheAccountException>(() => _accountService.Withdraw(100));
        }
    }
}