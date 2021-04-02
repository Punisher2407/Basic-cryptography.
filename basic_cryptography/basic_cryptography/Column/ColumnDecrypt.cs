using System;

namespace basic_cryptography
{
    public class ColumnDecrypt
    {
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
}
