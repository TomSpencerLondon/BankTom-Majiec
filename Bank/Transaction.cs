namespace Bank
{
    public class Transaction
    {
        private readonly int _amount;
        private readonly int _currentBalance;
        private readonly string _date;

        public Transaction(int amount, int currentBalance, string date)
        {
            _amount = amount;
            _currentBalance = currentBalance;
            _date = date;
        }

        public string Date => _date;

        public int Amount => _amount;

        public int CurrentBalance => _currentBalance;
    }
}