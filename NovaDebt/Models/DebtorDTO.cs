using System.Xml.Serialization;

namespace NovaDebt.Models
{
    [XmlType("Debtor")]
    public class DebtorDTO : Transactor
    {
        public DebtorDTO()
            : base()
        {
        }

        public DebtorDTO(int id, string name, string phoneNumber, string email, string facebook, decimal amount)
            : base(id, name, phoneNumber, email, facebook, amount)
        {
        }
    }
}
