using System;


namespace LotteryDraw
{
    class Program
    {
        static Random rndNumber = new Random();
        static int winNumber;
        static int[] lotteryTable = new int[7];
        static int lotteryCounter = 0;


        static void Main(string[] args)
        {
            Draw();
            Display();
        }


        static void Draw()
        {
            while (lotteryCounter < lotteryTable.Length)
            {
                winNumber = rndNumber.Next(1, 50);

                for (int numero = 0; numero < lotteryTable.Length; numero++)
                {
                    if (lotteryTable[numero] == winNumber)
                    {
                        break;
                    }
                    else if (numero == lotteryCounter)
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
                int affichage = x + 1;
                Console.WriteLine("Index Loto " + affichage + " = " + lotteryTable[x]);
            }
        }
        
        
    }
}
