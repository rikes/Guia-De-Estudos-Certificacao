using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Expression_Tree
{
    /// <summary>
    /// Expression é o código em formato de dados
    /// Os dados são armazenados em uma estrtura de dados do tipo árvore
    /// Cada no representara uma informação da expressão. Sendo dado ou operador por exemplo.
    /// Os operadores e tipo são nós da arvore. Sendo que os operadores ficaram na mesma linha
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Vamos fazer um Expression, que verifique se uma 'expressão' é verdadeira. Usando uma função anônima
            Expression<Func<int, bool>> exp = x => x >= 10;

            //Obtenho o corpo da expressão
            BinaryExpression corpo = (BinaryExpression) exp.Body;

            //Obtenho os parametros do corpo da expressão
            ParameterExpression param = exp.Parameters[0];//Obtenho o parametro (no caso só tenho um)
            ParameterExpression opEsquerdo = (ParameterExpression) corpo.Left;
            ConstantExpression opDireito = (ConstantExpression)corpo.Right; //Constnate, numero no caso
            
            //Primeira opcao
            Console.WriteLine("{0} => {1} {2} {3}", param.Name, opEsquerdo.Name, corpo.NodeType, opDireito.Value);

            //Segunda opção
            Console.WriteLine("Expressão \t {0}", corpo.Reduce());
            Console.WriteLine("{0} => {1} {2} {3} ", param.Name, corpo.Left, corpo.NodeType, corpo.Right);

            //Obtendo cada nó da Expressão para obter o resultado da Expressão.

            Func<int, bool> lambdaExpression = exp.Compile();

            //Exibira
            Console.WriteLine(lambdaExpression(15));

            Console.ReadLine();
        }
    }
}
