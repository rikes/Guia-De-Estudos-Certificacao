using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
 
 /*
 Criptograr e descriptografar de forma mais simples possível uma string com criptografia Assimetrica (AES)
 - Chave Unica
 */
namespace _3._2_AES_Symmetric_Algorithm
{
    class AES
    {
        static void Main(string[] args)
        {
            string original = "Mensagem secreta, não pode ser interceptada";
            
            //Como de costume, instanciar o algoritimo de Encriptação que contem uma chave e um vetor de inicialização (IV)
            //AES representa uma classe Abstrata
            using(Aes aes = Aes.Create())
            {
                //Encripta oa String
                byte[] encriptado = EncryptAES(original, aes.Key, aes.IV);
                
                //Desencriptação
                string descriptografado = DecryptAES(encriptado, aes.Key, aes.IV);
                
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Encriptado: {0}", encriptado);
                Console.WriteLine("Descriptografado: {0}", descriptografado);
                
                
            }
        
        }
        
        private static byte[] EncryptAES(string mensagem, string chave, string vetorInicializacao)
        {
            byte[] encriptado;
            
           
            //Criar um objeto do tipo AES com a chave e o vetor de inicializacao
            using(Aes aes = Aes.Create()) 
            {
                aes.Key = chave;
                aes.IV = vetorInicializacao;
                
                //Criamos um decryptor para executar transformacoes no fluxo
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                
                //Criamos um Stream usado para encriptar os dados
                using(MemoryStream msEncrypt = new MemoryStream())
                {
                    using(CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write) )
                    {
                        //Agora escrevemos todos os dados no fluxo de dados
                        using(StreamWriter swEncrypt = new StreamWriter(csEncrypt))
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
        
        private static void DecryptAES(string mensagemCriptografada, string chave, string vetorInicializacao)
        {
            string mensagemDescriptografada = null;
            
            
            
        }

}