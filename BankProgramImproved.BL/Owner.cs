using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgramImproved.BL
{
    public class Owner
    {
        private string _ownerName;
        private List<Account> _ownerAccounts;

        public Owner(string ownerName)
        {
            _ownerName = ownerName;
            _ownerAccounts = new List<Account>();
        }

        public List<Account> OwnerAccounts
        {
            get
            {
                return _ownerAccounts;
            }
            set
            {
                OwnerAccounts = value;
            }
        }

        public void AddAccounts(Account newAccount)
        {
            _ownerAccounts.Add(newAccount);
        }

        public string Name
        {
            get
            {
                return _ownerName;
            }

            set
            {
                _ownerName = value;
            }

        }
    }
}
