namespace basic_cryptography
{
    public class DecryptRF
    {
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
    }
}