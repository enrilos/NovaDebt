using DataAnnotationsExtensions;
using NovaDebt.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

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

        public Transactor()
        {
        }

        public Transactor(int id, string name, string phoneNumber, string email, string facebook, decimal amount)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.facebook = facebook;
            this.amount = amount;
        }

        [XmlElement("Id")]
        [Key]
        [Required]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [XmlElement("Name")]
        [Required]
        [MaxLength(100)]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [XmlElement("PhoneNumber")]
        [Phone]
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        [XmlElement("Email")]
        [Email]
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        [XmlElement("Facebook")]
        [MaxLength(70)]
        public string Facebook
        {
            get { return this.facebook; }
            set { this.facebook = value; }
        }

        [XmlElement("Amount")]
        [Required]
        [Range(typeof(decimal), minimum: "0.01", maximum: "4294967295")]
        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
    }
}
