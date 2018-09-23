Markdown Guide:
https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet



# Parte 2 - Types


## 2.1 Create Types

A linguagem C# conta com três tipos diferentes:

- Tipos de valor

- Tipos de referência

- Tipos de ponteiro
 
### Struct vs Class


**Structs** são usadas para criar estruturas de dados cujas instâncias (os objetos) sejam pequenas (no máximo 16 bytes), sejam imutáveis, representem um valor único, ou seja, que não contenha diversas características, e não precise ser encapsulado (boxing) em objetos por referência com frequência.
Estas estruturas têm seu conteúdo (seu valor) integral copiado quando precisa transportar de um local para outro. Portanto são tipos por valor (value types).

**Classes** são usadas para todos os casos que uma struct pode trazer problemas, principalmente quando não atendem as recomendações acima. E elas são muito mais comuns nas aplicações.

- Structs são tipos por valor.
- Todos os tipos struct implicitamente herdam da classe System.ValueType.
- Atribuição a uma variável do tipo struct cria uma cópia do valor sendo atribuído .
- O valor padrão de uma struct é o valor produzido após atribuir todos os tipos valores para seu valor padrão e todos os tipos referência para null.
- Operações de boxing e unboxing são usadas para converter entre um tipo struct e um objeto .
- Uma struct não pode declarar um construtor de instância sem parâmetros.
- Uma struct não pode declarar um destrutor.


https://pt.stackoverflow.com/questions/16181/qual-a-diferen%C3%A7a-entre-struct-e-class

### Enum

Os tipos de ponteiro são raramente usados. Você os usa somente quando estiver trabalhando com código não seguro e quando precisar usar a aritmética de ponteiros.

O *Enum* é um tipo especial básico por valor para o c#, exemplo

```csharp
enum Days: byte {Sat = 1, dom, seg, ter, qua, qui, sex};
```
Por *Default* os enumerados iniciando em 0 e vão se incrementando, mas podemos indicar com qual número ele vai iniciar.
Caso seja necessário uma comparação, poderemos fazer da seguinte maneira:

```csharp
Days day = Days.Sat; 
if ((byte) day == 1) 
    {
        //Faz alguma coisa
    }
```


Tipos por valor são recomendadas para pequenas estruturas, objetos são logicamente imutaveis (que não está sujeito a mudar), existem muitos objetos.

---


Às vezes, o termo “função” é usado e, às vezes, o termo “método” é usado. Em C#, o significado de uma função implica que ela retorna um valor e não modifica nada no sistema. 
Você pode dizer que uma função é a parte de “leitura” do sistema, na linguagem temos as consultas do tipo *linq* para tal. 
Muitas das vezes a definição de função está relacionado com um método. A verdade é que para o C# são as mesmas coisas, mas sendo amplamente usado o nome "Método"


---
Contrutores podem receber diversos tipos de parametros em métodos, podemos até definir valores durante a definição e chamada do método.
Chamamos isso de Parâmetros opcionais e/ou nomeados.

```csharp
void MyMethod(int firstArgument, string secondArgument = "default value",
    bool thirdArgument = false) { }

void CallingMethod()
{
    MyMethod(1, thirdArgument: true);
    MyMethod(1, "Alter Value", true);
}
```
No exemplo podemos passar ou não o segundo ou terceiro parâmetro.


Através da palavra *this* podemos chamar métodos também utilizando o simbolo de *':'* e caso exista, atenndedo os parametros

```csharp
    public class ConstructorChaining
    {
        private int _p;
        private string s;
       
        public ConstructorChaining() : this(3)
        {
        }

        public ConstructorChaining(int p)
        {
            this._p = p;
        }
        public ConstructorChaining(string j)
        {
            this.s = j;
        }
    }
```
No código acima o *this* chama o construtor que recebe um inteiro por parametro;


Padrão SOLID (Designing class)

Ao projetar uma nova classe, você deve ter em mente alguns dos principais princípios de design. 
Esses princípios ajudam você a criar classes que podem ser facilmente usadas, mantidas e estendidas. 
Precisamos garantiar que as classes sejam:
- De Baixa Coplamento
- De Alta Coesão

Esses princípios significam que o código não deve depender de outro código quando não for absolutamente necessário.
Isso permite que você faça alterações no código sem se preocupar com o fato de suas alterações passarem pelo código e afetarem outros subsistemas.




| Initial        | Resumo          | Definição  |
| ------------- |:-------------:| -----:|
| S | Responsabilidade única                 | Uma classe deve ter apenas uma responsabilidade.  |
| O | Princípio Aberto/Fechado               | Um objeto deve estar aberto para extensão, mas fechado para modificação.  |
| L | Princípio da Substituição              |   Um tipo base deve ser substituível por subtipos em cada situação |
| I | Princípio de segregação das interfaces | Use interfaces específicas do cliente em vez de uma interface geral. |
| D | Princípio da inversão de dependêncio   |   Dependa de abstrações, não concreções.  |


### Tipos genericos
Uma área no .NET Framework na qual você pode ver o uso de genéricos está no suporte para Nullables . Um tipo de referência pode ter um valor real de nulo, significando que não possui valor. Um tipo de valor não pode ter um valor null, no entanto. 
Por exemplo, como você expressaria que algum valor booleano é verdadeiro, falso ou desconhecido? Um booleano normal só pode ser verdadeiro ou falso.

É por isso que os Nullables foram adicionados ao .NET Framework. Um Anulável é um wrapper em torno de um tipo de valor com um sinalizador Booleano que ele armazena se o Nullable tiver um conjunto de valores.
O símbolo de interrogação *?* identifica um tipo primitivo nulável.


### Métodos de Extensão

No .NET 4.0, um novo recurso foi adicionado, chamado de métodos de extensão , que permite adicionar novos recursos a um tipo existente.
Você não precisa fazer nenhuma modificação no tipo existente; Basta trazer o método de extensão para o escopo e chamá-lo como um método de instância regular.
Para extensão do método devemos dizer seu tipo, ser público e estático
A diferença para um método estático comum é u uso do this




## 2.2 Boxing and UnBoxing

Como o C # é principalmente uma linguagem tipada estatisticamente, não é possível alterar o tipo de uma variável após ela ser declarada. A menos que exista uma conversão explícita, não é possível converter um item para outro. 
Por exemplo, a conversão de um int em um double é permitida, mas a alteração de um *ANimal em uma *Pessoa* não é permitida.
Vamos falar sobre dois tipos de conversões:

- Explícita
Com a conversão **explícita** precisamos informar ao compilador, qual será o tipo de retorno. Fazendo um cast do tipo. Obs.: Nesses casos o compilador entende que você sabe o que esta fazendo,
caso a conversão não seja possível uma exeção será lançada.
```csharp
int a = (int) 12,37 
//a == 12
```

https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/explicit

- Implícita
Uma conversão implícita não precisa de nenhuma sintaxe especial. Pode ser executado porque o compilador sabe que a conversão é permitida e que é seguro converter.

```csharp
int i = 42;
double d = i;
```
https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/implicit


### Operador (Operator)
Use **operator** para sobrecarregar um operador interno ou para fornecer uma conversão definida pelo usuário em uma declaração de classe ou struct.

https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/operator

-- 
Podemos definir operadores para converter implicitamente e explicitamente, fazendo uso de métodos da classe. Exmplos podem ser encontrados no Repositorio.


### Verificando uma conversão

O C# disponibiliza o operador **is** e **as** que verifica se um tipo pode ser convertido para outro auxiliando em uma conversão segura.

