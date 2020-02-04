using NovaDebt.Models.Contracts;
using System;

namespace NovaDebt.Models
{
    public class Transactor : ITransactor
    {
        private int id;
        private int no;
        private string name;
        private string phoneNumber;
        private string email;
        private string facebook;
        private decimal amount;
        private string transactorType;

        public Transactor()
        {
        }

        public Transactor(string name, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.facebook = facebook;
            this.amount = amount;
            this.transactorType = transactorType;
        }

        public Transactor(int no, string name, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
            : this(name, phoneNumber, email, facebook, amount, transactorType)
        {
            this.no = no;
        }

        public Transactor(int id, int no, string name, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
            : this(no, name, phoneNumber, email, facebook, amount, transactorType)
        {
            this.id = id;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int No
        {
            get { return this.no; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"{nameof(this.No)} cannot be less or equal to zero.");
                }

                this.no = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.Name)} cannot be null.");
                }

                this.name = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Facebook
        {
            get { return this.facebook; }
            set { this.facebook = value; }
        }

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public string TransactorType
        {
            get { return this.transactorType; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.TransactorType)} cannot be null.");
                }
                else if (value != "Debtor" || value != "Creditor")
                {
                    throw new InvalidOperationException($"{nameof(this.TransactorType)} should be either Debtor or Creditor.");
                }

                this.transactorType = value;
            }
        }
    }
}
