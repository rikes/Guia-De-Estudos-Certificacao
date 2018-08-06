using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
 
 /*
 Creditos: DevMedia
 Algoritimo Rijndael para criptografia SIMÉTRICA (AES)
 
 O Rijndael é um algoritmo simétrico de chave variável (os valores possíveis para o tamanho das chaves são: 128bits, 192bits, 256bits)
 o que dificulta muito o trabalho de quebra dos valores.
 Fonte: https://www.devmedia.com.br/criptografia-em-net-utilizando-a-classe-rijndael/26440
 */
namespace _3._2_AES_Symmetric_Algorithm
{

    public static class CriptografiaHelper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Heelooo");
        }
        
        private static Rijndael CriarInstanciaRijndael(string chave, string vetorInicializacao)
        {
            if (  chave == null || 
                  chave.Length == 16 ||
                  chave.Length == 24 ||
                  chave.Length == 32)
            {
                throw new Exception(
                    "A chave de criptografia deve possuir 16, 24 ou 32 caracteres.");
            }
 
            if (vetorInicializacao == null ||
                vetorInicializacao.Length != 16)
            {
                throw new Exception("O vetor de inicialização deve possuir 16 caracteres.");
            }
 
            Rijndael algoritmo = Rijndael.Create();
            algoritmo.Key = Encoding.ASCII.GetBytes(chave);
            algoritmo.IV = Encoding.ASCII.GetBytes(vetorInicializacao);
 
            return algoritmo;
        }
 
        public static string Encriptar(string chave, string vetorInicializacao, string textoNormal)
        {
            if (String.IsNullOrWhiteSpace(textoNormal))
            {
                throw new Exception("O conteúdo a ser encriptado não pode ser uma string vazia.");
            }
 
            using (Rijndael algoritmo = CriarInstanciaRijndael(chave, vetorInicializacao))
            {
                ICryptoTransform encryptor = algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);
 
                using (MemoryStream streamResultado = new MemoryStream())
                {
                    using (CryptoStream csStream = new CryptoStream(streamResultado, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(csStream))
                        {
                            writer.Write(textoNormal);
                        }
                    }
 
                    return ArrayBytesToHexString(streamResultado.ToArray());
                }
            }
        }
        
        public static string Decriptar(string chave, string vetorInicializacao,string textoEncriptado)
        {
            if (String.IsNullOrWhiteSpace(textoEncriptado))
            {
                throw new Exception( "O conteúdo a ser decriptado não pode ser uma string vazia.");
            }
 
            if (textoEncriptado.Length % 2 != 0)
            {
                throw new Exception(
                    "O conteúdo a ser decriptado é inválido.");
            }
 
 
            using (Rijndael algoritmo = CriarInstanciaRijndael(chave, vetorInicializacao))
            {
                ICryptoTransform decryptor = algoritmo.CreateDecryptor( algoritmo.Key, algoritmo.IV);
 
                string textoDecriptografado = null;
                using (MemoryStream streamTextoEncriptado = new MemoryStream(HexStringToArrayBytes(textoEncriptado)))
                {
                    using (CryptoStream csStream = new CryptoStream(streamTextoEncriptado, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(csStream))
                        {
                            textoDecriptografado = reader.ReadToEnd();
                        }
                    }
                }
 
                return textoDecriptografado;
            }
        }
        //converte um array de bytes em uma string, com cada elemento tendo sido transformado em um valor correspondente em texto hexadecimal;
        private static string ArrayBytesToHexString(byte[] conteudo)
        {
            //o uso do formato "X2" permite a transformação de cada byte em uma string hexadecimal equivalente.
            string[] arrayHex = Array.ConvertAll(conteudo, b => b.ToString("X2"));
            
            return string.Concat(arrayHex);
        }
        
         /*
         converte uma string com valores hexadecimais em um array cujos itens serão do tipo byte.
          
          Cada conjunto de 2 caracteres corresponde a um byte, de forma que esta informação é convertida através do método 
          ToByte da classe Convert (repassando-se como parâmetros a esta última uma string de 2 caracteres, bem como o valor 16 
          que indica que se está sendo considerado um número na base hexadecimal).
        */
        private static byte[] HexStringToArrayBytes(string conteudo)
        {
            int qtdeBytesEncriptados = conteudo.Length / 2;
            byte[] arrayConteudoEncriptado =  new byte[qtdeBytesEncriptados];
            
            for (int i = 0; i < qtdeBytesEncriptados; i++)
            {
                arrayConteudoEncriptado[i] = Convert.ToByte(conteudo.Substring(i * 2, 2), 16);
            }
 
            return arrayConteudoEncriptado;
        }
    }
}