using System;

namespace AtmSystem
{
    public class PinChanger
    {
        public static bool PinValid(string inputString)
        {
            bool isValid = true;
            if (inputString.Length == 4)
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
                Console.WriteLine("Please Provide Correct Length of the Number(4 Digit)");
                isValid = false;
            }
            return isValid;
        }
        public static void ChangePin(CardHolder currUser)
        {
            Console.WriteLine("Please Enter Your Current Pin");
        returnToPass:
            string passInput = Console.ReadLine();

            while (!PinValid(passInput))
            {
                passInput = Console.ReadLine();
            }

            while (int.Parse(passInput) != ((IUser)currUser).CardPin)
            {
                Console.WriteLine("your Pin Do not match");
                goto returnToPass;
            }
            Console.WriteLine("Please Enter Your New Pin");

            string NewpassInput = Console.ReadLine();

            while (!PinValid(NewpassInput))
            {
                NewpassInput = Console.ReadLine();
            }


            Console.WriteLine($"Your Password Has Been Changed SuccessFully\nPrevious Password: {((IUser)currUser).CardPin}");
            currUser.ChangePass(int.Parse(NewpassInput));
            Console.WriteLine($"New Password: {((IUser)currUser).CardPin}");



        }
    }
}