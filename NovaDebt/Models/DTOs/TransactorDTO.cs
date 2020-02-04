using System.Xml.Serialization;

namespace NovaDebt.Models.DTOs
{
    [XmlType("Transactor")]
    public class TransactorDTO
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("No")]
        public int No { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("Facebook")]
        public string Facebook { get; set; }

        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        [XmlElement("TransactorType")]
        public string TransactorType { get; set; }
    }
}
