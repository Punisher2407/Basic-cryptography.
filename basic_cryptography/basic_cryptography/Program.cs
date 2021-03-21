using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace basic_cryptography
{
    public class Permutation
    {
        public string source_text = "";
        public int key = 0;
        public string str_key = "";

        public static string EncryptRailwayFence(int Key, string SourceText)
        {
            bool goDown = false;
            int row = 0, column = 0;
            int i = 0, j = 0;
            string ciphertext = "";
            char[,] Fence = new char[Key, SourceText.Length];

            // Matrix initialize
            for (i = 0; i < Key; i++)
            {
                for (j = 0; j < SourceText.Length; j++)
                {
                    Fence[i, j] = '~';
                }
            }

            for (i = 0; i < SourceText.Length; i++)
            {
                if ((row == 0) || (row == Key - 1))
                {
                    goDown = !goDown;
                }
                Fence[row, column] = SourceText[i];
                column++;
                if (goDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            for (i = 0; i < Key; i++)
            {
                for (j = 0; j < SourceText.Length; j++)
                {
                    if (Fence[i, j] != '~')
                    {
                        ciphertext += Fence[i, j];
                    }
                }
            }
            ciphertext = ciphertext.ToUpper();
            return ciphertext;
        }
        public static string DecryptRailwayFence(int Key, string CipherText)
        {
            char[,] Fence = new char[Key, CipherText.Length];
            bool goDown = false;
            int row = 0, column = 0;
            int i = 0, j = 0;
            int index = 0;

            for (i = 0; i < CipherText.Length; i++)
            {
                if ((row == 0) || (row == Key - 1))
                {
                    goDown = !goDown;
                }

                Fence[row, column] = '~';
                column++;

                if (goDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            for (i = 0; i < Key; i++)
            {
                for (j = 0; j < CipherText.Length; ++j)
                {
                    if (Fence[i, j] == '~')
                    {
                        Fence[i, j] = CipherText[index++];
                    }
                }
            }

            string sourcetext = "";
            goDown = false;
            row = 0;
            column = 0;
            for (i = 0; i < CipherText.Length; ++i)
            {
                if ((row == 0) || (row == Key - 1))
                {
                    goDown = !goDown;
                }
                sourcetext += Fence[row, column];
                column++;

                if (goDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }
            sourcetext = sourcetext.ToUpper();
            return sourcetext;
        }
        public static string EncryptColumn(string Key, string SourceText)
        {
            int rowsCount = (int)Math.Ceiling((double)SourceText.Length / Key.Length) + 1;
            char[,] sourcematrix = new char[rowsCount, Key.Length];
            int index, value = Key.Length;
            int i = 0, j = 0;

            for (i = 0; i < Key.Length; i++)
            {
                index = 0;
                for (j = 1; j <= Key.Length - 1; j++)
                {
                    if (Convert.ToInt32(Key[j]) >= Convert.ToUInt32(Key[index]))
                    {
                        index = j;
                    }
                }
                sourcematrix[0, index] = Convert.ToChar(value);
                Key = Key.Remove(index, 1).Insert(index, "\f");
                value--;
            }

            index = 0;
            for (i = 1; i < rowsCount; i++)
            {
                for (j = 0; j < Key.Length; j++)
                {
                    if (index < SourceText.Length)
                        sourcematrix[i, j] = SourceText[index++];
                    else
                        sourcematrix[i, j] = '\f';
                }
            }

            int z = Key.Length - 1;
            char min;
            while (z > 0)
            {
                index = 0;
                for (j = 1; j <= z; j++)
                {
                    if (Convert.ToUInt32(sourcematrix[0, j]) > Convert.ToUInt32(sourcematrix[0, index]))
                        index = j;
                }

                for (i = 0; i < rowsCount; i++)
                {
                    min = sourcematrix[i, index];
                    sourcematrix[i, index] = sourcematrix[i, z];
                    sourcematrix[i, z] = min;
                }

                z -= 1;
            }

            string ciphertext = "";
            for (j = 0; j < Key.Length; j++)
            {
                for (i = 1; i < rowsCount; i++)
                {
                    if (sourcematrix[i, j] != '\f')
                        ciphertext += sourcematrix[i, j];
                }
            }
            ciphertext = ciphertext.ToUpper();
            return ciphertext;
        }
        public static string DecryptColumn(string Key, string CipherText)
        {
            int rowsCount = (int)Math.Ceiling((double)CipherText.Length / Key.Length);
            char[,] sourcematrix = new char[rowsCount, Key.Length];
            int i = 0, j = 0, z = 0;
            int emptyCells = rowsCount * Key.Length - CipherText.Length;
            if (emptyCells != 0)
            {
                for (j = CipherText.Length % Key.Length; j < Key.Length; j++)
                {
                    sourcematrix[rowsCount - 1, j] = '\f';
                }
            }

            int indexString = CipherText.Length - 1;
            int index = 0;
            for (j = 0; j < Key.Length; j++)
            {
                index = 0;
                for (z = 1; z <= Key.Length - 1; z++)
                {
                    if (Convert.ToInt32(Key[z]) >= Convert.ToUInt32(Key[index]))
                    {
                        index = z;
                    }
                }
                Key = Key.Remove(index, 1).Insert(index, "\f");
                for (i = rowsCount - 1; i >= 0; i--)
                {
                    if (sourcematrix[i, index] != '\f')
                    {
                        sourcematrix[i, index] = CipherText[indexString--];
                    }
                }
            }

            string sourcetext = "";
            for (i = 0; i < rowsCount; i++)
            {
                for (j = 0; j < Key.Length; j++)
                {
                    if (sourcematrix[i, j] != '\f')
                    {
                        sourcetext += sourcematrix[i, j];
                    }
                }
            }
            sourcetext = sourcetext.ToUpper();
            return sourcetext;
        }
    }
    public class Program : Permutation
    { 
        static void Main()
        {
            Permutation test1 = new Permutation();
            Console.Write("Source text: ");
            test1.source_text = Console.ReadLine();
            Console.Write("Key:");
            test1.str_key = Console.ReadLine();
            Console.WriteLine("Ciphertext: {0}", EncryptColumn(test1.str_key, test1.source_text));
            Permutation test2 = new Permutation();
            Console.Write("Source text: ");
            test2.source_text = Console.ReadLine();
            Console.Write("Key:");
            test2.str_key = Console.ReadLine();
            Console.WriteLine("Text: {0}", DecryptColumn(test2.str_key, test2.source_text));
        }
    }    
}
