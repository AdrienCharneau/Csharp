using System;


namespace LotteryDraw
{
    class Program
    {


        /* - What is this?
            
           This program is part of an exercice from an online C# course
           (available at openclassrooms.com) named "Réalisez un tirage 
           de loto" aka "Build your own Lottery Draw algorithm".

        */


        /* - What it does?
        
            When executed, this program will a open a console window 
            where 7 numbers ranging from 1 to 49 will be displayed. It 
            is important to note that all numbers are unique and not a
            single one of them is equal to any of the others.

        */


        // Declaring a single-dimensional Array that will contain all 
        // the chosen numbers.
        static int[] lotteryTable = new int[7];


        // Main method. First we call Draw() in order to work out the 
        // lottery draw, then we use the Display() method to show the 
        // winning numbers on the console.
        static void Main(string[] args)
        {
            Draw();
            Display();
        }


        static void Draw()
        {
            int lotteryCounter = 0;
            Random rndNumber = new Random();
            int winNumber;

            while (lotteryCounter < lotteryTable.Length)
            {
                winNumber = rndNumber.Next(1, 50);

                for (int i = 0; i < lotteryTable.Length; i++)
                {
                    if (lotteryTable[i] == winNumber)
                    {
                        break;
                    }
                    else if (i == lotteryCounter)
                    {
                        lotteryTable[lotteryCounter] = winNumber;
                        lotteryCounter++;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }


        static void Display()
        {
            for (int x = 0; x < lotteryTable.Length; x++)
            {
                int displayNumber = x + 1;
                Console.WriteLine("Lottery Index " + displayNumber + " = " + lotteryTable[x]);
            }
        }


    }
}
