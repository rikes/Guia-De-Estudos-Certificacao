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

```CSHARP
enum Days: byte {Sat = 1, dom, seg, ter, qua, qui, sex};
```
Por *Default* os enumerados iniciando em 0 e vão se incrementando, mas podemos indicar com qual número ele vai iniciar.
Caso seja necessário uma comparação, poderemos fazer da seguinte maneira:

```CSHARP
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

``` CSHARP
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

``` CSHARP
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
``` CSHARP
int a = (int) 12,37 
//a == 12
```

https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/explicit

- Implícita
Uma conversão implícita não precisa de nenhuma sintaxe especial. Pode ser executado porque o compilador sabe que a conversão é permitida e que é seguro converter.

``` CSHARP
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

``` CSHARP
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













# Parte 3 Debug and security


## 3 Depurar aplicativos e implementar segurança

### 3.5 Implementar log de rastreamento
Aplicativos do .NET framework são depurados facilmente usando o Visual Studio, que lida com muitos dos detalhes de configuração. Se o Visual Studio não estiver instalado, você poderá examinar e melhorar o desempenho de aplicativos do .NET Framework por meio das classes de depuração do namespace System.Diagnostics do .NET Framework. Este namespace inclui as classes Trace, Debug e TraceSource para rastreamento de fluxo de execução e as classes Process, EventLog e PerformanceCounter para criação de perfil de código.

A classe  *TraceSource* fornece recursos de rastreamento avançados e pode ser usada no lugar dos métodos estáticos das classes de rastreamento antigas *Trace* e *Debug*. As classes *Trace* e *Debug* conhecidas ainda são amplamente usadas, mas a classe *TraceSource* é recomendada para novos comandos de rastreamento, como *TraceEvent* e *TraceData*.

As classes Trace e Debug fornecem os meios para monitorar e examinar o desempenho do aplicativo durante o desenvolvimento ou após a implantação. Por exemplo, é possível usar a classe Trace para acompanhar determinados tipos de ações em um aplicativo implantado, conforme eles ocorrem (por exemplo, criação de novas conexões de banco de dados) e, portanto, é possível monitorar a eficiência do aplicativo.

--- 
Durante o desenvolvimento, use os métodos de saída da classe Debug para exibir mensagens na janela de Saída do IDE:

``` CSHARP
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


``` CSHARP
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