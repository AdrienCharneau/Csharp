using System;
using System.Collections.Generic;

namespace ipbinarycalculator
{
    class Program
    {
        private static int octet1Dec;
        private static int octet2Dec;
        private static int octet3Dec;
        private static int octet4Dec;

        private static List<List<int>> BinNumList = new List<List<int>>();

        private static int masqueReseau;


        static void Main(string[] args)
        {
            //Change IP adress here:
            octet1Dec = 192;
            octet2Dec = 168;
            octet3Dec = 1;
            octet4Dec = 10;

            //Change Mask length here:
            masqueReseau = 8;

            Console.Write("Adresse IP (Decimal)       : ");
            Console.WriteLine(octet1Dec + "." + octet2Dec + "." + octet3Dec + "." + octet4Dec);

            Console.WriteLine("Taille du Masque           : " + masqueReseau);

            Console.Write("Masque (Decimal)           : ");
            binarytodec(Maskconverter(masqueReseau));

            BinNumList.Add(Binaryconverter(octet1Dec));
            BinNumList.Add(Binaryconverter(octet2Dec));
            BinNumList.Add(Binaryconverter(octet3Dec));
            BinNumList.Add(Binaryconverter(octet4Dec));

            /*
            Console.Write("Adresse IP (Binaire)       : ");
            DisplayList(BinNumList);
            Console.Write("Masque (Binaire)           : ");
            DisplayList(Maskconverter(masqueReseau));
            Console.Write("Adresse Reseau (Binaire)   : ");
            DisplayList(ReseauAddress(BinNumList, masqueReseau));
            Console.Write("Adresse Broadcast (Binaire): ");
            DisplayList(BroadcastAddress(BinNumList, masqueReseau));
            */

            Console.Write("Adresse Reseau (Decimal)   : ");
            binarytodec(ReseauAddress(BinNumList, masqueReseau));

            Console.Write("Adresse Broadcast (Decimal): ");
            binarytodec(BroadcastAddress(BinNumList, masqueReseau));
        }

        static bool Sizecheck(int octet)
        {
            if (octet < 0 || octet > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool Maskcheck(int maskSize)
        {
            if (maskSize < 0 || maskSize > 32)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        static List<int> Binaryconverter(int octetDec)
        {
            List<int> octetBinList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

            if (Sizecheck(octetDec))
            {
                for (int i = 7; octetDec > 0 && i >= 0; i--)
                {
                    octetBinList[i] = octetDec % 2;
                    octetDec = octetDec / 2;
                }
            }
            return octetBinList;
        }

        static List<List<int>> Maskconverter(int maskSize)
        {
            List<List<int>> maskBinary = new List<List<int>>();

            if (Maskcheck(maskSize))
            {
                for (int i = 0; i < 4; i++)
                {
                    List<int> maskOctet = new List<int>();

                    for (int j = 0; j < 8; j++)
                    {
                        if (maskSize > 0)
                        {
                            maskOctet.Add(1);
                            maskSize--;
                        }
                        else
                        {
                            maskOctet.Add(0);
                        }
                    }

                    maskBinary.Add(maskOctet);
                }
            }
            return maskBinary;
        }


        static List<List<int>> ReseauAddress(List<List<int>> BinNumList, int maskSize)
        {
            if (maskSize <= 8)
            {
                for (int i = 7; i > maskSize - 1; i--)
                {
                    BinNumList[0][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[1][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[2][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 0;
                }
            }

            if (maskSize > 8 && maskSize <= 16)
            {
                for (int i = 7; i > maskSize - 9; i--)
                {
                    BinNumList[1][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[2][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 0;
                }
            }

            if (maskSize > 16 && maskSize <= 24)
            {
                for (int i = 7; i > maskSize - 17; i--)
                {
                    BinNumList[2][i] = 0;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 0;
                }
            }

            if (maskSize > 24)
            {
                for (int i = 7; i > maskSize - 25; i--)
                {
                    BinNumList[3][i] = 0;
                }
            }

            return BinNumList;
        }


        static List<List<int>> BroadcastAddress(List<List<int>> BinNumList, int maskSize)
        {
            if (maskSize <= 8)
            {
                for (int i = 7; i > maskSize - 1; i--)
                {
                    BinNumList[0][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[1][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[2][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 1;
                }
            }

            if (maskSize > 8 && maskSize <= 16)
            {
                for (int i = 7; i > maskSize - 9; i--)
                {
                    BinNumList[1][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[2][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 1;
                }
            }

            if (maskSize > 16 && maskSize <= 24)
            {
                for (int i = 7; i > maskSize - 17; i--)
                {
                    BinNumList[2][i] = 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    BinNumList[3][i] = 1;
                }
            }

            if (maskSize > 24)
            {
                for (int i = 7; i > maskSize - 25; i--)
                {
                    BinNumList[3][i] = 1;
                }
            }

            return BinNumList;
        }

        static void binarytodec(List<List<int>> binaryNumList)
        {
            int octet1 = 0;
            int octet2 = 0;
            int octet3 = 0;
            int octet4 = 0;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        octet1 += binaryNumList[i][j] * (int)Math.Pow(2, 7 - j);
                    }
                }
                else if (i == 1)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        octet2 += binaryNumList[i][j] * (int)Math.Pow(2, 7 - j);
                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        octet3 += binaryNumList[i][j] * (int)Math.Pow(2, 7 - j);
                    }
                }
                else
                {
                    for (int j = 0; j < 8; j++)
                    {
                        octet4 += binaryNumList[i][j] * (int)Math.Pow(2, 7 - j);
                    }
                }

            }

            Console.WriteLine(octet1 + "." + octet2 + "." + octet3 + "." + octet4);
        }


        static void DisplayList(List<List<int>> binaryNumList)
        {
            for (int i = 0; i < binaryNumList.Count; i++)
            {
                for (int j = 0; j < binaryNumList[i].Count; j++)
                {
                    Console.Write(binaryNumList[i][j]);
                }

                if (i != 3)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

    }
}
