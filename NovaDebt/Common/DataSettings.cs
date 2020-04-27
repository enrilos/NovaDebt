using NovaDebt.Models;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NovaDebt.Common
{
    public static class DataSettings
    {
        public static string ApplicationName = "NovaDebt";

        public static string DefaultAssemblyPath { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TransactorsFileName { get; } = "\\transactors.xml";

        public static string IdCounterFileName { get; } = "\\idcounter.txt";

        public static string UninstallerFileName { get; } = "\\uninstall.bat";

        public static string TransactorsFilePath { get; } = DefaultAssemblyPath + TransactorsFileName;

        public static string IdCounterFilePath { get; } = DefaultAssemblyPath + IdCounterFileName;

        public static string UninstallerFilePath { get; } = DefaultAssemblyPath + UninstallerFileName;

        public static string XmlRoot { get; } = "Transactors";

        public static string XmlElement { get; } = "Transactor";

        public static string XmlRootOpenClose { get; } = "<Transactors>\n</Transactors>";

        public static string IdCounterSeed { get; } = "1";

        // NOTE:
        // Product ID MUST BE CHANGED when making a new setup.
        public static string UninstallerSeed { get; } = "@echo off\nmsiexec /x {F3C2E03C-2250-42BA-944A-55245596295F}";

        public static Color DefaultButtonColor { get; } = Color.FromArgb(0, 208, 255);

        // Strange. When loading a font from elsewhere (method or class), the app sometimes malfunctions and throws ArugmentException - Parameter is not valid.
        // It just randomly occurs.
        public static Font DefaultFontTwelve => new Font("Idealist Sans", 12f);

        public static Font DefaultFontThirteen => new Font("Idealist Sans", 13.8f);

        public static Font DefaultFontFifteen => new Font("Idealist Sans", 15f);

        public static Font DefaultFontSixteen => new Font("Idealist Sans", 16.2f);

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
            public static string DeleteConfirmationSingular { get; } = "Изтрий записа?";

            public static string DeleteConfirmationPlural { get; } = "Изтрий избраните записи?";

            public static string ExitConfirmation { get; } = "Наистина ли искате да излезете?";

        }

        public static class ErrorMessage
        {
            public static string PathCannotBeNull { get; } = "Path cannot be null.";

            public static string FileDoesntExist { get; } = "File doesn't exist.";

            public static string DataTableCannotBeNull { get; } = "Data table cannot be null.";

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

        public static IEnumerable<Currency> GetCurrencies()
        {
            List<Currency> currencies = new List<Currency>();

            currencies.Add(new Currency() { Id = "01", Abbreviation = "BGN" });
            currencies.Add(new Currency() { Id = "02", Abbreviation = "EUR" });
            currencies.Add(new Currency() { Id = "03", Abbreviation = "USD" });
            currencies.Add(new Currency() { Id = "04", Abbreviation = "GBP" });
            currencies.Add(new Currency() { Id = "05", Abbreviation = "PLN" });
            currencies.Add(new Currency() { Id = "06", Abbreviation = "RON" });
            currencies.Add(new Currency() { Id = "07", Abbreviation = "TRY" });
            currencies.Add(new Currency() { Id = "08", Abbreviation = "RUB" });
            currencies.Add(new Currency() { Id = "09", Abbreviation = "CZK" });
            currencies.Add(new Currency() { Id = "10", Abbreviation = "NOK" });
            currencies.Add(new Currency() { Id = "11", Abbreviation = "SEK" });
            currencies.Add(new Currency() { Id = "12", Abbreviation = "CAD" });
            currencies.Add(new Currency() { Id = "13", Abbreviation = "CHF" });

            return currencies;
        }

        public static bool AreInputFieldsValid(TextBox nameTextBox, DateTimePicker sinceDatePicker, DateTimePicker dueDatePicker, TextBox phoneTextBox, TextBox emailTextBox, TextBox facebookTextBox, TextBox amountTextBox, CheckBox interestCheckBox, TextBox interestWithCurrencyTextBox, TextBox interestWithPercentageTextBox)
        {

            //
            // Име - Name (Required)
            //
            Regex latinRegex = new Regex("^[a-zA-Z0-9., ]*$");
            Regex cyrillicRegex = new Regex("^[АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0-9., ]*$");

            if (!latinRegex.IsMatch(nameTextBox.Text)
             && !cyrillicRegex.IsMatch(nameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else if (string.IsNullOrEmpty(nameTextBox.Text)
                  || string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.MissingName,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // От - Since (Required)
            //
            if (sinceDatePicker.Value > dueDatePicker.Value)
            {
                MessageBox.Show(ErrorMessage.InvalidSinceDate,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // До - Due Date (Required)
            //
            if (dueDatePicker.Value < sinceDatePicker.Value)
            {
                MessageBox.Show(ErrorMessage.InvalidDueDate,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Тел № - PhoneNumber
            //
            latinRegex = new Regex("^[+0-9-() ]*$");

            if (!latinRegex.IsMatch(phoneTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidPhoneNumber,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Имейл - Email
            //
            latinRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            if (!latinRegex.IsMatch(emailTextBox.Text.Trim())
                && !string.IsNullOrEmpty(emailTextBox.Text.Trim())
                && !cyrillicRegex.IsMatch(emailTextBox.Text.Trim()))
            {
                MessageBox.Show(ErrorMessage.InvalidEmail,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Фейсбук - Facebook
            //
            latinRegex = new Regex("^[A-z ]*$");

            if (!latinRegex.IsMatch(facebookTextBox.Text)
                && !cyrillicRegex.IsMatch(facebookTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.InvalidFacebook,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            //
            // Количество - Amount (Required)
            //
            latinRegex = new Regex("^[0-9]+([.,][0-9]{1,2})?$");
            decimal amount;

            if (latinRegex.IsMatch(amountTextBox.Text.Trim()))
            {
                amount = decimal.Parse(amountTextBox.Text);

                if (amount < MinAmountValue || amount > MaxAmountValue)
                {
                    MessageBox.Show(string.Format(ErrorMessage.InvalidAmountInterval, MinAmountValue, MaxAmountValue),
                           MessageBoxCaption.Error,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                    return false;
                }
            }
            else if (string.IsNullOrEmpty(amountTextBox.Text) || string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show(ErrorMessage.MissingAmount,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                MessageBox.Show(ErrorMessage.InvalidAmount,
                    MessageBoxCaption.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (interestCheckBox.Checked)
            {
                // Количествена лихва - Currency interest
                if (string.IsNullOrWhiteSpace(interestWithCurrencyTextBox.Text)
                    || string.IsNullOrEmpty(interestWithCurrencyTextBox.Text))
                {
                    interestWithCurrencyTextBox.Text = "0";
                }
                if (latinRegex.IsMatch(interestWithCurrencyTextBox.Text.Trim()))
                {
                    decimal currencyInterest = decimal.Parse(interestWithCurrencyTextBox.Text);

                    if (currencyInterest < MinInterestCurrencyValue || currencyInterest > MaxInterestCurrencyValue)
                    {
                        MessageBox.Show(string.Format(ErrorMessage.InvalidInterestCurrencyInterval, MinInterestCurrencyValue, MaxInterestCurrencyValue),
                               MessageBoxCaption.Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMessage.InvalidInterestCurrency,
                        MessageBoxCaption.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                // Процентна лихва - Percentage interest
                if (string.IsNullOrWhiteSpace(interestWithPercentageTextBox.Text)
                    || string.IsNullOrEmpty(interestWithPercentageTextBox.Text))
                {
                    interestWithPercentageTextBox.Text = "0";
                }
                if (latinRegex.IsMatch(interestWithPercentageTextBox.Text.Trim()))
                {
                    decimal percentageInterest = decimal.Parse(interestWithPercentageTextBox.Text);

                    if (percentageInterest < MinInterestPercentageValue || percentageInterest > MaxInterestPercentageValue)
                    {
                        MessageBox.Show(string.Format(ErrorMessage.InvalidInterestPercentageInterval, MinInterestPercentageValue, MaxInterestPercentageValue),
                           MessageBoxCaption.Error,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(ErrorMessage.InvalidInterestPercentage,
                        MessageBoxCaption.Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }
    }
}
