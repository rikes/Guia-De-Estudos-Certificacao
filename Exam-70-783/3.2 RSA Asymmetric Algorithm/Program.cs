using System;
using System.Text;
using System.Security.Cryptography;

namespace _3._2_RSA_Asymmetric_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string KeyContainerName = "MyKeyContainer";//Usamos container para armazenar nossas chaves de texto puro
            string clearText = "This is the data we want to encrypt!";
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = KeyContainerName;

            RSAParameters publicKey;
            RSAParameters privateKey;
            string publicKeyXML = null;
            string privateKeyXML = null;

            using(var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                publicKey = rsa.ExportParameters(false);//se for false chave publica
                privateKey = rsa.ExportParameters(true);//Se for verdadeiro cria um RSAParamters privado

                publicKeyXML = rsa.ToXmlString(false);
                privateKeyXML = rsa.ToXmlString(true);
                rsa.Clear();
            }

            byte[] encrypted = EncryptUsingRSAParam(clearText, publicKey);
            string decrypted = DecryptUsingRSAParam(encrypted, privateKey);

            Console.WriteLine("Asymmetric RSA - Using RSA Params");
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

            Console.WriteLine("\n");
            Console.WriteLine("Asymmetric RSA - Using Persistent Key Container");
            encrypted = EncryptUsingContainer(clearText, cspParams);
            decrypted = DecryptUsingContainer(encrypted, cspParams);
            
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

            Console.WriteLine("\n");
            Console.WriteLine("Asymmetric RSA - Using Xml");
            encrypted = EncryptUsingXML(clearText, publicKeyXML);
            decrypted = DecryptUsingXML(encrypted, privateKeyXML);

            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

            Console.ReadLine();
        }

        /*
         * Usamos RSA para criptografar através de parametros.
         * Obs1 - No outro metodo usamos um container
         * Obs2 - No outro metodo usamos XML
         */
        static byte[] EncryptUsingRSAParam(string value, RSAParameters rsaPublicKay)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaPublicKay); //rsa.FromXmlString();
                byte[] encodedData = Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }

        static string DecryptUsingRSAParam(byte[] encryptedData, RSAParameters rsaPrivateKey)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaPrivateKey);
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }
        /*
         * Container para armazenamento de chaves
         */
        static byte[] EncryptUsingContainer(string value, CspParameters containerParameters)
        {
            using(var rsa = new RSACryptoServiceProvider(containerParameters))
            {
                byte[] encodedData = Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }

        static string DecryptUsingContainer(byte[] encryptedData, CspParameters containerParameters)
        {
            using(var rsa = new RSACryptoServiceProvider(containerParameters))
            {
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }

        static byte[] EncryptUsingXML(string value, string publicKeyXML)
        {
            byte[] dataToEncrypt = Encoding.Default.GetBytes(value);
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXML);
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);

                rsa.Clear();
                return encryptedData;
            }
        }

        static string DecryptUsingXML(byte[] encryptedData, string privateKeyXML)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXML);
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }


    }
}
