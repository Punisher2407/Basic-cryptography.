using System;

namespace basic_cryptography
{
    public class RotatingGrid
    {
        public static string Encrypt(string key, string sourceText)
        {
            string ciphertext = "";
            Int32 index = 0;
            bool[,] punchingMask;
            Int32 sizeMatr = 5;
            punchingMask = new bool[sizeMatr, sizeMatr];
            char[,] cipherMatrix = new char[sizeMatr, sizeMatr];
            bool saveCenterCell;

            for (Int32 i = 0; i < sizeMatr; ++i)
                for (Int32 j = 0; j < sizeMatr; ++j)
                    if (key[index++] == '0')
                        punchingMask[i, j] = false;
                    else
                        punchingMask[i, j] = true;

            saveCenterCell = punchingMask[sizeMatr / 2, sizeMatr / 2];
            index = 0;

            while (sourceText.Length % (sizeMatr * sizeMatr) != 0)
                sourceText += ' ';

            while (index < sourceText.Length - 1)
            {
                for (Int32 i = 0; i < sizeMatr; ++i)
                {
                    for (Int32 j = 0; j < sizeMatr; ++j)
                    {
                        if (punchingMask[i, j])
                            cipherMatrix[i, j] = sourceText[index++];
                    }
                }

                if (punchingMask[sizeMatr / 2, sizeMatr / 2])
                    punchingMask[sizeMatr / 2, sizeMatr / 2] = false;

                for (Int32 i = 0; i < sizeMatr; i++)
                {
                    for (Int32 j = 0; j < sizeMatr; j++)
                    {
                        if (punchingMask[i, j])
                            cipherMatrix[j, sizeMatr - 1 - i] = sourceText[index++];
                    }
                }

                for (Int32 i = sizeMatr - 1; i >= 0; i--)
                {
                    for (Int32 j = sizeMatr - 1; j >= 0; j--)
                    {
                        if (punchingMask[sizeMatr - 1 - i, sizeMatr - 1 - j])
                            cipherMatrix[i, j] = sourceText[index++];
                    }
                }

                for (Int32 i = 0; i < sizeMatr - 1; i++)
                {
                    for (Int32 j = sizeMatr - 1; j >= 0; j--)
                    {
                        if (punchingMask[i, sizeMatr - 1 - j])
                            cipherMatrix[j, i] = sourceText[index++];
                    }
                }

                for (int i = 0; i < sizeMatr; ++i)
                {
                    for (int j = 0; j < sizeMatr; ++j)
                    {
                        ciphertext += cipherMatrix[i, j];
                    }
                }

                punchingMask[sizeMatr / 2, sizeMatr / 2] = saveCenterCell;
            }
            ciphertext = ciphertext.ToUpper();
            return ciphertext;
        }
        public static string Decrypt(string key, string cipherText)
        {
            string plaintext = "";
            Int32 index = 0;
            bool[,] punchingMask;
            Int32 sizeMatr = 5;
            punchingMask = new bool[sizeMatr, sizeMatr];
            char[,] plainMatrix = new char[sizeMatr, sizeMatr];
            bool saveCenterCell;

            for (Int32 i = 0; i < sizeMatr; ++i)
                for (Int32 j = 0; j < sizeMatr; ++j)
                    if (key[index++] == '0')
                        punchingMask[i, j] = false;
                    else
                        punchingMask[i, j] = true;

            saveCenterCell = punchingMask[sizeMatr / 2, sizeMatr / 2];
            index = 0;

            while (cipherText.Length % (sizeMatr * sizeMatr) != 0)
                cipherText += ' ';

            for (Int32 i = 0; i < sizeMatr; i++)
            {
                for (Int32 j = 0; j < sizeMatr; j++)
                {
                    plainMatrix[i, j] = cipherText[index++];
                }
            }

            for (Int32 i = 0; i < sizeMatr; ++i)
            {
                for (Int32 j = 0; j < sizeMatr; ++j)
                {
                    if (punchingMask[i, j])
                        plaintext += plainMatrix[i, j];
                }
            }

            if (punchingMask[sizeMatr / 2, sizeMatr / 2])
                punchingMask[sizeMatr / 2, sizeMatr / 2] = false;

            for (Int32 i = 0; i < sizeMatr; i++)
            {
                for (Int32 j = 0; j < sizeMatr; j++)
                {
                    if (punchingMask[i, j])
                        plaintext += plainMatrix[j, sizeMatr - 1 - i];
                }
            }

            for (Int32 i = sizeMatr - 1; i >= 0; i--)
            {
                for (Int32 j = sizeMatr - 1; j >= 0; j--)
                {
                    if (punchingMask[sizeMatr - 1 - i, sizeMatr - 1 - j])
                        plaintext += plainMatrix[i, j];
                }
            }

            for (Int32 i = 0; i < sizeMatr - 1; i++)
            {
                for (Int32 j = sizeMatr - 1; j >= 0; j--)
                {
                    if (punchingMask[i, sizeMatr - 1 - j])
                        plaintext += plainMatrix[j, i];
                }
            }
            punchingMask[sizeMatr / 2, sizeMatr / 2] = saveCenterCell;
            plaintext = plaintext.ToUpper();
            return plaintext;
        }
    }
}
