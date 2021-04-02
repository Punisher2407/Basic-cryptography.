namespace basic_cryptography
{
    public class EncryptRF
    {
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
    }
}
