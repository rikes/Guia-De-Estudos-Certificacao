Markdown Guide:
https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet

# **Exam 70-483**




## **3 Depurar aplicativos e implementar segurança**

### **3.5 Implementar log de rastreamento**
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




### **3.5 Criação de perfil de aplicativos**


### **3.5 Criar e monitorar contadores de desempenho**



### **3.5 Escrever para o log de eventos**







