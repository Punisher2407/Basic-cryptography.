using System;

namespace basic_cryptography
{
    public class BasicCryptographies
    {
        public string source_text = "";
        public int key = 0;
        public string str_key = "";
    }
    public class Program
    {
        static void Main()
        {
            
            Console.WriteLine(Caesar_sEncrypt.EncryptCaesar(3, "ILOVEYOU"));
            Console.WriteLine(Caesar_sDecrypt.DecryptCaesar(3, "loryhbrx"));
        }
    }    
}
