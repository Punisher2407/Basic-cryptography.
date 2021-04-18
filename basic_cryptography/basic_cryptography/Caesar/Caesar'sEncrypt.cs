namespace basic_cryptography
{
    public class Caesar_sEncrypt
    {
        public static string EncryptCaesar(int Key, string SourceText)
        {
            SourceText = SourceText.ToUpper();
            char[] char_text = SourceText.ToCharArray();
            int i = 0;
            int start = 65;
            int result = 0;
            int buf = 0;
            for (i = 0; i < char_text.Length; i++)
            {
                buf = (int)char_text[i];
                if ((Key + buf) > 90)
                {
                    result = (Key + buf) - ('Z' - start) - 1;
                    char_text[i] = (char)result;
                }
                else
                {
                    result = buf + Key;
                    char_text[i] = (char)result;
                }

            }
            string cipherstring = "";
            for (i = 0; i < char_text.Length; i++)
            {
                cipherstring += char_text[i];
            }
            return cipherstring;
        }
    }
}