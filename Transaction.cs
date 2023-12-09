using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_FinalTest
{
    public class Transaction
    {
       public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person, DateTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }
        public override string ToString()
        {
            // Assuming you need to include the transaction type (Deposit or Withdraw) in the string
            string transactionType = Amount >= 0 ? "Deposit" : "Withdraw";
            return $"{transactionType}: Account {AccountNumber}, {Originator.Name}, Amount: {Amount}, Time: {Time.ToShortTimeString()}";
        }
    }
}
