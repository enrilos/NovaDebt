namespace NovaDebt.Models.Contracts
{
    public interface ITransactor
    {
        int Id { get; }

        int No { get; }

        string Name { get; }

        string PhoneNumber { get; }

        string Email { get; }

        string Facebook { get; }

        decimal Amount { get; }

        string TransactorType { get; }
    }
}
