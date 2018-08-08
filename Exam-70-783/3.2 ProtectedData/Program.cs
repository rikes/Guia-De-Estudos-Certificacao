using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2_ProtectedData
{
    static class Program
    {
        /// <summary>
        /// ProtectedData é utilizada para proteger dados definidos pelo usuário. Essa classe não exige outras classes (algoritmos) de criptografia. 
        /// Essa classe fornece dois métodos principais chamados de Protect e Unprotect. 
        /// Ambos os métodos são estáticos e, o método Protect, além de outros parâmetros, recebe principalmente um array de bytes que representa o valor a ser protegido, retornando também um array de bytes contendo o valor criptografado;
        /// já o método Unprotect recebe um array de bytes representando o dado protegido (criptografado) e retorna um array de bytes contendo o conteúdo em seu formato original.
        /// 
        /// Read more: http://www.linhadecodigo.com.br/artigo/2085/por-dentro-da-base-classe-library-capitulo-8-criptografia.aspx#ixzz5NSJZC5S9
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
