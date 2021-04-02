using System;

namespace basic_cryptography
{
    public class ColumnEncrypt
    {
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
    }
}
