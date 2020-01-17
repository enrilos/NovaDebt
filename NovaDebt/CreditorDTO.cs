using System.Xml.Serialization;

namespace NovaDebt
{
    [XmlType("Creditor")]
    public class CreditorDTO : Transactor
    {
        public CreditorDTO()
            : base()
        {
        }

        public CreditorDTO(int id, string name, string phoneNumber, string email, string facebook, decimal amount)
            : base(id, name, phoneNumber, email, facebook, amount)
        {
        }
    }
}
