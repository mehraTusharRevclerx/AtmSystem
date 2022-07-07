using System;
using System.Collections;
using System.Collections.Generic;
using AtmSystem;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AtmSystem
{
    public class Program
    {
        static void Main()
        {
            List<CardHolder> cardHolders = new List<CardHolder>
            {
                new CardHolder("tushar", 4532413825193257, 1234, 350000),
                new CardHolder("Komal", 4532833950366792, 2034, 10000),
                new CardHolder("sanjana", 4485365787512386, 8972, 5000),
                new CardHolder("salman", 4485365787412386, 2942, 20000)
            };

            UserInput(cardHolders);
            Console.ReadKey();
        }
        static void UserInput(List<CardHolder> cardHolders)
        {


            Console.WriteLine("Welcome To Instamoney");

            Console.WriteLine("Please Enter Your Card Number: ");
        returnToCardNum:;
            string inputCardNum = Console.ReadLine();
            while (!NumberValid(inputCardNum))
            {
                inputCardNum = Console.ReadLine();
            }

            CardHolder currUser = cardHolders.FirstOrDefault(x => ((IUser)x).CardNum == long.Parse(inputCardNum));
            while (currUser == null)
            {
                Console.WriteLine("Card Number Does Not Match Please Reenter");
                goto returnToCardNum;
            }


            Console.WriteLine("Please Enter Your Card Pin: ");
        returnToCardPin:;
            string inputCardPin = Console.ReadLine();
            while (!PinChanger.PinValid(inputCardPin))
            {
                inputCardPin = Console.ReadLine();
            }

            while (((IUser)currUser).CardPin != int.Parse(inputCardPin))
            {
                Console.WriteLine("Card Pin Does Not Match Please Reenter");
                goto returnToCardPin;
            }
            Console.WriteLine($"Welcome To Instamoney {((IUser)currUser).CardName}");
            int option = 0;
            do
            {
                PrintOption();
            returnToOptions:
                string options = Console.ReadLine();
                bool isvalid = int.TryParse(options, out option);
                while (!isvalid)
                {
                    Console.WriteLine("please Enter Correct Option");
                    goto returnToOptions;
                }

                switch (option)
                {
                    case 1:
                        CashDeposit(currUser);
                        break;
                    case 2:
                        CashAvailability(currUser);
                        break;
                    case 3:
                        PrevFiveTrans(currUser);
                        break;
                    case 4:
                        CashWithdrawal(currUser);
                        break;
                    case 5:
                        FastCashWithdrawal(currUser);
                        break;
                    case 6:
                        PinChanger.ChangePin(currUser);
                        break;
                    case 7:
                        Cancel();
                        break;
                }
            } while (option != 7);
        }
        static void PrevFiveTrans(CardHolder currUser)
        {



            if (currUser.PreviousTrans.Count <= 0)
            {
                Console.WriteLine("You Dont Have Any Transitons yet");
                return;

            }
            else if (currUser.PreviousTrans.Count > 5)
            {
                Console.WriteLine("Your Recent Five Transitions Are: ");
                if (currUser.PreviousTrans.Contains(currUser.PreviousTrans[currUser.PreviousTrans.Count - 5]))
                {

                    for (int j = currUser.PreviousTrans.Count - 1; j >= currUser.PreviousTrans.Count - 5; j--)
                    {

                        Console.WriteLine(currUser.PreviousTrans[j]);
                    }

                }
            }
            else if (currUser.PreviousTrans.Count <= 5)
            {
                Console.WriteLine("Your Recent Transitions Are: ");
                for (int j = currUser.PreviousTrans.Count; j >= 1; j--)
                {

                    Console.WriteLine(currUser.PreviousTrans[j - 1]);
                }
            }

        }
        static void CashAvailability(CardHolder currUser)
        {
            if (((IinstaMoney)currUser).CashAvailability >= 0)
            {
                Console.WriteLine($"Yes Cash is Avalibale Total Cash {((IinstaMoney)currUser).CashAvailability}");

            }
            else
            {
                Console.WriteLine($"sorry No Cash is Avalibale Total Cash {((IinstaMoney)currUser).CashAvailability}");
            }
        }
        static void Cancel()
        {
            Console.WriteLine("Thanks For Using Instamoney Please Visit Again\nPress Any Key To Exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
        static void CashWithdrawal(CardHolder currUser)
        {
            if (((IUser)currUser).Count != 10)
            {

                Console.WriteLine($"Your Current Balance is{((IUser)currUser).CardBalance}");
                Console.WriteLine($"How Much Cash You Want To Withdrawal: ");
            returnToWithdrawals:
                string Withdrawals = Console.ReadLine();
                bool isvalid = int.TryParse(Withdrawals, out int Withdrawal);

                while (!isvalid)
                {
                    Console.WriteLine($"Please Enter Correct Ammount: ");
                    goto returnToWithdrawals;
                }
                if (Math.Abs(Withdrawal) > 20000)
                {
                    Console.WriteLine($"You can Only Withdrawal less than 20000 At a time: ");
                    goto returnToWithdrawals;

                }
                if (Math.Abs(Withdrawal) > ((IUser)currUser).CardBalance || Math.Abs(Withdrawal) > ((IinstaMoney)currUser).CashAvailability)
                {
                    Console.WriteLine($"Not Enough Balance Please Renter The Amount: ");
                    goto returnToWithdrawals;
                }

                currUser.CardWithdrawal(Math.Abs(Withdrawal));
                currUser.PreviousTrans.Add($"Cash Withdrawal: {Math.Abs(Withdrawal)}");

                ((IUser)currUser).Count++;


                Console.WriteLine("Count " + ((IUser)currUser).Count);
                Console.WriteLine($"Thank You for Withdrawing Money \nNow Your Current Balance is {((IUser)currUser).CardBalance}");
            }
            else
            {
                Console.WriteLine($"Your Limit Is Exceed For Today");

            }

        }

        static void FastCashWithdrawal(CardHolder currUser)
        {
            if (((IUser)currUser).Count != 10)
            {


                Console.WriteLine($"Your Current Balance is{((IUser)currUser).CardBalance}");
                Console.WriteLine($"Please Choose Correct Option for Fast Cash Withdrawal\n1.500\n2.1000\n3.2000");
            returnToFastWithdrawals:
                int Withdrawal;
                string Withdrawals = Console.ReadLine();
                bool isvalid = int.TryParse(Withdrawals, out Withdrawal);
                while (!isvalid)
                {
                    Console.WriteLine($"Please Enter Correct Ammount: ");
                    goto returnToFastWithdrawals;
                }

                switch (Withdrawal)
                {
                    case 1:
                        Withdrawal = 500;
                        break;
                    case 2:
                        Withdrawal = 1000;
                        break;
                    case 3:
                        Withdrawal = 2000;
                        break;
                    default:
                        Withdrawal = 0;
                        break;

                }
                if (Withdrawal == 0)
                {
                    Console.WriteLine($"Please Enter Correct input");
                    goto returnToFastWithdrawals;
                }
                if (Math.Abs(Withdrawal) > ((IUser)currUser).CardBalance || Math.Abs(Withdrawal) > ((IinstaMoney)currUser).CashAvailability)
                {
                    Console.WriteLine($"Not Enough Balance Please Renter The Amount: ");
                    goto returnToFastWithdrawals;
                }

                currUser.CardWithdrawal(Math.Abs(Withdrawal));
                currUser.PreviousTrans.Add($"Fast Cash Withdrawal: {Math.Abs(Withdrawal)}");
                ((IUser)currUser).Count++;
                Console.WriteLine($"Thank You for Withdrawing Money \nNow Your Current Balance is {((IUser)currUser).CardBalance}");
            }
            else
            {
                Console.WriteLine($"Your Limit Is Exceed For Today");
            }
        }
        static void PrintOption()
        {
            Console.WriteLine("\nNow Please Choose the Following Options:\n1.Cash Deposit\n2.Cash availability\n3.Previous five transactions\n4.Cash withdrawal\n5.Fast Withdrawal\n6.Change Pin\n7.Cancel");
        }

        static void CashDeposit(CardHolder currUser)
        {
            Console.WriteLine("How much cash Do You Want To Deposit");
            string cashDepositInput = Console.ReadLine();
            double cashDeposit;
            while (!double.TryParse(cashDepositInput, out cashDeposit))
            {
                cashDepositInput = Console.ReadLine();
            }

            currUser.CashDeposit(cashDeposit);
        }
        public static bool NumberValid(string inputString)
        {
            bool isValid = true;
            if (inputString.Length == 16)
            {

                foreach (char c in inputString)
                {
                    if (!Char.IsDigit(c))
                    {
                        Console.WriteLine("Please Provide Only Numbers");
                        isValid = false;
                        return false;
                    }
                }

            }
            else
            {
                Console.WriteLine("Please Provide Correct Length of the Number(16 Digit)");
                isValid = false;
            }
            return isValid;
        }
    }
}
