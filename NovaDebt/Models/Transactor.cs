using NovaDebt.Models.Contracts;

namespace NovaDebt.Models
{
    public class Transactor : ITransactor
    {
        private int id;
        private string name;
        private string phoneNumber;
        private string email;
        private string facebook;
        private decimal amount;
        private string transactorType;

        public Transactor()
        {
        }

        public Transactor(int id, string name, string phoneNumber, string email, string facebook, decimal amount, string transactorType)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.facebook = facebook;
            this.amount = amount;
            this.transactorType = transactorType;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
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
            set { this.transactorType = value; }
        }
    }
}
