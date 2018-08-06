## Criptografia
No âmbito da criptografia (do grego esconder+escrever), a encriptação é o processo de transformação de uma informação original, numa informação ilegível, para terceiros. 
Este mecanismo tem como objectivo o envio de informação confidencial de forma segura, sendo apenas possível a sua descodificação por pessoas  autorizadas (que possuam a chave de “desencriptação”).

O algoritmo trabalha junto com a chave, de forma que eles tornam um conteúdo sigiloso com um conjunto único de regras.


### Simétrica

A criptografia simétrica faz uso de uma única chave, que é compartilhada entre o emissor e o destinatário de um conteúdo. 
Essa chave é uma cadeia própria de bits, que vai definir a forma como o algoritmo vai cifrar um conteúdo.

Como vantagem, a criptografia tem uma boa performance e a possibilidade de manter uma comunicação contínua entre várias pessoas simultaneamente. 
Caso a chave seja comprometida, basta efetuar a troca por uma nova, mantendo o algoritmo inicial.

A segurança de um sistema de criptografia vai variar conforme o tamanho da chave utilizada. 
Um algoritmo baseado no data encryption standart (DES ou padrão de criptografia de dados, em tradução livre) tem 56 bits, o que permite a criação de 72 quadrilhões de chaves diferentes. 
Pode parecer muito, mas esse padrão já é considerado inseguro diante da capacidade de processamento dos dispositivos atuais.


A plataforma .NET contém o algoritmo Rijndael, que você deve usar para todos os novos projetos que exigem a criptografia simétrica. Assim você pode usar a classe RijndaelManaged para realizar a criptografia e descriptografia simétrica.

Esta classe exige que você forneça uma chave e um vetor de inicialização (VI). O VI ajuda a garantir que ao criptografar a mesma mensagem várias vezes produz-se textos cifrados diferentes. O mensagem criptografada é comumente conhecido como texto cifrado.

Para descriptografar os dados, você deve usar a mesma chave e o VI usado para criptografar os dados. A chave deve ser composta de bytes de dados que compõem o comprimento total da chave.

Por exemplo, uma chave de 128 bit é composta por 16 bytes. Se a chave é gerada pela aplicação, utilizar bytes para a chave não é um problema, no entanto, se um ser humano está gerando a chave, é comum querer que a chave seja uma palavra ou frase.
Isso pode ser feito usando a classe Rfc2898DeriveBytes, que pode derivar uma chave de uma senha fornecida.


Apesar do seu alto desempenho, a criptografia simétrica possui falhas graves de segurança. 
A gestão de chaves, por exemplo, torna-se mais complexa conforme o número de pessoas que se comunica aumenta. Para cada N usuários, são necessárias N2 chaves.

Ex de algoritimos.: DES, 3DES,AES(também conhecido como Rijndael) e RC4

O C# disponibiliza em sua biblioteca **"System.Security"** a classe **TripleDESCryptoServiceProvider**, referente ao algoritimo 3DES.

``` C#
TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();  
```





### Assimétrica
A criptografia assimétrica, também conhecida como criptografia de chave pública, é baseada em 2 tipos de chaves de segurança — uma privada e a outra pública. 
Elas são usadas para cifrar mensagens e verificar a identidade de um usuário.

Resumidamente falando, a chave privada é usada para decifrar mensagens, enquanto a pública é utilizada para cifrar um conteúdo.
Assim, qualquer pessoa que precisar enviar um conteúdo para alguém precisa apenas da chave pública do seu destinatário, que usa a chave privada para decifrar a mensagem.
As chaves privadas assimétricas nunca devem ser armazenadas no formato textual nem como texto sem formatação no computador local.


Com a criptografia assimétrica, somente uma parte mantém a chave privada. Essa parte é conhecida como o assunto. Todas as outras partes podem acessar a chave pública. Os dados criptografadas por meio da chave pública só podem ser descriptografados com o uso da chave privada. 
Por outro lado, os dados criptografados por meio da chave privada só podem ser descriptografados com o uso da chave pública. Por conseguinte, esse tipo de criptografia fornece confidencialidade e não-repúdio.



Ex de algoritimos.: RSA e DSA

A **"System.Security"** disponibiliza classes para a criptografia assimétrica, tais como: **RSACryptoServiceProvider** e **DSACryptoServiceProvider**.
Essas classes de criar um par de chaves pública/privada quando você usa o construtor padrão para criar uma nova instância. 
Chaves assimétricas podem ser armazenadas para uso em várias sessões ou geradas para apenas uma sessão. 
Enquanto a chave pública pode ser disponibilizada, a chave privada deve ser bastante protegida.


### Considerações

Criptografias simétrica e assimétrica são executadas usando processos diferentes. 
A criptografia simétrica é executada em fluxos e, portanto, é útil para criptografar grandes quantidades de dados. 
A criptografia assimétrica é executada em um pequeno número de bytes e, portanto, só é útil para pequenas quantidades de dados.


--      


**Resumindo:** *Simétrica* mesma chave para encriptar e desencriptar, e **assimétrica** são chaves diferentes para encriptar e desencriptar 


*Referências*
------

@cryptoid
@pplware