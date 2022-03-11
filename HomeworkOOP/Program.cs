using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOOP
{
    public enum AccountType
    {
        Budget_Account,
        Currency_Account,
        Frozen_Account,
        Insured_Account,
        Current_Account,
        Correspondent_Account,
        Savings_Account,
    }
    public class BancAccount
    {
        //статическая переменная
        static private int accountNumber;
        private int balance;
        private AccountType _type;

        public int AccountNumber
        {
            get { return RandomAcNum(); }
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public AccountType _Type
        {
            get { return _type; }
            set { _type = value; }
        }
        //Метод
        private static int RandomAcNum()
        {
            Random random = new Random();
            string value = $"{random.Next()}";
            accountNumber = int.Parse(value);
            return accountNumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам 
            //и был уникальным. Для этого надо создать в классе статическую переменную и метод, который 
            //увеличивает значение этого переменной.

            BancAccount bancAccount = new BancAccount();
            bancAccount.Balance = 1500;
            bancAccount._Type = AccountType.Frozen_Account;

            Console.WriteLine($"Номер счёта: {bancAccount.AccountNumber} \nБаланс: {bancAccount.Balance}\nТип счёта: {bancAccount._Type}");
            Console.ReadKey();
        }
    }
}
