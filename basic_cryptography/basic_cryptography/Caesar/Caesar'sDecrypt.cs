namespace basic_cryptography
{
    public class Caesar_sDecrypt
    {
        public static string DecryptCaesar(int Key, string CipherText)
        {
            CipherText = CipherText.ToUpper();
            char[] char_text = CipherText.ToCharArray();
            int i = 0;
            int end = 90;
            int result = 0;
            int buf = 0;
            for (i = 0; i < char_text.Length; i++)
            {
                buf = (int)char_text[i];
                if ((buf - Key) < 65)
                {
                    result = (buf - Key) + (end - 'A') + 1;
                    char_text[i] = (char)result;
                }
                else
                {
                    result = buf - Key;
                    char_text[i] = (char)result;
                }

            }
            string sourcetext = "";
            for (i = 0; i < char_text.Length; i++)
            {
                sourcetext += char_text[i];
            }
            return sourcetext;
        }
    }
}
