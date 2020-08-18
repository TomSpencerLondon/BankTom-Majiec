namespace Bank
{
    public class Transaction
    {
        private readonly int _amount;
        private readonly int _currentBalance;

        public Transaction(int amount, int currentBalance)
        {
            _amount = amount;
            _currentBalance = currentBalance;
        }

        public int Amount => _amount;

        public int CurrentBalance => _currentBalance;
    }
}