O operador **as** é como uma operação de conversão. No entanto, se a conversão não for possível, **as** retorna null em vez de gerar uma exceção.
Observe que o operador **as** executa somente conversões de referência, conversões que permitem valor nulo e conversões boxing. O operador **as** não pode realizar outras conversões, como conversões definidas pelo usuário que, em vez disso, devem ser realizadas usando expressões de conversão.

A palavra-chave **is** avalia a compatibilidade de tipo em tempo de execução. Ela determina se uma instância de objeto ou o resultado de uma expressão pode ser convertido em um tipo especificado. Retornando **true** ou **false**.



## 2.3 Encapsulamento 


| Tipo               | Definição     |
| -------------      |:-------------:|
| Public             | o acesso não é restrito. |
| Protected          | o acesso é limitado à classe que os contém ou aos tipos derivados da classe que os contém. |
| Internal           | o acesso é limitado ao assembly atual. |
| Protected Internal | o acesso é limitado ao assembly atual ou aos tipos derivados da classe que os contém. |
| Private            | o acesso é limitado ao tipo recipiente. |
| Private Protected  | o acesso é limitado à classe que o contém ou a tipos derivados da classe que o contém no assembly atual. |




## 2.4 Hierarquia

A palavra-chave abstract permite que você crie classes e membros de classe que estão incompletos e devem ser implementados em uma classe derivada.

A palavra-chave sealed permite evitar a herança de uma classe ou de determinados membros de classe que foram marcados anteriormente com virtual.
Uma classe sealed não pode ser usada como uma classe base. Por esse motivo, também não pode ser uma classe abstrata. As classes sealed impedem a derivação. 



### Implementando Interfaces padrões do .Net

O .NET Framework possui algumas interfaces padrão que você pode usar em seus próprios tipos. Ao implementar essas interfaces, suas classes podem ser usadas na infraestrutura que o .NET Framework oferece.


#### IComparable

A interface *IComparable* define um método genérico de comparação específica de tipo que um tipo de valor ou classe implementa para ordenar ou classificar suas instâncias.
Essa interface é implementada por tipos cujos valores podem ser ordenados ou classificados. Ela requer que os tipos de implementação definam um único método, *CompareTo(Object)* , que indica se a posição da instância atual na ordem de classificação é antes, depois, ou o mesmo que um segundo objeto do mesmo tipo.

Essa interface contém um único método que você pode usar para classificar os elementos. O método CompareTo retorna um valor int que mostra como dois elementos estão relacionados. 
A Tabela abaixo mostra os valores possíveis que o método *CompareTo*:


| Tipo  | Definição     |
| ------|:-------------:|
| (< 0) | A instância atual precede o objeto especificado pelo método CompareTo na ordem de classificação. |
| (= 0) | Essa instância atual ocorre na mesma posição na ordem de classificação que o objeto especificado pelo método CompareTo . |
| (> 0) | Esta instância atual segue o objeto especificado pelo método CompareTo na ordem de classificação. |


A chamada do método **Sort()** na lista, chama o método **CompareTo** para classificar os itens. Após a triagem, a lista é atualizada com a ordenação definida.


#### IEnumerable e IEnumerator

O **IEnumerable** e **IEnumerator** interface no .NET ajuda a implementar o padrão de iterador , que lhe permite aceder a todos os elementos em uma coleção sem se preocupar como ele é exatamente implementado. Você pode encontrar essas interfaces nas **System.Collection** e **System.Collections.Generic** namespaces. 
Ao usar o padrão de iterador, você pode facilmente iterar sobre os elementos em uma matriz, uma lista ou uma coleção personalizada. 
Ele é muito usado no LINQ, que pode acessar todos os tipos de coleções de uma maneira genérica sem realmente se importar com o tipo de coleção.

A interface **IEnumerable** expõe um método **GetEnumerator** que retorna um enumerador . O enumerador tem um método **MoveNext** que retorna o próximo item na coleção.
Sempre que implementar a **IEnumerable** terá que implementar de alguma forma, na classe ou em outro local a interface **IEnumerator**.

O fato do **IEnumerable** iterar sobre uma classe nos lembra um requisito minímo para utilização do **ForEach**, ser uma lista *iteravél*. O **ForEach** está usando internamente os métodos **GetEnumerator** e **MoveNex**.

```csharp
//MoveNext() returna 'true' se houver novos elementos e 'false' caso não haja
//'Current' seria o objeto atual,´o tipo já se sabe(no caso string), pois foi definido no Using
//A função GetEnumerator em um IEnumerable retorna um IEnumerator .
List<string> numbers = new List<string> { "1", "2", "3", "5", "7", "9" };
using (List<string>.Enumerator enumerator = numbers.GetEnumerator())
{
    while (enumerator.MoveNext())
    Console.WriteLine(enumerator.Current);
}
```



#### IDisposable

Será visto no 2.6


## 2.5 Reflection

Uma aplicação .NET não contém apenas código e dados; Ela também contém metadados, que são informações sobre os dados. 
No .NET, isso significa que um aplicativo contém o código que define o aplicativo e os dados que descrevem o código. 
Um **atributo(Attribute)** é um tipo de metadado que pode ser armazenado em um aplicativo .NET. Outros tipos de metadados contêm informações sobre os tipos, código, assembly e todos os outros elementos armazenados em seu aplicativo.
*Reflection* é o processo de recuperar esses metadados em tempo de execução. Os dados podem ser inspecionados e usados para tomar decisões.


### Attributes

Os *Attributes* podem ser usados para descrever as informações do autor de uma assembly ou para fornecer dicas específicas ao compilador sobre como otimizar seu código, perante os atributos definidos. 
Atributos personalizados podem armazenar todos os tipos de dados que você deseja. No .Net, você aplica um atributo colocando o nome do atributo entre colchetes ([]) acima da declaração à qual deseja aplicar o atributo.
Um bom exemplo é o atributo **[Serializable]**, com sua utilização podemos armazenar um objeto em um arquivo (xml, json,txt...), para que seja possível sua recuperação. Lembrando que: 
- "A **Serialização** é o processo de converter um objeto em uma sequência linear de bytes que podem ser armazenados ou transferidos."
 

### Reflection

O Reflection, no .NET, é uma funcionalidade em que é possível ler os dados de um objeto quanto à sua classe, ou seja, obtendo informações em tempo de execução sobre:
- Propriedades da classe;
- Métodos;
- Outros valores.

### Lambda
Uma expressão lambda é uma **função anônima** que você pode usar para criar delegados ou tipos de árvore de expressão. Ao usar expressões lambda, você pode escrever funções locais que podem ser passadas como argumentos ou retornadas como o valor de chamadas de função. 
Expressões lambda são particularmente úteis para escrever expressões de consulta LINQ.

Para criar uma expressão lambda, especifique os parâmetros de entrada (se houver) no lado esquerdo do operador lambda **=>** e coloque a expressão ou o bloco de instruções do outro lado. 
Por exemplo, a expressão lambda ```x => x * x``` especifica um parâmetro chamado **x** e retorna o valor de **x ao quadrado**. Exemplo:

```csharp
delegate int del(int i);  
static void Main(string[] args)  
{  
    del myDelegate = x => x * x;  
    int j = myDelegate(5); // Exibe: j = 25  
} 
```

Nos fontes há mais exemplos de exmpressões lambda.

#### Func

**Func** é usado para determinar um *delegate*. Ou seja é para tipar (criar uma assinatura) uma função anônima. 
Nele é especificado os tipos de diversos parâmetros e o tipo do retorno da função.

