using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
 // ReSharper disable SuggestVarOrType_SimpleTypes

 /*
 Criptograr e descriptografar de forma mais simples possível uma string com criptografia Assimetrica (AES)
 - Chave Unica
 Obs: Alterar na configuracao do build qual 'Main' será executado
 */
namespace _3._2_AES_Symmetric_Algorithm
{
    class AES
    {
        static void Main(string[] args)
        {
            string original = "Mensagem secreta, não pode ser interceptada¹² ³";

            //Como de costume, instanciar o algoritimo de Encriptação que contem uma chave e um vetor de inicialização (IV)
            //AES representa uma classe Abstrata
            using (Aes aes = Aes.Create())
            {
                //Encripta para String
                byte[] encriptado = EncryptAes(original, aes.Key, aes.IV);

                //Desencriptação
                string descriptografado = DecryptAes(encriptado, aes.Key, aes.IV);

                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Encriptado: {0}", encriptado);
                Console.WriteLine("Descriptografado: {0}", descriptografado);

                Console.ReadKey();
            }

        }

        private static byte[] EncryptAes(string mensagem, byte[] chave, byte[] vetorInicializacao)
        {
            byte[] encriptado;


            //Criar um objeto do tipo AES com a chave e o vetor de inicializacao
            using (Aes aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = vetorInicializacao;

                //Criamos um decryptor para executar transformacoes no fluxo
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                //Criamos um Stream usado para encriptar os dados
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        //Agora escrevemos todos os dados no fluxo de dados
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(mensagem);
                        }
                        encriptado = msEncrypt.ToArray();
                    }
                }
                //Retorna um vetor de bytes criptografados do fluxo
                return encriptado;


            }

        }

        private static string DecryptAes(byte[] mensagemCriptografada, byte[] chave, byte[] vetorInicializacao)
        {
            string mensagemDescriptografada = null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = vetorInicializacao;

                //Cria um decryptor para transformar o stream
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                //Crie um stream usado pelo decryptor
                using (MemoryStream msDecrypt = new MemoryStream(mensagemCriptografada))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            //Acesso a leitura do array de bytes para descriptografia
                            mensagemDescriptografada = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return mensagemDescriptografada;
        }
    }
}