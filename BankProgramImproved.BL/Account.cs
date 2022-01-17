using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgramImproved.BL
{
    public enum AccountTypes
    {
        Checking, Investment, CorporateInvestment, IndividualInvestment
    }

    public class Account
    {
        private Owner _owner;
        private decimal _balance;
        private decimal _withdrawalLimit;
        private AccountTypes _bankAccountType;

        public Account(Owner owner, decimal balance, AccountTypes accountType)
        {
            _owner = owner;
            _balance = balance;
            _bankAccountType = accountType;

        }

        public Owner Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
            }

        }

        public decimal Balance
        {
            get
            {
                return _balance;

            }
            set
            {
                _balance = value;
            }
        }

        public decimal WithDrawalLimit
        {
            get
            {
                return _withdrawalLimit;
            }
            set
            {
                _withdrawalLimit = value;
            }
        }

        public AccountTypes BankAccountType
        {
            get
            {
                return _bankAccountType;
            }
            set
            {
                _bankAccountType = value;
            }
        }


    }
}
