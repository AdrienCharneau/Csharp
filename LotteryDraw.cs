using System;


namespace LotteryDraw
{
    class Program
    {
        /* 
            - What is this?
            
           This program is part of an exercice from an online C# course
           (available at openclassrooms.com) named "Réalisez un tirage 
           de loto" aka "Build your own Lottery Draw algorithm".

            - What it does?
        
            When executed, this program will a open a console window 
            where 7 numbers ranging from 1 to 49 (included) will be 
            displayed. It is important to note that all numbers are 
            unique and not equal to any of the others.
        */


        // Declaring a single-dimensional Array that will contain all 
        // the chosen numbers.
        static int[] lotteryTable = new int[7];


        // Main method:
        // First we call Draw() in order to work out the lottery draw, 
        // then we use the Display() method to show the winning 
        // numbers on the console.
        static void Main(string[] args)
        {
            Draw();
            Display();
        }


        // Draw method:
        // This method fills the Array 'lotteryTable' with 7 unique 
        // random numbers ranging from 1 to 49 (included).
        static void Draw()
        {

            // Initialization of an int variable that counts how many 
            // winning numbers are contained inside 'lotteryTable'.
            int lotteryCounter = 0;

            // Declaration of a random number variable that will be
            // used to get winning numbers.
            Random rndNumber = new Random();

            // Declaration of an int variable that will store values
            // found by 'rndNumber'.
            int winNumber;

            while (lotteryCounter < lotteryTable.Length)
            {
                // Setting 'winNumber' to a random value ranging from 
                // 1 to 49 (included).
                winNumber = rndNumber.Next(1, 50);

                for (int i = 0; i < lotteryTable.Length; i++)
                {
                    if (lotteryTable[i] == winNumber)
                    {
                        // At any moment, if a value is already present
                        // in 'lotteryTable', the "for" loop breaks and 
                        // we set 'winNumber' to a new random value.
                        break;
                    }
                    else if (i == lotteryCounter)
                    {
                        // When we have finished checking all values 
                        // in 'lotteryTable', we add 'winNumber' to the
                        // Array and restart the process with a new 
                        // random value.
                        lotteryTable[lotteryCounter] = winNumber;
                        lotteryCounter++;
                        break;
                    }
                    else
                    {
                        // At any moment, if a value is not present in
                        // 'lotteryTable', the "for" loop continues and
                        // we check the next value present in the Array.
                        continue;
                    }
                }
            }
        }


        // Display method:
        // This method displays every single number present in 
        // 'lotteryTable' along with their order inside the Array.
        static void Display()
        {
            for (int x = 0; x < lotteryTable.Length; x++)
            {
                int displayNumber = x + 1;
                Console.WriteLine("Lottery number " + displayNumber + " = " + lotteryTable[x]);
            }
        }


    }
}
