using NovaDebt.Models.Contracts;

namespace NovaDebt.Models
{
    public class Currency : ICurrency
    {
        public string Id { get; set; }

        public string Abbreviation { get; set; }
    }
}
