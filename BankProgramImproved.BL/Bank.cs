using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgramImproved.BL
{
    public class Bank
    {
        public Bank(string bankName)
        {
            BankName = bankName;

        }

        public string BankName { get; private set; }

        private static void CheckNegativeAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
        }

        private static void CheckInsufficientFunds(Account fromAccount, decimal amount)
        {
            if (fromAccount.Balance - amount < 0)
            {
                throw new ArgumentException("Insufficient funds.");
            }
        }

        public Account CreateBankAccount(Owner owner, decimal initialDeposit, AccountTypes newAccountType)
        {
            CheckNegativeAmount(initialDeposit);
            Account newAccount;
            switch (newAccountType)
            {
                case AccountTypes.Checking:
                    newAccount = new Account(owner, initialDeposit, AccountTypes.Checking);
                    break;
                case AccountTypes.Investment:
                    newAccount = new Account(owner, initialDeposit, AccountTypes.Investment);
                    break;
                case AccountTypes.IndividualInvestment:
                    newAccount = new Account(owner, initialDeposit, AccountTypes.IndividualInvestment);
                    break;
                case AccountTypes.CorporateInvestment:
                    newAccount = new Account(owner, initialDeposit, AccountTypes.CorporateInvestment);
                    break;
                default: throw new ArgumentException("Account type not defined.");

            }
            owner.AddAccounts(newAccount);
            return newAccount;

        }

        public List<Account> GetOwnerAccounts(Owner owner)
        {
            return owner.OwnerAccounts;
        }

        public void Deposit(Account toAccount, decimal amount)
        {
            CheckNegativeAmount(amount);
            toAccount.Balance = toAccount.Balance + amount;
        }

        public void Withdraw(Account fromAccount, decimal amount)
        {
            CheckNegativeAmount(amount);
            CheckInsufficientFunds(fromAccount, amount);
            if (fromAccount.BankAccountType == AccountTypes.IndividualInvestment && amount > 500)
            {
                throw new ArgumentException("Withdrawal limit reached.");
            }

            fromAccount.Balance = fromAccount.Balance - amount;

        }

        public void Transfer(Account toAccount, Account fromAccount, decimal amount)
        {
            CheckNegativeAmount(amount);
            CheckInsufficientFunds(fromAccount, amount);
            if (amount > 0 && (fromAccount.Balance - amount) > 0)
            {
                Withdraw(fromAccount, amount);
                Deposit(toAccount, amount);
            }
        }


    }
}
