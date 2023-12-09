using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_FinalTest
{
    public abstract class Account
    {
        private static int LAST_NUMBER = 100000;
        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        public string Number { get; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }

        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
        }

        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }
            Transaction transaction = new Transaction(Number, amount, person, DateTime.Now);
            transactions.Add(transaction);
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(string name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void PrepareMonthlyStatement();

        public override string ToString()
        {
            string info = $"Account Number: {Number}\nBalance: {Balance}\nUsers: ";
            foreach (var user in users)
            {
                info += $"{user.Name} ";
            }
            info += "\nTransactions:\n";
            foreach (var transaction in transactions)
            {
                info += transaction.ToString() + "\n";
            }
            return info;
        }
    }

}
