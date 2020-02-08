using System.IO;
using System.Reflection;

namespace NovaDebt
{
    public static class DataSettings
    {
        public static string DefaultAssemblyPath { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string DefaultFileName { get; } = "\\transactors.xml";

        public static string DefaultFilePath { get; } = DefaultAssemblyPath + DefaultFileName;

        public static string DefaultXmlRoot { get; } = "Transactors";

        public static string DefaultXmlRootOpenClose { get; } = "<Transactors>\n</Transactors>";

        public static string DefaultCurrencySymbol { get; } = " лв.";

        public static decimal MinAmountValue { get; } = 0.01m;

        public static decimal MaxAmountValue { get; } = 4294967295m;

        public static class TableColumn
        {
            public static string No { get; } = "№";

            public static string Name { get; } = "Име";

            public static string PhoneNumber { get; } = "Тел №";

            public static string Email { get; } = "Имейл";

            public static string Facebook { get; } = "Фейсбук";

            public static string Amount { get; } = "Количество";
        }

        public static class MessageBoxCaption
        {
            public static string Confirm { get; } = "Потвърди";

            public static string Error { get; } = "Грешка";

            public static string Exit { get; } = "Изход";
        }

        public static class MessageBoxText
        {
            public static string DeleteConfirmation { get; } = "Изтрий избраните записи?";

            public static string ExitConfirmation { get; } = "Данните няма да бъдат запазени.\nНаистина ли искате да излезете?";

        }

        public static class ErrorMessage
        {
            public static string PathCannotBeNull { get; } = "Path cannot be null.";

            public static string FileDoesntExist { get; } = "File doesn't exist.";

            public static string DataTableCannotBeNull { get; } = "Data table cannot be null.";

            public static string NameCannotBeNull { get; } = "Name cannot be null.";

            public static string InvalidAmountInterval { get; } = "Количеството трябва да е в интервала {0} - {1}.";

            public static string InvalidName { get; } = "Името може да се състои само от букви и цифри.";

            public static string MissingName { get; } = "Името e задължително.";

            public static string InvalidPhoneNumber { get; } = "Невалиден Тел №.";

            public static string InvalidEmail { get; } = "Невалиден Имейл.";

            public static string InvalidFacebook { get; } = "Невалиден Фейсбук.";

            public static string MissingAmount { get; } = "Количеството е задължително.";

            public static string InvalidAmount { get; } = "Невалидно количество.";
        }
    }
}
