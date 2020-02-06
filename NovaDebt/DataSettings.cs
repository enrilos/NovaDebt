namespace NovaDebt
{
    public static class DataSettings
    {
        public const string DefaultFileName = "\\transactors.xml";

        public const string DefaultXmlRoot = "Transactors";

        public const string DefaultXmlRootOpenClose = "<Transactors>\n</Transactors>";

        public const string DefaultCurrencySymbol = " лв.";

        public const decimal MinAmountValue = 0.01m;

        public const decimal MaxAmountValue = 4294967295m;

        public static class TableColumn
        {
            public const string No = "№";

            public const string Name = "Име";

            public const string PhoneNumber = "Тел №";

            public const string Email = "Имейл";

            public const string Facebook = "Фейсбук";

            public const string Amount = "Количество";
        }

        public static class MessageBoxCaption
        {
            public const string Confirm = "Потвърди";

            public const string Error = "Грешка";

            public const string Exit = "Изход";
        }

        public static class MessageBoxText
        {
            public const string DeleteConfirmation = "Изтрий избраните записи?";

            public const string ExitConfirmation = "Данните няма да бъдат запазени.\nНаистина ли искате да излезете?";

        }

        public static class ErrorMessage
        {
            public const string PathCannotBeNull = "Path cannot be null.";

            public const string FileDoesntExist = "File doesn't exist.";

            public const string DataTableCannotBeNull = "Data table cannot be null.";

            public const string NameCannotBeNull = "Name cannot be null.";

            public const string InvalidAmountInterval = "Количеството трябва да е в интервала {0} - {1}.";

            public const string InvalidName = "Името може да се състои само от букви и цифри.";

            public const string MissingName = "Името e задължително.";

            public const string InvalidPhoneNumber = "Невалиден Тел №.";

            public const string InvalidEmail = "Невалиден Имейл.";

            public const string InvalidFacebook = "Невалиден Фейсбук.";

            public const string MissingAmount = "Количеството е задължително.";

            public const string InvalidAmount = "Невалидно количество.";
        }
    }
}
