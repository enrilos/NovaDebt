using DataAnnotationsExtensions;
using NovaDebt.Models.Contracts;
using System.ComponentModel.DataAnnotations;

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

        [Key]
        [Required]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Required]
        [MaxLength(100)]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [Phone]
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        [Email]
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        [MaxLength(70)]
        public string Facebook
        {
            get { return this.facebook; }
            set { this.facebook = value; }
        }

        [Required]
        [Range(typeof(decimal), minimum: "0.01", maximum: "4294967295")]
        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        [Required]
        public string TransactorType
        {
            get { return this.transactorType; }
            set { this.transactorType = value; }
        }
    }
}