```csharp
var operacoes = new Dictionary<string, Func<int, int, int>> {
    {"+", (op1, op2) => op1 + op2 },
    {"-", (op1, op2) => op1 - op2 },
    {"*", (op1, op2) => op1 * op2 },
    {"/", (op1, op2) => op1 / op2 }
};
Write(operacoes["+"](10, 20)); //imprime 30
```
No exemplo acima, a função terá dois parâmetros inteiros e seu retorno também será um inteiro. Por isso criamos uma função de três inteiros.


#### Action

**Action** é uma *Func* que não terá um retorno, ou seja, é função anônima que retorna nada (seria o tipo *void*). Ela faz uma ação ao invés de dar um resultado, como costuma acontecer com funções

```csharp
var acoes = new Dictionary<string, Action<int>> {
    {"Criar", (parametro) => Criar(parametro) },
    {"Editar", (parametro) => Editar(parametro) },
    {"Apagar", (parametro) => Apagar(parametro) },
    {"Imprimir", (parametro) => Imprimir(parametro) }
};
acoes["Criar"](1); //executará o método Criar
```
No exemplo acima só teremos uma função com um parâmetro inteiro.


#### Predicate

**Predicate** é uma *Func* que retorna um *bool*. Hoje ele não é muito necessário. *Func* resolve já resolveria, porém use se quiser realmente indicar que aquilo não é uma função qualquer, mas sim um predicado (critério para um filtro). 
**Predicate** só pode ter um parâmetro. Os dois tipos anteriores permitem até 16 parâmetros já que existem vários tipos com assinaturas diferentes.

```csharp
var compareZero = new Dictionary<string, Predicate<int>> {
    {">", (x) => x > 0 },
    {"<", (x) => x < 0 },
    {"=", (x) => x == 0 }
};
Write(compareZero["="](5)); //imprimirá False
```

O exemplo acima só passa um parâmetro, pois predicados só aceitam um memso :P.



#### Árvores de Expressão

Árvores de expressão representam código em uma estrutura de dados de árvore, onde cada nó é, por exemplo, uma expressão, uma chamada de método ou uma operação binária como ```x < y```
Existe um código exemplo no repósitorio, use debug para entender melhor a execução do código.




## Cap 2.6 Manage the object life


### Garbagge collection


No CLR (Common Language Runtime), o coletor de lixo atua como um gerenciador automático de memória. Ele oferece os seguintes benefícios:

- Permite que você desenvolva seu aplicativo sem a necessidade de liberar memória.

- Aloca objetos no heap gerenciado com eficiência.

- Recupera os objetos que não estão sendo usados, limpa a memória e mantém a memória disponível para alocações futuras. Os objetos gerenciados obtêm automaticamente conteúdo limpo com o qual começar, portanto, seus construtores não precisam inicializar cada campo de dados.

- Fornece segurança de memória, assegurando que um objeto não possa usar o conteúdo de outro objeto.

Diferentemente do C++, a linguagem C# existe o *Garbagge collection*, que faz todo o gerenciamento da alocação e liberação de memória para recursos gerenciados.
Aoi decorrer do desenvolvimento de software, poderemos lidar com recursos não gerenciados pelo GC, como conexões de bancos de dados, conexão de rede e manipulação de arquivos. Neste casos,
é imprescindível o próprio desenvolvedor fazer a liberação dos recursos alocados o mais rápido possível. Os erros mais comuns ao não liberar tais recursos: "Este arquivo está em uso por outro processo" ou
"Não foi possível conectar ao banco de dados, verifique se há conexões disponíveis".

Há dois lugares na memória em que o CLR armazena itens enquanto seu código é executado. Uma é a pilha; o outro é o heap . A pilha controla o que está sendo executado em seu código, e o heap controla seus objetos. O heap é gerenciado pelo coletor de lixo.

Existe dois tipos de objetos considerando esse contexto, managed e unmanaged.

- Objetos managed são aqueles que estão sendo controlados diretamente pelo garbage collector. Ou seja, objetos de classes do seu sistema normalmente são managed;
- Objetos unmanaged são o inverso. Um provider de banco de dados, por exemplo, escrito em uma DLL que não seja do .NET. Normalmente objetos assim possuem um procedimento próprio de liberação de memória , especificado pelo provedor da tecnologia.

#### Finally

Os problemas citados anteriormente ao manipular recursos não gerenciados, podem ser evitados. O C# disponibiliza o conceito de *finally*. O propósito de uma instrução *finally* é garantir que a limpeza necessária de objetos, normalmente objetos que estão mantendo recursos externos.
Um exemplo dessa limpeza é chamar Close em um FileStream imediatamente após o uso, em vez de esperar que o objeto passe pela coleta de lixo feita pelo Common Language Runtime.

A instrução using garante que *Dispose* seja sempre chamado. Todo tipo que implementa *IDisposable* deve ser usado em uma instrução *using* sempre que possível. Dessa forma, você garante a limpeza de todos os recursos não gerenciados.
Portanto não será necessário chamar a instrunção *finally*.

A instrunção é *using* tem a mesma finalidade da *finally* no exemplo abaixo:

```csharp
using (FileStream fs = new FileStream("teste.txt", FileMode.Create)) {
    // Algum código...
}
```
É o mesmo que:

```csharp
{
    FileStream fs = new FileStream("teste.txt", FileMode.Create);
    try {
       // Algum código...
    } finally {
        if (fs != null)
            ((IDisposable)fs).Dispose();
    }
}
```

**Obs.:**  O coletor de lixo é bastante inteligente no gerenciamento de memória e não é recomendado que você chame **GC.Collect**





#### IDISPOSABLE


Uma grande observação deve ser feitaq sobre tudo o que foi dito anteriormente neste capítulo. 
**Liberação de recursos é diferente de liberação de memória. O *garbage collector* libera a memória quando ele puder e achar necessário. Ele não libera recursos.**

Todas as classes que precisam desta liberação devem implementar a interface *IDisposable*, ou seja, precisa criar uma implementação do método *Dispose()* que encerrará a vinculação do recurso com a aplicação. Por isso é comum que a implementação chame o método *Close()*.


O coletor de lixo do *Common Language Runtime* recupera a memória usada por objetos gerenciados, mas os tipos que usam recursos não gerenciados implementam a interface *IDisposable* para permitir que a memória alocada para esses recursos não gerenciados seja recuperada.
Após terminar de usar um objeto que implementa *IDisposable*, você deverá chamar a implementação de *IDisposable.Dispose()* do objeto. Você pode fazer isso de duas maneiras:

Com a instrução using do C# ou a instrução Using do Visual Basic.

Implementando um bloco try/finally.

Criar seu próprio tipo personalizado que implementa *IDisposable* e um finalizador corretamente não é uma tarefa trivial.

Maiores detalhes e exemplos olhar o fonte e a especificação:
https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose




## Cap 2.7 Strings

Uma string em C # é um objeto do tipo String cujo valor é text. O objeto string contém uma matriz de objetos Char internamente. Uma string tem uma propriedade Length que mostra o número de objetos Char que ela contém. 
String é um tipo de referência que se parece com o tipo de valor (por exemplo, os operadores de igualdade == e ! = Estão sobrecarregados para comparar em valor, não em referência).

Em C #, você pode se referir a uma string como String e string . Você pode usar qualquer convenção de nomenclatura adequada a você. A palavra-chave string é apenas um alias para a String do .NET Framework.
Uma das características especiais de uma string é que ela é imutável , portanto ela não pode ser alterada depois de criada. Toda mudança em uma string irá criar uma nova string.

Ao trabalhar com um número tão grande de operações de string, você deve ter em mente que string é imutável e que o .NET Framework oferece algumas classes auxiliares especiais ao lidar com strings.

### Manipulando cadeias de *String*


