using DigitalBank.Core.Contracts;
using DigitalBank.Core.Services;

namespace DigitalBank.Test.Core.Entities
{
    [TestClass]
    public class AccountTest
    {
        // Positive Test Case
      [TestMethod]
        public void Account_VaildOpeningBalance_ShouldSucceed()
        {
            //Arrange
            var owner = new Owner("Avishak", "Kumar");
            var openingBalance = new Amount { Value = 500, Currency = CurrencyType.INR };
            ulong expectedAccountNumber= 1000000000000000;

            //Act
            var account = new Account(owner, openingBalance);

            //Assert
            Assert.AreEqual<decimal>(openingBalance.Value,account.Balance);
            Assert.AreEqual("Initial amount.",account.Transactions.First().Note);
            Assert.AreEqual(expectedAccountNumber,account.Number);
        }

        // Negative Test Case
        [TestMethod]
        public void Account_InVaildOpeningBalance_ShouldSucceed()
        {
            // Arrange
            var owner = new Owner("Avishak", "Kumar");
            var openingBalance=new Amount { Value = 300, Currency = CurrencyType.INR };

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Account(owner, openingBalance));
        }

        // Positive Test Case
        [TestMethod]
        public void Deposit_VaildAmount_ShouldSuccees()
        {
            // Arrange
            decimal depositAmount = 300;
            decimal expectedBalance = 800;
            var account = new Account(new Owner("Avishek", "Kumar"),new Amount { Value=500,Currency=CurrencyType.INR});

            // Act
            var depositResult = account.Deposite(new Amount { Value = depositAmount, Currency = CurrencyType.INR },DateTime.Now,"Depositing vaild Amount ");

            // Assert
            Assert.IsTrue(depositResult);
            Assert.AreEqual(expectedBalance,account.Balance);
        }

        // Negative Test Case
        [DataTestMethod]
        [DataRow(0d)]
        [DataRow(-1.5)]

        public void Deposit_AmountZeroOrLess_ShouldThrowError(double depositAmount)
        {
            // Arrange
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> account.Deposite(new Amount { Value =(decimal) depositAmount, Currency = CurrencyType.INR }, DateTime.Now, "Depositing vaild Amount ")); 
        }

        // Positive Test Case
        [TestMethod]
        public void Withdraw_VaildAmount_ShouldScceed()
        {
            // Arrange
            decimal withdrawAmount = 200;
            decimal expectedAmount = 300;
            var account=new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act
            var withdrawResult = account.Withdraw(new Amount { Value = withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Withdrawing Vaild Amount");

            // Assert
            Assert.IsTrue(withdrawResult);
            Assert.AreEqual(expectedAmount, account.Balance);
        }

        // Negative Test Case
        [TestMethod]
        [DataRow(0d)]
        [DataRow(-1.5)]
        public void Withdraw_AmountZeroOrLess_ShouldScceed(double withdrawAmount)
        {
            // Arrange
            var account=new Account(new Owner("Avishak","Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act & Assert
            if (withdrawAmount<=0)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(new Amount { Value = (decimal)withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Withdrawing Vaild Amount"));
            }
            else if(withdrawAmount>500)
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(new Amount { Value = (decimal)withdrawAmount, Currency = CurrencyType.INR }, DateTime.Now, "Withdrawing Vaild Amount"));
        }

        // Positive Test Case
        [TestMethod]
        public void TransactionHistory_VaildAmount_ShouldScceed()
        {
            // Arrange
            var description = $"All transaction history for {DateTime.Now.ToShortDateString()}";
            var account = new Account(new Owner("Avishak", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });
            ITransactionService transactionService = new TransactionService();

            // Act
            var transactionHistory = transactionService.GetTransactionHistory(account.Transactions);
            var matchingNoteFound = transactionHistory.TransactionHistory.Contains("Initial amount.", StringComparison.CurrentCultureIgnoreCase);

            // Assert
            Assert.AreEqual(description, transactionHistory.Description);
            Assert.IsTrue(matchingNoteFound);


        }
    }
}
