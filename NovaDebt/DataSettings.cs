using System.IO;
using System.Reflection;

namespace NovaDebt
{
    public static class DataSettings
    {
        public static string DefaultAssemblyPath { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TransactorsFileName { get; } = "\\transactors.xml";

        public static string IdCounterFileName { get; } = "\\idcounter.txt";

        public static string TransactorsFilePath { get; } = DefaultAssemblyPath + TransactorsFileName;

        public static string XmlRoot { get; } = "Transactors";

        public static string XmlRootOpenClose { get; } = "<Transactors>\n</Transactors>";

        public static string IdCounterSeed { get; } = "1";

        public static string IdCounterFilePath { get; } = DefaultAssemblyPath + IdCounterFileName;

        public static decimal MinAmountValue { get; } = 0.01m;

        public static decimal MaxAmountValue { get; } = 4294967295m;

        public static decimal MinInterestCurrencyValue { get; } = 0.00m;

        public static decimal MaxInterestCurrencyValue { get; } = 4294967295m;

        public static decimal MinInterestPercentageValue { get; } = 0.00m;

        public static decimal MaxInterestPercentageValue { get; } = 4096.00m;

        public static class TableColumn
        {
            public static string No { get; } = "№";

            public static string Name { get; } = "Име";

            public static string Since { get; } = "От";

            public static string DueDate { get; } = "До";

            public static string PhoneNumber { get; } = "Тел №";

            public static string Email { get; } = "Имейл";

            public static string Facebook { get; } = "Фейсбук";

            public static string Amount { get; } = "Количество в лв.";
        }

        public static class MessageBoxCaption
        {
            public static string Confirm { get; } = "Потвърди";

            public static string Error { get; } = "Грешка";

            public static string Exit { get; } = "Изход";
        }

        public static class MessageBoxText
        {
            public static string DeleteConfirmationSingular { get; } = "Изтрий записа?";

            public static string DeleteConfirmationPlural { get; } = "Изтрий избраните записи?";

            public static string ExitConfirmation { get; } = "Наистина ли искате да излезете?";

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

            public static string InvalidSinceDate { get; } = "Началният срок не може да е след крайния.";

            public static string InvalidDueDate { get; } = "Крайният срок не може да е преди началния.";

            public static string InvalidPhoneNumber { get; } = "Невалиден Тел №.";

            public static string InvalidEmail { get; } = "Невалиден Имейл.";

            public static string InvalidFacebook { get; } = "Невалиден Фейсбук.";

            public static string MissingAmount { get; } = "Количеството е задължително.";

            public static string InvalidAmount { get; } = "Невалидно количество.";

            public static string InvalidInterestCurrencyInterval { get; } = "Количествената лихва трабва да е в интервала {0} - {1}.";

            public static string InvalidInterestPercentageInterval { get; } = "Процентната лихва трябва да е в интервала {0} - {1}.";

            public static string InvalidInterestCurrency { get; } = "Невалидна лихва в левове.";

            public static string InvalidInterestPercentage { get; } = "Невалидна лихва в проценти.";

            public static string DetailsOverOneSelectedRecords { get; } = "Трябва да изберете един запис за детайли.";

            public static string EditOverOneSelectedRecords { get; } = "Трябва да изберете един запис за редакция.";
        }
    }
}