```csharp
string s = string.Empty(); 

for (int i = 0; i <10000; i ++) 
{ 
    s + = "x"; 
}
```
Esse código será executado 10.000 vezes e, a cada vez, criará uma nova string. 
A referência 's' apontará apenas para o **último** item, portanto, todas as outras sequências estão imediatamente prontas para a coleta de lixo.
O código acima parece simples, mas utiliza muita memória de maneira desnecessária
Ao trabalhar com um número tão grande de operações de string, você deve ter em mente que string é imutável e que o .NET Framework oferece algumas classes auxiliares especiais ao lidar com strings.


#### StringBuilder 

 
A classe *System.Text.StringBuilder* pode ser usada quando você deseja modificar uma cadeia de caracteres sem criar um novo objeto. Por exemplo, o uso da classe *StringBuilder* pode melhorar o desempenho ao concatenar várias cadeias de caracteres em um loop.

```csharp
//Cria uma instancia d estringBuilder
StringBuilder sb = new StringBuilder (string.Empty); 

for (int i = 0; i <10000; i ++) 
{ 
    sb.Append ("x"); 
}
```

Uma coisa a ter em mente é que o StringBuilder nem sempre dá melhor desempenho. Ao concatenar uma série fixa de cadeias de caracteres, o compilador pode otimizar isso e combinar operações de concatenação individuais em uma única operação.

#### StringWriter and StringReader

Algumas APIs no .NET Framework esperam que um **TextWriter** ou **TextReader** funcione. Essas APIs não podem trabalhar diretamente com uma **string** ou **StringBuilder**. Devido a isso, o .NET Framework adiciona uma classe **StringReader** e **StringWriter**. 
Essas classes adaptam a interface do **StringBuilder** para que possam ser usadas em locais onde um **TextWriter** ou **TextReader** é esperado.

Exemplo: Usando um StringWriter como saída para um XmlWriter

```csharp
var stringWriter = new StringWriter();
using (XmlWriter writer = XmlWriter.Create(stringWriter))
{
    writer.WriteStartElement("book");
    writer.WriteElementString("price", "19.95");
    writer.WriteEndElement();
    writer.Flush();
}
string xml = stringWriter.ToString();
```

The value of xml is now:


```xml 
< ?xml version=\"1.0\" encoding=\"utf-16\"?>
    < book>
        < price>19.95</price>
    < /book>
```

#### Cultura do App

O *CultureInfo* classe contém informações específicas de cultura, como o idioma, país/região, calendário e convenções culturais. Essa classe também fornece as informações necessárias para executar operações específicas de cultura, como casing, formatação de datas e números e comparação de seqüências de caracteres.

```csharp
double cost = 1234.56;
Console.WriteLine(cost.ToString("C",
                  new System.Globalization.CultureInfo("en-US")));
// Displays $1,234.56
```

Fornecer o *CultureInfo* correto é importante ao formatar valores. Ele contém todas as informações necessárias sobre como um determinado tipo é exibido nessa cultura. Da mesma forma, é importante ter certeza de que, quando você salvar valores em um banco de dados; por exemplo, você faz isso de uma maneira insensível à cultura. 
Se os dados insensíveis à cultura forem carregados, eles poderão ser formatados dependendo do usuário que estiver visualizando os dados.


#### IFormattable e IFormatProvider 

Ao formatar strings, você também pode usar um *IFormatProvider* . O *IFormatProvider* tem um método, *GetFormat(Type)* , que retorna informações específicas de formatação para formatar um tipo. Todos os objetos CultureInfo implementam *IFormatProvider* . O objeto *CultureInfo* retorna um *NumberFormatInfo* ou *DateTimeFormatInfo* específico da cultura se uma string ou DateTime formatado.
Dessa forma, você pode formatar uma string como cultura específica, passando um objeto *CultureInfo* para o *ToString* método.

# Parte 3 Debug and security


## 3 Depurar aplicativos e implementar segurança

### 3.5 Implementar log de rastreamento
Aplicativos do .NET framework são depurados facilmente usando o Visual Studio, que lida com muitos dos detalhes de configuração. Se o Visual Studio não estiver instalado, você poderá examinar e melhorar o desempenho de aplicativos do .NET Framework por meio das classes de depuração do namespace System.Diagnostics do .NET Framework. Este namespace inclui as classes Trace, Debug e TraceSource para rastreamento de fluxo de execução e as classes Process, EventLog e PerformanceCounter para criação de perfil de código.

A classe  *TraceSource* fornece recursos de rastreamento avançados e pode ser usada no lugar dos métodos estáticos das classes de rastreamento antigas *Trace* e *Debug*. As classes *Trace* e *Debug* conhecidas ainda são amplamente usadas, mas a classe *TraceSource* é recomendada para novos comandos de rastreamento, como *TraceEvent* e *TraceData*.

As classes Trace e Debug fornecem os meios para monitorar e examinar o desempenho do aplicativo durante o desenvolvimento ou após a implantação. Por exemplo, é possível usar a classe Trace para acompanhar determinados tipos de ações em um aplicativo implantado, conforme eles ocorrem (por exemplo, criação de novas conexões de banco de dados) e, portanto, é possível monitorar a eficiência do aplicativo.

--- 
Durante o desenvolvimento, use os métodos de saída da classe Debug para exibir mensagens na janela de Saída do IDE:

```csharp
System.Diagnostics.Trace.WriteLine("Hello World!");  
System.Diagnostics.Debug.WriteLine("Hello World!");  
```

Há três fases de rastreamento de código:

1. **Instrumentação** – você adiciona o código de rastreamento ao aplicativo.

2. **Rastreamento** – o código de rastreamento grava as informações no destino especificado.

3. **Análise** – você avalia as informações de rastreamento para identificar e entender problemas no aplicativo.



#### Saída de Rastreamento

A saída de rastreamento é coletada por objetos chamados ouvintes. Um ouvinte é um objeto que recebe a saída de rastreamento e grava-a em um dispositivo de saída (geralmente, uma janela, um log ou um arquivo de texto). Quando um ouvinte de rastreamento é criado, normalmente, ele é adicionado à coleção Trace.Listeners, permitindo que o ouvinte receba toda a saída de rastreamento.


Os seis membros Debug e métodos Trace que gravam informações de rastreamento são listados na tabela a seguir:


| Método        | Saída           |
| ------------- |:-------------:|
| Assert      | O texto especificado; ou, se nenhum for especificado, a Pilha de Chamadas. A saída é gravada somente se a condição especificada como um argumento na instrução Assert é false. |
| Fail      | O texto especificado; ou, se nenhum for especificado, a Pilha de Chamadas. |
| Write | O texto especificado. |
| WriteIf      | O texto especificado, se a condição especificada como um argumento na instrução WriteIf é atendida. |
| WriteLine | O texto especificado e um retorno de carro. |
| WriteLineIf      | O texto especificado e um retorno de carro, se a condição especificada como um argumento na instrução WriteLineIf é atendida. |


---
* **TextWriterTraceListener**: Redireciona a saída para uma classe *Stream*.
* **EventLogTraceListener**: Redireciona a saída para um log de eventos.
* **DefaultTraceListener**: Emite mensagens Write e WriteLine para os métodos *OutputDebugString* e *Debugger.Log*. 
* **ConsoleTraceListener**: 


Podemos alterar o ouvinte do nosso rastreamento, qunado falo ouvinte podemos entender como receptor das mensagens geradas pela classe *Trace*, *Debug* e *TraceSource*.


Obs.: **Rastreamento de código** – Se refere ao Recebimento de mensagens informativas sobre a execução de um aplicativo em tempo de execução.


