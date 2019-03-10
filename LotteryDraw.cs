using System;


namespace OpenClassrooms
{
    class Program
    {

        static Random rnd = new Random();
        static int winNumber;
        static int[] loto = new int[7];
        static int compteur = 0;

        static void Main(string[] args)
        {

            Test();
            Display();

        }

        static void Test()
        {
            while (compteur < loto.Length)
            {
                //winNumber = rnd.Next(1, 8);
                winNumber = rnd.Next(1, 50);


                for (int numero = 0; numero < loto.Length; numero++)
                {

                    if (loto[numero] == winNumber)
                    {

                        //Console.WriteLine("Resultat = " + winNumber + " RETRY");
                        break;

                    }

                    else if (numero == compteur)
                    {

                        loto[compteur] = winNumber;
                        compteur++;
                        //Console.WriteLine("Tirage " + compteur + " = " + winNumber);
                        //Console.WriteLine("Compteur = " + compteur);
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

            for (int x = 0; x < loto.Length; x++)
            {
                int affichage = x + 1;
                Console.WriteLine("Index Loto " + affichage + " = " + loto[x]);
            }

        }
    }
}
