using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmSystem
{
    public class CardHolder : IinstaMoney, IUser
    {
        List<string> previousTrans = new List<string>();
        private long cardNum;
        long IUser.CardNum
        {
            get => cardNum;
            set => cardNum = value;
        }
        private int count;
        int IUser.Count
        {
            get => count;
            set => count = value;
        }
        private int cardPin;
        long IUser.CardPin
        {
            get => cardPin;
            set => cardPin = (int)value;
        }
        private string cardName;
        string IUser.CardName
        {
            get => cardName;
            set => cardName = value;
        }
        private double cardBalance;
        double IUser.CardBalance
        {
            get => cardBalance;
            set => cardBalance = value;
        }
        private int cashAvailability;
        int IinstaMoney.CashAvailability
        {
            get => cashAvailability;
            set => cashAvailability = value;
        }
        public List<string> PreviousTrans { get => previousTrans; set => previousTrans = value; }
        public CardHolder(string cardName, long cardNum, int cardPin, double cardBalance)
        {
            ((IUser)this).CardNum = cardNum;
            ((IUser)this).CardPin = cardPin;
            ((IUser)this).CardName = cardName;
            ((IUser)this).CardBalance = cardBalance;
            ((IinstaMoney)this).CashAvailability = 20000;
            count = 0;
        }
        public CardHolder()
        {
            ((IUser)this).CardNum = 0;
            ((IUser)this).CardPin = 0;
            ((IUser)this).CardName = "No Name";
            ((IUser)this).CardBalance = 0;
            ((IinstaMoney)this).CashAvailability = 20000;
            count = 0;
        }
        public void CardWithdrawal(int Withdrawal)
        {
            ((IUser)this).CardBalance -= Withdrawal;
            ((IinstaMoney)this).CashAvailability -= Withdrawal;
        }
        public void ChangePass(int pass)
        {
            ((IUser)this).CardPin = pass;
        }
        public void CashDeposit(double deposit)
        {
            ((IUser)this).CardBalance += deposit;
            Console.WriteLine($"Thank You\nYour {deposit} Rupees Has Been Deposit");
            Console.WriteLine($"Now Your Current Balance is: {this.cardBalance}");
        }
    }
}
