using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_FinalTest
{
    public class CheckingAccount : Account, ITransaction
    {
        private static readonly double COST_PER_TRANSACTION = 0.05;
        private static readonly double INTEREST_RATE = 0.005;
        private bool hasOverdraft;

        public CheckingAccount(double balance = 0, bool hasOverdraft = false)
            : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void Withdraw(double amount, Person person)
        {
            if (!IsUser(person.Name))
            {
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if (!person.IsAuthenticated)
            {
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            }
            if (amount > Balance && !hasOverdraft)
            {
                throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
            }

            base.Deposit(-amount, person); // Negative amount for withdrawal
        }

        public override void PrepareMonthlyStatement()
        {
            double serviceCharge = transactions.Count * COST_PER_TRANSACTION;
            double interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance += interest - serviceCharge;
            transactions.Clear();
        }
    }
}
