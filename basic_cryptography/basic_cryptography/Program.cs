using System;
using static System.Console;

namespace basic_cryptography
{
    public class BasicCryptographies
    {
        public string sourceText = "";
        public string cipherText = "";
        public int key = 0;
        public string strKey = "";
    }
    public class Program
    {
        static int Main()
        {
            BasicCryptographies Crypt = new BasicCryptographies();
            const string firstRGKey = "1010000001001100100001000";
            //const string secondRGKey = "0000100000001010011100010";
            int quit = -1;
            string cryptOrDecrypt = "";
            while (quit == -1)
            {
                WriteLine();
                WriteLine("-----------------------------------");
                WriteLine("   Enter \"-1\" for quit.");
                WriteLine("1. The \"railway fence\" method.");
                WriteLine("2. The column method.");
                WriteLine("3. The \"rotating grid\" method.");
                WriteLine("4. Caesars's cipher.");
                WriteLine("-----------------------------------");
                Write("\nChoice: ");
                int choice = Convert.ToInt32(ReadLine());
                switch (choice)
                {
                    case 1:
                        WriteLine("Choice:\n e  - encrypt\n d  -  decrypt");
                        Write("Your choice: ");
                        cryptOrDecrypt = ReadLine();
                        switch (cryptOrDecrypt)
                        {
                            case "e":
                                Write("Input key: ");
                                Crypt.key = Convert.ToInt32(ReadLine());
                                Write("Input string: ");
                                Crypt.sourceText = ReadLine();
                                WriteLine("Result: {0}", EncryptRF.EncryptRailwayFence(Crypt.key, Crypt.sourceText));
                                break;
                            case "d":
                                Write("Input key: ");
                                Crypt.key = Convert.ToInt32(ReadLine());
                                Write("Input string: ");
                                Crypt.cipherText = ReadLine();
                                WriteLine("Result: {0}", DecryptRF.DecryptRailwayFence(Crypt.key, Crypt.cipherText));
                                break;
                            default:
                                WriteLine("\nWrong data. Please, try again.");
                                break;
                        }
                        break;
                    case 2:
                        WriteLine("Choice:\n e  - encrypt\n d  -  decrypt");
                        Write("Your choice: ");
                        cryptOrDecrypt = ReadLine();
                        switch (cryptOrDecrypt)
                        {
                            case "e":
                                Write("Input string key: ");
                                Crypt.strKey = ReadLine();
                                Write("Input string: ");
                                Crypt.sourceText = ReadLine();
                                WriteLine("Result: {0}", ColumnEncrypt.EncryptColumn(Crypt.strKey, Crypt.sourceText));
                                break;
                            case "d":
                                Write("Input string key: ");
                                Crypt.strKey = ReadLine();
                                Write("Input string: ");
                                Crypt.cipherText = ReadLine();
                                WriteLine("Result: {0}", ColumnDecrypt.DecryptColumn(Crypt.strKey, Crypt.cipherText));
                                break;
                            default:
                                WriteLine("\nWrong data. Please, try again.");
                                break;
                        }
                        break;
                    case 3:
                        //"1010000001001100100001000"
                        WriteLine("Choice:\n e  - encrypt\n d  -  decrypt");
                        Write("Your choice: ");
                        cryptOrDecrypt = ReadLine();
                        switch (cryptOrDecrypt)
                        {
                            case "e":
                                //Write("Input string key: ");
                                //Crypt.strKey = ReadLine();
                                Write("Input string: ");
                                Crypt.sourceText = ReadLine();
                                WriteLine("Result: {0}", RotatingGrid.Encrypt(firstRGKey, Crypt.sourceText));
                                break;
                            case "d":
                                //Write("Input string key: ");
                                //Crypt.strKey = ReadLine();
                                Write("Input string: ");
                                Crypt.cipherText = ReadLine();
                                WriteLine("Result: {0}", RotatingGrid.Decrypt(firstRGKey, Crypt.cipherText));
                                break;
                            default:
                                WriteLine("\nWrong data. Please, try again.");
                                break;
                        }
                        break;
                    case 4:
                        WriteLine("Choice:\n e  - encrypt\n d  -  decrypt");
                        Write("Your choice: ");
                        cryptOrDecrypt = ReadLine();
                        switch (cryptOrDecrypt)
                        {
                            case "e":
                                Write("Input key: ");
                                Crypt.key = Convert.ToInt32(ReadLine());
                                Write("Input string: ");
                                Crypt.sourceText = ReadLine();
                                WriteLine("Result: {0}", Caesar_sEncrypt.EncryptCaesar(Crypt.key, Crypt.sourceText));
                                break;
                            case "d":
                                Write("Input key: ");
                                Crypt.key = Convert.ToInt32(ReadLine());
                                Write("Input string: ");
                                Crypt.cipherText = ReadLine();
                                WriteLine("Result: {0}", Caesar_sDecrypt.DecryptCaesar(Crypt.key, Crypt.cipherText));
                                break;
                            default:
                                WriteLine("\nWrong data. Please, try again.");
                                break;
                        }
                        break;
                    default:
                        WriteLine("Incorrect data. Try one more time.");
                        break;
                    case -1:
                        return 0;
                }
            }
            return 0;
        }
    }    
}