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
        public string EncryptRailwayFence(int Key, string SourceText)
        {
            bool goDown = false;
            int row = 0, column = 0;
            int i = 0, j = 0;
            string ciphertext = "";
            char[,] Fence = new char[Key, SourceText.Length];

            // Инициализация массива, символом, котрый не используется в тексте.
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
            return ciphertext;
        }
    }
    public class Program
    { 
        static void Main()
        {
            // test - 1, Telecommunication
            Permutation RailwayFence = new Permutation();
            Console.Write("Source text: ");
            RailwayFence.source_text = Console.ReadLine();
            Console.Write("Input key: ");
            RailwayFence.key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ciphertext: {0}", RailwayFence.EncryptRailwayFence(RailwayFence.key, RailwayFence.source_text));
        }
    }    
}