```csharp
Debug.WriteLine(“Starting application”);
Debug.Indent();
int i = 1 + 2;
Debug.Assert(i == 3);
Debug.WriteLineIf(i > 0, “i is greater than 0”);
```
Se a instrução Debug.Assert falhar, você receberá uma caixa de mensagem mostrando o rastreamento de pilha atual do aplicativo. Esta caixa de mensagem pede que você tente novamente, aborte ou ignore a falha de asserção. Você pode usar o Debug.Assert para indicar um erro no seu código que você deseja indicar ao desenvolver seu aplicativo.




### 3.5 Criação de perfil de aplicativos

*Criação de perfil* é o processo de determinar como seu aplicativo usa determinados recursos. Você pode verificar, por exemplo, quanta memória seu programa usa, quais métodos estão sendo chamados e quanto tempo cada método leva para executar.
Essas informações são necessárias quando você tem um afunilamento de desempenho e deseja encontrar a causa.

Ao criar um perfil, podemos utilizar o *Wizard Perfomance*. Ao criar um perfil, será disponibilizado 4 opções de escolha:


| Tipo        | Descrição           |
| ------------- |:-------------:|
| CPU Sampling           | A *Amostragem de CPU* serve para analisar através de gráficos a útilização da CPU. |
| Instrumantation        | A *Instrumentação* é um método que insere códigos nos arquivos compilados e captura informações a cada chamada de função. |
| .NET Memory Allocation | A *Alocação de memória* intercepta seu código todo vez que um novo registro é inserido na memória ou qunado o *Garbagge collect* é chamado. |
| Resource Content Data  | O *Dados de contenção de recursos* é um método que pode ser usado em aplicativos multithread para descobrir por que os métodos precisam esperar um pelo outro antes de poderem acessar um recurso compartilhado.  |




### 3.5 Criar e monitorar contadores de desempenho

O Windows fornece um grande número de contadores de desempenho categorizados que você pode usar para monitorar seu hardware, serviços, aplicativos e drivers.
Exemplos de contadores de desempenho são aqueles que exibem o uso da CPU e do uso de memória, mas também contadores específicos do aplicativo, como o comprimento de uma consulta no SQL Server.

No Windows temos o *Monitor de Desempenho*, que exibe diversas informações sobre a performance atual do sistema. 
Podemos ler os valores dos contadores de desempenho por código usando a classe *PerformanceCounter* também encontrada no namespace *System.Diagnostics*. No repósitorio também há um código exemplo

Todos os contadores de desempenho implementam IDisposable porque acessam recursos não gerenciados.
Após seu uso devemos descartá-los.
Criar seus próprios contadores de desempenho pode ser uma grande ajuda ao verificar a integridade de seu aplicativo. 
Você pode criar outro aplicativo para lê-los (algum tipo de aplicativo de painel) ou usar a ferramenta Monitor de Contador de Desempenho que o Windows fornece.


### 3.5 Escrever para o log de eventos

Além de podermos gravar nossos registros em arquivos e bancod dedados, podemos dizer via código que queremos gravar nossas informações de rastreamento
no *Log de Eventos* do próprio Windows. Para tal utilizaremos a classe *EventLog* ainda contida no namespace *System.Diagnostics*.
*Obs.:* É necessário executar o Visual Studio como administrador para gravar as informações de eventos do Windows.

Os logs gerados pelo código do repósitorio poderão ser visualizados no *Visualizador de Eventos do Windows'
É possível também ler os logs gerados através da classe *EventLogEntry*




# Implement Data Access


## Cap 4.1 I/O

### Trabalhando com arquivos e diretórios

Todos os tipos necessários podem ser encontrados no namespace System.IO.

#### Driver

Um objeto DriveInfo não possui nenhum método específico para lidar com unidades (por exemplo, não há um método de ejeção para um CD player). 
Ele possui várias propriedades para acessar informações, como o nome da unidade, o tamanho e o espaço livre disponível. Como no exemplo abaixo e nos fontes.

```csharp
DriveInfo[] drivesInfo = DriveInfo.GetDrives();
```



#### Directory


Uma unidade contém uma lista de diretórios e arquivos. Para trabalhar com esses itens, você pode usar o objeto DirectoryInfo ou a classe Directory estática . Ambas as classes oferecem acesso à sua estrutura de pastas. Ao executar apenas uma única operação em seu sistema de arquivos, pode ser mais eficiente usar a classe Directory estática.
Quando você deseja executar várias operações em uma pasta, DirectoryInfo é uma escolha melhor.


```csharp
var directory = Directory.CreateDirectory(@"C:\Temp\Directory");

var directoryInfo = new DirectoryInfo(@"C:\Temp\DirectoryInfo");
directoryInfo.Create();

```

Outro método que pode ser útil é o método **MoveTo** nas classes **DirectoryInfo** ou **Move** de **Directory** quando você deseja mover um diretório existente para um novo local.

```csharp
Directory.Move(@"C:\source", @"c:\destination");

DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Source");
directoryInfo.MoveTo(@"C:\destination");
```


#### File

Diretórios são necessários apenas para dar alguma estrutura aos arquivos que eles precisam armazenar. Assim como com **Directory**, você pode usar a classe **File** estático e/ou um objeto **FileInfo** para acessar arquivos.

Para abrirmos o arquivo *read.txt* para leitura, utilizamos o código a seguir:

```csharp
Stream entrada = File.Open("read.txt", FileMode.Open);
```
Como podemoves ver no código acima, é retornado um vetor de bytes através da classe **Stream**, mas no caso queremos ler texto. Para tal, poderemos usar as  classes *StreamReader* e *StreamWriter*, para leitura e escrita
respectivamente.

```csharp
StreamWriter writer = new StreamWriter(arquivoStream);
writer.WriteLine("Aqui esta meu texto");
```

Criando um arquivo:
```csharp
using (FileStream fs = File.Create(@"C:\temp2\numeros.txt"))
```
No exemplo acima, caso escrevamos algo, precisaremos trabalhar com um array de bytes. No repósitorio a mais exemplos.

Lembrando que estamos trabalhando com recursos não gerenciados, precisamos fechar os arquivos. Logo podemos chamar o método **Close** da classe **File** ou usar a instrunçao **Using**.

#### Path

A classe estática Path que pode ser encontrada em System.IO tem alguns métodos auxiliares para lidar com esses tipos de situações.

```csharp
string path = @"C:\temp2\arquivo.txt";

Console.WriteLine(Path.GetDirectoryName(path)); // Displays C:\temp2
Console.WriteLine(Path.GetExtension(path)); // Displays .txt
Console.WriteLine(Path.GetFileName(path)); // Displays arquivo.txt
Console.WriteLine(Path.GetPathRoot(path)); // Displays C:\
```

**Obs.:** Sempre use a classe Path ao combinar várias strings para formar um caminho.

### I/O Async

Utilizamos a instrução *File.Exists* que retorna um booleano para verificar s eum arquivo existe ou não. Mas ao criar um arquivo, podemos asegurar 
que este diretório existe ou não? Ou até mesmo tem permissão de acesso?
Não, porque você não é o único usuário que acessa o sistema de arquivos. Enquanto você está trabalhando com o sistema de arquivos, alguns outros usuários estão fazendo exatamente a mesma coisa. Talvez eles removam a pasta que você deseja usar para criar um novo arquivo. Ou, de repente, eles alteram as permissões em um arquivo para que você não possa mais acessá-lo.

