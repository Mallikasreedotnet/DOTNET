namespace BankingAccount
{
    public class CreatingAccount
    {
        public long Account { get; private set; }
        
         static long _accountNumber = 10000000000;
        public CreatingAccount()
        {
            Account = _accountNumber;
            _accountNumber++;
        }
      
    }
}