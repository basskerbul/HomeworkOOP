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
        private int accountNumber;
        private int balance;
        private AccountType _type;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        //    Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета
        //    (использовать перечислимый тип). Предусмотреть методы для доступа к данным – заполнения и чтения.
        //    Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
            
            BancAccount bancAccount = new BancAccount();
            bancAccount.AccountNumber = 104;
            bancAccount.Balance = 1500;
            bancAccount._Type = AccountType.Frozen_Account;

            Console.WriteLine($"Номер счёта: {bancAccount.AccountNumber} \nБаланс: {bancAccount.Balance}\nТип счёта: {bancAccount._Type}");
            Console.ReadKey();
        }
    }
}
