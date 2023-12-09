using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_FinalTest
{
    public class VisaAccount : Account, ITransaction
    {
        private double creditLimit;
        private static readonly double INTEREST_RATE = 0.1995;

        public VisaAccount(double balance = 0, double creditLimit = 1200)
            : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person); // Payment to the account decreases the balance (or increases credit)
        }

        public void DoPurchase(double amount, Person person)
        {
            if (!IsUser(person.Name))
            {
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if (!person.IsAuthenticated)
            {
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            }
            if (Balance - amount < -creditLimit)
            {
                throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            base.Deposit(-amount, person); // Purchase increases the balance (or decreases credit)
        }

        public override void PrepareMonthlyStatement()
        {
            double interest = (LowestBalance < 0 ? LowestBalance : 0) * INTEREST_RATE / 12;
            Balance -= interest; // Subtracting interest from balance, as it's a liability
            transactions.Clear();
        }

        public void Withdraw(double amount, Person person)
        {
            throw new NotImplementedException();
        }
    }

}
