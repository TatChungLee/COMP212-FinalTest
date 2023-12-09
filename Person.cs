using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace COMP212_FinalTest
{
    public class Person
    {
        private string password;
        public string SIN { get; }
        public bool IsAuthenticated { get; private set; }
        public string Name { get; }

        public Person(string name, string sin)
        {
            Name = name;
            SIN = sin;
            password = sin.Substring(0, 3);
        }

        public void Login(string password)
        {
            if(this.password != password)
            {
                IsAuthenticated = false;
                throw new AccountException(AccountEnum.PASSWORD_INCORRECT);
            }
            else
            {
                IsAuthenticated = true;
            }
        }

        public void Logout()
        {
            IsAuthenticated=false;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
