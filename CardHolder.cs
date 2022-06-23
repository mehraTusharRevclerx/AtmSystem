using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmSystem
{
    public class CardHolder
    {
        List<string> previousTrans = new List<string>();
        private long cardNum;
        public long CardNum
        {
            get => cardNum;
            set => cardNum = value;
        }

        private int count;
        public int Count
        {
            get => count;
            set => count = value;
        }
        private int cardPin;
        public long CardPin
        {
            get => cardPin;
            set => cardPin = (int)value;
        }
        private string cardName;

        public string CardName
        {
            get => cardName;
            set => cardName = value;
        }
        private double cardBalance;
        public double CardBalance
        {
            get => cardBalance;
            set => cardBalance = value;
        }
        private int cashAvailability;
        public int CashAvailability
        {
            get => cashAvailability;
            set => cashAvailability = value;
        }
        public List<string> PreviousTrans { get => previousTrans; set => previousTrans = value; }


        public CardHolder(string cardName, long cardNum, int cardPin, double cardBalance)
        {
            CardNum = cardNum;
            CardPin = cardPin;
            CardName = cardName;
            CardBalance = cardBalance;
            CashAvailability = 20000;
            count = 0;
        }

        public CardHolder()
        {
            CardNum = 0;
            CardPin = 0;
            CardName = "No Name";
            CardBalance = 0;
            CashAvailability = 20000;
            count = 0;
        }

        public void CardWithdrawal(int Withdrawal)
        {
            CardBalance -= Withdrawal;
            CashAvailability -= Withdrawal;
        }

        public void ChangePass(int pass)
        {
            CardPin = pass;
        }




    }
}
