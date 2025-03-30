using System;
using System.Security.Cryptography;
using System.Text;

namespace Act5
{
    public class Program
    {
        private static string _hashedPassword;
        private static string _username;

        static void Main()
        {
            const string MsgMenu = "Menu:" + "\n1. Registration"
                    + "\n2. Data Verification" + "\n3. RSA Encryption and Decryption"
                    + "\n4. Exit" + "\nChoose an option: ";
            const string MsgInvalidOption = "Invalid option. Please try again.\n";
            while (true)
            {
                Console.WriteLine(MsgMenu);
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        VerifyData();
                        break;
                    case "3":
                        RsaEncryptionDecryption();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine(MsgInvalidOption);
                        break;
                }
            }
        }

        private static void Register()
        {
            const string MsgEnterUser = "Enter username: ";
            const string MsgEnterPass = "Enter password: ";
            string MsgHashedComb = $"Registration successful. Hashed combination: {_hashedPassword}\n";

            Console.Write(MsgEnterUser);
            _username = Console.ReadLine();

            Console.Write(MsgEnterPass);
            string password = Console.ReadLine();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_username + password));
                _hashedPassword = Convert.ToBase64String(hashBytes);
            }

            Console.WriteLine(MsgHashedComb);
        }

        private static void VerifyData()
        {
            const string MsgError = "No registration data found.\n";
            const string MsgEnterUser = "Enter username: ";
            const string MsgEnterPass = "Enter password: ";
            const string MsgDataCorrect = "Data is correct.\n";
            const string MsgIncorrect = "Incorrect username or password.\n";

            if (string.IsNullOrEmpty(_hashedPassword) || string.IsNullOrEmpty(_username))
            {
                Console.WriteLine(MsgError);
                return;
            }

            Console.Write(MsgEnterUser);
            string username = Console.ReadLine();

            Console.Write(MsgEnterPass);
            string password = Console.ReadLine();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(username + password));
                string enteredHash = Convert.ToBase64String(hashBytes);

                if (enteredHash == _hashedPassword)
                    Console.WriteLine(MsgDataCorrect);
                else
                    Console.WriteLine(MsgIncorrect);
            }
        }

        private static void RsaEncryptionDecryption()
        {
            const string MsgInput = "Enter text to encrypt: ";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                Console.Write(MsgInput);
                string plainText = Console.ReadLine();

                rsa.PersistKeyInCsp = false;
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                byte[] encryptedBytes;
                using (RSACryptoServiceProvider rsaEncryptor = new RSACryptoServiceProvider())
                {
                    rsaEncryptor.FromXmlString(publicKey);
                    encryptedBytes = rsaEncryptor.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
                }

                Console.WriteLine($"Encrypted text: {Convert.ToBase64String(encryptedBytes)}");

                string decryptedText;
                using (RSACryptoServiceProvider rsaDecryptor = new RSACryptoServiceProvider())
                {
                    rsaDecryptor.FromXmlString(privateKey);
                    byte[] decryptedBytes = rsaDecryptor.Decrypt(encryptedBytes, false);
                    decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                }

                Console.WriteLine($"Decrypted text: {decryptedText}\n");
            }
        }
    }
}