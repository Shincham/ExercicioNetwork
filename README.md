# ExercicioNetwork
Teste de Lógica, exercício sobre verificar conexões em uma Network. Linguagem usada: C#

O código do programa está no arquivo Program.CS. Este é o arquvio que deve ser aberto para ver o código. O restante dos arquivos são arquivos gerados automaticamente pelo projeto do Visual Studio.

Este programa é para resolver esta questão.

O problema:

Temos uma lista de elementos. Exemplo: 1, 2, 3, 4, 5, 6, 7, 8

É possível fazer uma conexão entre 2 eleementos. Por exemplo, pode-se conectar 1 e 6.

É possível fazer qualquer número de conexões e quaisquer 2 elementos podem ser conectados. Vamos fazer as seguintes conexões:
1-2, 6-2, 2-4 e 5-8. Lembrando que 1-6 também estão conectados, no passo acima.

Agora o programa precisa determinar se dois elementos estão conectados, seja diretamente ou através de uma série de conexões. 1 e 6 estão conectados, assim como 6 e 4. No entanto, 7 e 4 não estão conectados, e nem 5 e 6. O caminho de conexão é irrelevante, 1 e 2 estão conectados tanto diretamente quanto indiretamente (através do 6), mas para este problema o fato de que existe 2 caminhos é irrelevante.

A Tarefa:
Escrever uma classe chamada NETWORK. O construtor deve receber um valor inteiro positivo indicando o numero de elementos de uma lista. Passar um valor inválido deve gerar uma exceção. A classe também precisa prover 2 métodos publicos chamados CONNECT and QUERY. O primeiro método, CONNECT, receberá 2 inteiros indicando os elementos a serem conectados. Esse método deve tratar exceções de forma apropriada. O segundo método, QUERY, também receberá 2 inteiros e também deve tratar exceções de forma apropriada. Ele deve retornar TRUE se os elementos estiverem conectados, diretamente ou indiretamente, e falso se os elementos não estiverem conectados. A classe pode ter qualquer número de elementos privados ou protegidos para uma boa implementação.
