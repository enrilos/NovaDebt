namespace NovaDebt.Models
{
    using NovaDebt.Models.Enums;

    public class Currency : ICurrency
    {
        public string Id { get; set; }

        public string Abbreviation { get; set; }
    }
}