Normalmente, ao lidar com uma situação em que vários usuários acessam recursos compartilhados, começamos a usar um mecanismo de bloqueio para sincronizar o uso de recursos. C # tem um mecanismo de bloqueio que você pode usar para sincronizar o acesso ao código quando vários encadeamentos estiverem envolvidos. Isso garante que um determinado código não possa ser executado simultaneamente no mesmo momento.
Todo o código que você viu até agora neste capítulo é chamado de código *síncrono*.
Quando trabalahos com aplicativos que possuem uma interface gráfica, como WPF ou Windows Store, o app trabalha com uma thread responsável por gerenciar a interface com o usuário.
Se por algum motivo essa thread parar de responder, o tela de exibição vai parar de responder. O problema é que muitos usuários fecham a aplicação pensando que o sistema travou, quando 
na verdade pode estar aguardando algum tipo de solicitação.
É importante executar tarefas de longa duração em outras threads.

#### Async / Wait in Files

**Async/await** é um sinal para o compilador que você deseja executar algum código assíncrono.
É importante saber que a classe estática *File* não oferece suporte a I/O de forma assíncrona real. Para uma I/O assíncrona real, você precisa usar o objeto *FileStream* e passar um valor *true* para o parâmetro useAsync.

O método abaixo *WriteAsync* é marcado com o modificador *async* para sinalizar ao compilador que você deseja alguma ajuda para transformar seu código e, finalmente, usar a palavra-chave *await* na tarefa retornada.


```csharp
public  async Task CreateAndWriteAsyncFile()
{
    using (FileStream fileStream = new FileStream("teste.txt", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
    {
        byte[] data = new byte[100000];
        new Random().NextBytes(data);

        await stream.WriteAsync(data, 0, data.Length);
    }
}
```
Explicação:
O construtor de *FileStream*, está passando o nome do arquivo, o que faremos com o arqivo no caso criar, o tipo de acesso, se o arquivo será compartilhado, o tamanho do buffer e por último se será *assincrono*

O objeto *Task* retornado representa algum trabalho em andamento, encapsulando o estado da operação assíncrona. Eventualmente, o objeto *Task* retorna o resultado da operação ou exceções que foram levantadas de forma assíncrona.
Neste método não há nenhum valor a ser retornado ao responsável pela chamada. É por isso que o *WriteAsync* retorna um objeto *Task* comum. Quando um método tem um valor de retorno, ele retorna **Task<T>** , onde **T** é o tipo do valor retornado.

No exemplo abaixo, o método retorna uma **Task<string>** , o que significa que, eventualmente, quando o processo é concluído, um valor de string está disponível.

```csharp
public async Task ReadAsyncHttpRequest()
{
    HttpClient client = new HttpClient();
    string result = await client.GetStringAsync("http://www.google.com.br");
}
```
Sempre que a linguagem fornecer métodos Async equivaletnes, dê prioridade ao seu uso. Isso retorna uma melhor experiência ao usuário e evita possíveis exceções, mas cuidado.

**Task.WhenAll**
Podemos esperar todas as solicitações que estão sendo executadas de forma **paralela**, para tal usamos o método *WhenAll()* da classe *Task*.
Assim que você chamar **GetStringAsync** , a operação assíncrona é iniciada. No entanto, você não espera imediatamente pelo resultado. Em vez disso, você permite que todas as três solicitações sejam iniciadas e, em seguida, você espera que elas sejam concluídas. 

Exemplo.:
```csharp
public async Task ExecuteMultipleRequestsInParallel()
{
    HttpClient client = new HttpClient();

    Task google = client.GetStringAsync("http://www.google.com");
    Task msdn =  client.GetStringAsync("http://msdn.microsoft.com");
    Task blogs = client.GetStringAsync("http://blogs.msdn.com/");

    await Task.WhenAll(google, msdn, blogs);
}
```

### WebRequest, WebResponse, WebClient and HttpClient in System.Net


O .NET Framework tem suporte para permitir que seus aplicativos se comuniquem através de uma rede. O namespace *System.Net* define um grande número de classes que ocultam a complexidade de executar operações de rede e, ao mesmo tempo, fornecer uma interface fácil de usar.

De todos esses membros, os que você provavelmente usará são o *WebRequest* e o *WebResponse* . Essas classes são classes base abstratas que oferecem suporte para comunicação em uma rede. Implementações específicas definem o protocolo a ser usado para comunicação.
Por exemplo, você pode usar *HttpWebRequest* e *HttpWebResponse* ao usar o protocolo HTTP.

O *WebRequest* e o *WebResponse* formam um par de classes que você pode usar em conjunto para enviar uma solicitação de informações e, em seguida, receber a resposta com os dados solicitados.

Um *WebRequest* é criado usando um método *Create* estático na classe *WebRequest*. O método *Create* inspeciona o endereço que você passa para ele e, em seguida, seleciona a implementação correta do protocolo. 
Se você passasse o endereço **http://www.microsoft.com** para ele, veria que você está trabalhando com o protocolo *HTTP* e retornaria um *HttpWebRequest*.
Depois de criar o *WebRequest* correto, você pode definir outras propriedades, como instruções de autenticação ou armazenamento em cache.

Quando você terminar de redigir sua solicitação, chame o método GetResponse para executar a solicitação e recuperar a resposta.

```csharp
WebRequest request = WebRequest.Create("http://www.microsoft.com");
WebResponse response = request.GetResponse();

StreamReader responseStream = new StreamReader(response.GetResponseStream());
string responseText = responseStream.ReadToEnd();

Console.WriteLine(responseText); // Exibe o HTML do site da Microsoft

response.Close();
```
O problema é que para fazer um simples *request* precisamos de 5 linhas de código. 


A classe *WebClient* é uma abstração de alto nível construída no topo do *HttpWebRequest* para simplificar as tarefas mais simples envolvidas nas requisições HTTP.``
Ela fornece métodos para enviar dados ou receber dados de qualquer recurso identificado pela URI; seja local , intranet ou internet. 

```csharp
var cliente = new WebClient();
var text = cliente.DownloadString("http:/msdn.net");
Console.WriteLine(text); // Exibe o HTML do site da Microsoft
```


A classe **HttpClient** usa o novo padrão orientada a tarefa (*Task*) para lidar com solicitações assíncronas, possibilitando assim, gerenciar e coordenar de forma mais fácil solicitações pendentes;

```csharp
HttpClient cliente = new HttpClient();
string resultado = await cliente.GetStringAsync("http://www.docs.microsoft.net");

Console.WriteLine(resultado); // Exibe o HTML do site da Microsoft
```

### 4.2 Dados de consumo

O gerenciamento de dados é um dos aspectos mais importantes de um aplicativo. Imagine que você pode criar apenas aplicativos que armazenem seus dados na memória. Assim que o usuário sai, todos os dados são perdidos e os lançamentos subsequentes exigem a reentrada de todos os dados necessários. Claro, isso seria uma situação impossível de se trabalhar.

#### Conectando ao banco de dados

Dependendo do tipo de aplicativo, você usa o arquivo app.config ou web.config . Esses arquivos podem ser usados para armazenar todos os tipos de configurações para um aplicativo. Você também pode usar outros arquivos de configuração, que você faz referência a esses arquivos.

No exemplo abaixo, o *app.Config* é configurado para conectar no banco de dadosasdca 'ProgrammingInCSharpConnection'.


```html
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <connectionStrings>
        <add name="ProgrammingInCSharpConnection" 
     providerName="System.Data.SqlClient" 
     connectionString="Data Source=(localdb)\v11.0;Initial Catalog=ProgrammingInCSharp;"
/>
    </connectionStrings>
</configuration>
```


Se você quiser usar a seqüência de conexão em seu aplicativo, você pode usar a propriedade ConfigurationManager.ConnectionStrings do System.Configuration.dll . Você pode acessar seqüências de caracteres de conexão por índice e por nome, como mostrado abaixo.

```csharp
string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
}
```

Podemos alterar o arquivo *Web.Config* no momento do deploy de nossa aplicação. A maioria dos aplicativos têm configurações na Web. config arquivos que devem ser diferentes quando o aplicativo é implantado. 
Automatizando o processo de fazer essas alterações evita a necessidade para fazê-las manualmente sempre que você implanta, qual seria entediante e sujeito a erros.

Para maiores informações acessar:
https://docs.microsoft.com/pt-br/aspnet/web-forms/overview/deployment/visual-studio-web-deployment/web-config-transformations


Conectar-se a um banco de dados é uma operação demorada. Ter uma conexão aberta por muito tempo também é um problema porque pode levar outros usuários a não conseguirem se conectar. Para minimizar os custos de abrir e fechar conexões repetidamente, o ADO.NET aplica uma otimização chamada pool de conexões.

Ao usar o SQL Server, um pool de conexões é mantido pelo seu aplicativo. Quando uma nova conexão é solicitada, o .NET Framework verifica se há uma conexão aberta no pool. Se houver, não é necessário abrir uma nova conexão e fazer tudoas etapas iniciais de configuração. Por padrão, o pool de conexões está habilitado, o que pode proporcionar uma grande melhoria de desempenho.

#### SQL Injection

Devemos evitar SQL Injection ao atualizar ou inserir informações em nosso banco.

```csharp
public async Task InsertRowParameterized()
{
    string connectionString = ConfigurationManager.
        ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(
            "INSERT INTO People([FirstName], [LastName], [MiddleName]) VALUES (@firstName, @lastName, @middleName)", connection);
        await connection.OpenAsync();
        
        command.Parameters.AddWithValue("@firstName", "John");
        command.Parameters.AddWithValue("@lastName", "Doe");
        command.Parameters.AddWithValue("@middleName", "Little");

        int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
        Console.WriteLine("Inserted {0} rows", numberOfInsertedRows);
    }
}
```
Nos fontes a um exemplo de *update* e *delete*.

#### WCF - Web Service

O **WCF** é uma parte da .NET Framework que fornece um modelo unificado de programação para construir de forma rápida aplicações distribuidas orientadas a serviço (**SOA**).

* **Service Class** - Uma classe de serviço WCF que implementa um serviço com um conjunto de métodos;
* **Host Environment** -  Este é o grande diferencial do WCF pois podemos usar qualquer tipo de aplicação como host. Um Host Environment pode ser uma aplicação Console, um Windows Service, um Web Service, uma aplicação WIndows Forms ou o Internet Information Service no caso de um web service normal;
* **EndPoints** - Todas as comunicações com um serviço WCF irão acontecer via endpoints. O endpoint é composto de 3 partes (ABC´s endpoints):
  * Address - Consiste em especificar um endereço que define onde o endpoint esta hospedado. Cada endpoint possui um endereço especificado com ele que é usado para identificar e localizar o endpoint. (Geralmente é definido pela instância da classe Uri).
  * Binding - Especifica como o cliente irá se comunicar (qual transporte será usado: Http, Tcp, Ipc, WS, MSMQ, etc.) com serviço e o endereço onde o endpoint esta hospedado. A definição do Binding pode ser feita no arquivo de configuração ou via programação.
  * Contract - Especifica um contrato que define quais métodos da classe de Serviço serão acessíveis via endpoint, onde cada endpoint poderá expor um conjunto diferente de métodos; (O contrato é representado por uma Interface que deverá ser decorada com o atributo ServiceContract).
  *  Address + Binding + Contract = **Endpoint** (o famoso ABC's endpoints) 
  
O seguinte exemplo foi implementado no repositório:
https://msdn.microsoft.com/pt-br/library/bb386386.aspx?f=255&MSPPError=-2147217396


*Obs.: Tentei recriar o exemplo acima e um erro era gerado ao tentar compilar o projeto. Acabei desistentido de ter o exemplo no repósitorio.*  

#### XML in .NET

O .NET Framework ajuda você fornecendo classes que podem ser usadas para analisar, criar e editar arquivos XML - na memória e no disco.
| Nome        | Descrição           |
| ------------- |:-------------:|
| XmlReader      | Uma maneira rápida de ler um arquivo XML. Você pode avançar somente pelo arquivo e nada é armazenado em cache. |
| XmlWriter      | Uma maneira rápida de criar um arquivo XML. Assim como com o XmlReader , ele é somente encaminhado e não armazenado em cache. |
| XmlDocument    | Representa um documento XML na memória. Suporta navegar e editar um documento. |
| XPathNavigator | Ajuda na navegação por um documento XML para encontrar informações específicas.  |

Abaixo falarei um pouco mais sobre cada. No repósitorio há três projetos, na qual um arquivo denominado "People.xml" foi adicionando, para exemplificação.

##### XmlReader

Você cria uma nova instância de *XmlReader* usando o método Create estático. Você pode passar este método uma instância de **XmlReaderSettings** para configurar como o XML deve ser analisado. Dessa forma, você pode optar por ignorar dados de seu arquivo XML, como espaço em branco e comentários, ou iniciar em uma determinada posição
O mesmo já implementa *IDisposable*. De tal modo, usarei a instrunção *using* para garantir o gerenciamento dos recursos.

Quando um XmlReader é primeiro criado e inicializado, não há nenhuma informação disponível. Você deve chamar Read para ler o primeiro nó. Ou seja, o read(), lerá linha a linha de seu XML.


##### XmlWriter

Quando você deseja criar um arquivo XML, você pode usar a classe XmlWriter . Essa classe é criada usando o método Create estático e pode ser configurada usando uma instância da classe XmlWriterSettings 
No exemplo contido no repósitorio, criamos um stream 

##### XmlWriter

Embora XmlReader e XmlWriter sejam as opções mais rápidas, elas definitivamente não são as mais fáceis de usar. Principalmente na leitura de seus dados, 
é necessário percorrer linha a linha a fim de obter cada atributo e valor. Além disso, devemos conhecer a fundo a estrutura do XML.
uando você trabalha com documentos relativamente pequenos e desempenho não é tão importante, você pode usar a classe XmlDocument . Sua função principal permite editar arquivos XML e representa o XML de forma hierárquica na memória, permitindo que você navegue facilmente pelo documento e edite elementos no local.

##### JSON

Outro formato popular usado por muitos serviços da Web é o **JavaScript Object Notation (JSON)**. Embora o XML seja útil, ele é detalhado e possui muitas regras relacionadas à estrutura de um documento. O JSON é o que chamamos de alternativa "livre de gordura" ao XML.
Tem uma gramática mais fácil e muitas vezes carrega significativamente menos peso. 
Ao trabalhar com XML, você usa classes como XmlWriter , XmlReader e XmlDocument ; O JSON não possui classes como elas. Normalmente, ao trabalhar com JSON, você usa uma biblioteca de serialização que ajuda a converter objetos em JSON e vice-versa. Uma dessas bibliotecas populares é a *Newtonsoft.Json*, que está disponível em http://json.codeplex.com/ 


### 4.3 LINQ

Ao longo dos capítulos fizemos o uso do LINQ em diversos momentos, nesse capítulo iremos formalizar alguns conceitos e exemplificar outros.

#### Expressão Lambda

Para entender o que é uma expressão lambda, é importante que você primeiro saiba o que é um método anônimo. Métodos anônimos foram introduzidos no C # 2.0 para permitir que você crie um método embutido em algum código, atribua-o a uma variável e passe-o de volta.
Exemplo de uma método anônimo abreviado por *lambda* de multiplicação.


```csharp
Func <int, int> myDelegate = x => x * 3;
Console.WriteLine(myDelegate (10)); // 30
```

#### Extension Methods

*Extension Methods* podem ser usados para estender um tipo existente com novo comportamento sem usar herança. Um método de extensão é definido em uma classe estática e usa a palavra-chave *this* para se marcar como um método de extensão.
O exemplo abaixo cria uma classe com as extensões para o tipo *int*, neste caso temos acesso ao método *Multiply*.

```csharp
public static class IntExtensions
{
    public static int Multiply(this int x, int y)
    {
        return x * y;
    }
}
int x = 2;
Console.WriteLine(x.Multiply(10)); // 20
```

#### Query

Ao trabalhar com dados, seja na memória, em um banco de dados ou em um arquivo.
Todo provedor de LINQ é incentivado a implementar os operadores de consulta padrão para que você possa usá-los sempre. Isso significa que você pode usar esses operadores padrão em quase todas as fontes de dados, fornecendo uma experiência consistente.
Os operadores de consulta padrão são: *All, Any, Average, Cast, Count, Distinct, GroupBy, Join, Max, Min, OrderBy, OrderByDescending, Select, SelectMany, Skip, SkipWhile, Sum, Take, Take-While, ThenBy, ThenByDescending, and Where*.
Todos as operações de consulta LINQ consistem em três ações distintas:

1. Obter a fonte de dados.
 
2. Criar a consulta.

3. Executar a consulta.


Exemplo do operador *Select*



```csharp
int[] data = { 1, 2, 5, 8, 11 };
var result = from d in data 
             select d;
Console.WriteLine(string.Join(", ", result)); // 1, 2, 5, 8, 11
```

Através dos métodos anônimos, podemos utilizar uma projeção (*projection*) para agrupar(*grouping*) nossos dados da forma que quisermos. utilizando a instrução *Select new*, podemos selecionar apenas as propriedades que precisamos.
Exemplo:

```csharp
var result = from o in orders
             from l in o.OrderLines
             group l by l.Product into p
             select new
                 {
                    Product = p.Key,
                    Amount = p.Sum(x => x.Amount)
                 };
```

#### LINQ XML

Se você quiser consultar um arquivo XML com LINQ para XML, você pode usar a classe *XDocument* para carregar um arquivo ou uma string contendo XML na memória. A classe *XDocument* trabalha com objetos do tipo *XNode*.
*XNode* é uma classe abstrata que representa a ideia de algum segmento de conteúdo que um documento contém. Você pode usar *XDocument.Nodes* para acessar os nós que formam um arquivo XML, ou você pode usar *XDocument.Descendants* ou *XDocument.Elements* para procurar por um conjunto específico de nós.
Um dos ótimos recursos do *XDocumentclasse* é que representa o arquivo XML de forma hierárquica. Devido a isso, você pode mover de um nó para nós filhos e voltar para o nó pai.
Existe um exemplo no repósitorio.


### 4.4 Serialize and Deserialize

Ao criar seus aplicativos, você frequentemente trocará dados com outros aplicativos. Ao enviar dados para um serviço da Web ou por meio de um fluxo de rede, você primeiro precisa transformar seus dados em um formato simples ou binário. 
Quando você recebe dados, você precisa transformar os dados planos ou binários nos objetos com os quais deseja trabalhar. Esse processo é chamado de serialização(*Serialize*) e desserialização(*Deserialize*).

#### Serializando e Deserializando dados

Você usa serialização quando precisa trocar dados com outro aplicativo. Essa troca pode ser feita através de uma rede ou quando você armazena dados em um banco de dados ou arquivo.
A serialização serializa apenas os dados que um objeto armazena. Os métodos não são serializados. Quando você desserializa um objeto, você precisa acessar a definição de classe original ou terminará com um objeto que armazena apenas dados.
Quando você deseja otimizar a quantidade de dados que precisa serializar, é possível criar um *data transfer object* (DTO) personalizado que contenha apenas os dados específicos necessários.

##### XmlSerializer


Ao trabalhar com o *XmlSerializer* , é importante marcar seus tipos com o atributo **[Serializable]** , parte da classe *SerializableAttribute* . Isso informa ao .NET Framework que seu tipo deve ser serializável. Ele irá verificar o seu objeto e todos os objetos que ele faz referência para se certificar de que ele pode serializar todo o gráfico.
Se isso não for possível, você receberá uma exceção em tempo de execução.

Serialização XML pode ser feita usando o *XmlSerializer*.

```csharp
[Serializable]
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [XmlIgnore]
    private int Age { get; set; }
    
    [XmlIgnore]
    public string desc {private get; set}
}
```
Atributos de acesso privados não podem ser serializados, nesses caso a tag *[XmlIgnore]* é necessária.
Exemplo no repósitorio.


##### Binary Serialization

O *XmlSerializer* produz texto legível por humanos. Você pode abri-lo no Bloco de Notas, por exemplo, para inspecioná-lo e editá-lo. Mas a legibilidade humana do arquivo também aumenta seu tamanho. Usando um formato binário(*binary format*), você obtém um resultado menor.
Você também pode serializar dados que não são adequados para um formato XML, como uma **imagem**.

Em essência, usando serialização binária parece usando o *XmlSerializer*. Você precisa marcar um item com o *SerializableAttribute* e, em seguida, usar a instância do *serializador binário* para serializar um objeto ou um gráfico de objeto em um *stream*.
É importante implementar verificações de segurança em seu construtor. Dessa forma, você pode ter certeza de que ninguém adulterou os dados serializados.
A serialização binária pode ser feita usando a classe BinaryFormatter.

```csharp
IFormatter formatter = new BinaryFormatter();
using (Stream stream = new FileStream("data.bin", FileMode.Create))
{
    formatter.Serialize(stream, p);
}

using (Stream stream = new FileStream("data.bin", FileMode.Open))
{
    Person dp = (Person)formatter.Deserialize(stream);
}
```
Assim como no Xml, atributos de acesso não são serializados. Caso seja essa a intenção a tag *[NonSerialized]* deve ser utilizada.
Exemplo no repósitorio.


##### Web Service Serialization - DataContract

Quando seus tipos são usados no WCF, eles são serializados para que possam ser enviados para outros aplicativos. O serializador de contrato de dados é usado pelo WCF para serializar seus objetos para XML ou JSON.

O exemplo abaixo mostra como você pode criar um **DataContract** para a classe *Person*.
O campo *isDirty* é ignorado e ambas as propriedades *Id* e *Name* serão serializadas, até mesmo o campo *Idade* que é privado.

```csharp
[DataContract]
classe pública PersonDataContract
{
    [DataMember]
    public int Id {get; set; }

    [DataMember]
    public string Nome {get; set; }

    [DataMember]
    private string Idade {get; set; }
    
    private bool isDirty = false;
}
```

Na próxima sessão usaremos para gerar um arquivo JSON.

##### JSON

JSON é um formato especial que é especificamente útil ao enviar pequenas quantidades de dados entre um servidor da Web e um cliente usando JavaScript e XML assíncrono (AJAX).
Normalmente, seus dados são serializados automaticamente quando você usa um ponto de extremidade WCF AJAX ou ASP.NET WebApi.
No exemplo abaixo será feito uma serializaçãod e desserialização do objeto "Produto" usando a classe *DataContractJsonSerializer*.

```csharp
// Serialize
Stream stream = new FileStream("Product.json", FileMode.Create);
DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
ser.WriteObject(stream, prod); // Note: call WriteObject method instead of Serialize
stream.Close();

// Deserialize
Product prod2 = new Product();
Stream stream2 = new FileStream("Product.json", FileMode.Open);
DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Product));
prod = (Product)ser.ReadObject(stream2); // Note: call ReadObject method instead of Deserialize
```

