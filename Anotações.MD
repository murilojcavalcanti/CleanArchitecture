Modelo de maturidade de richardson:
Modelo que classifica as pais com base em sua aderencia e conformidade com cada um dos quatro nivel do modelo
que s�o:
nivel 0 : Pox - plain old XML -
nivel 1: Recursos -  
Nivel 2: Verbos HTTP - 
Nivel 3: HATEOAS - 

- Inje��o de dependencia
	Tecnica usada para tornar uma classe independente de suas dependencias,ou seja,
	Ele � usado para implementar a invers�o de controle e  assim reduzir o acoplamento entre objetos.


- Inver��o de controle: 
	Devemos delegar a tarefa de cria��o de um objeti a uma outra entidade como uma outra classe, interface, 
	componente,etc. de forma a termos um baixo acoplamento e minimizar as dependencias entre os objetos.

- Tempo de vida:
	Quando resgistramos servi�os em um container, precisaos definir o tempo de vida que queremos usar para este servi�o

	Ele controla por quanto tempo o objeto vai existir ap�s ter sido criado pelo conteiner.

	� definido usando o m�todo de extens�o apropriado no IserviceCollection ao registrar o servi�o
				
	1-Transient: Uma instancia do servi�o � criada a cada vez que s�o solicitados. S��o recomendados para servil�os leves e sem estado.
	2-Scoped: Neste tempo de vida a instancia � criada a cada request. � indicado para uso web.
	3-Singleton:S�o criados uma vez durante a vida �til do aplicativo que usa a mesma instancia para todo o aplicativo.


- As interfaces de repositorio s�o responsaveis por realizar a conex�o do dominio com as outras camadas 

- CancellarionToken:� um recurso usado para cancelar determinada opera��o.

- IBaseRepository:
	� uma abstra��o generica para as opera��es basicas do crud

= IUnitOfWork:
	� um conceito relacionado a coordena��o das atividades de percistencia e transa��es.
	
- Padr�o Repositorio + Unit Of Work
	� um padr�o que tem como objetivo gerenciar todas as transa��es dos repositorios entando a ocorencia de atualiza��es 
	parciais ou erros, assim garantindo a concistencia de dados.

- A classe application atua como uma ponte entre a camada de dominio e as interfaces externas da aplica��o

- Services: Configurar diversos servi�os e comportamentos relacionados � aplica��o.

- Behavior: Comportamento personalizado do Mediator, um padr�o que permite a execu��o de l�gica antes ou depois 
		  do processo da solicita��o por um manipulador.

- Exceptions:Exce��es personalizadas.

- useCases: Padr�o CQRS para criar os casos de uso realcionados com as opera��es CRUD

Pacotes usados na camada Application
1-Mediator:
	- � uma lib usada para auxiliar a implementa��o do padr�o mediator em aplica��es. Este padr�o 
	  fornece um local centralizado para gerenciar a cominica��o entre diferentes componentes em um aplicativo.
2-AutoMapper:
	- � uma lib que fornece uma maneira simples de mapear objetos de diferentes tipos. � usada em aplicativos 
	  que precisam converter dados de um formato para outro, como objetos de dominio para objtos de transferencia de dados(DTOs)
3-FluentValidation:
	-� uma lib usada para validar objetos e garantir que eles estejam em conformidade com um conjunto de regras especificadas.

- Padr�o CQRS - Command Query Responsability Segregation
	Esse padr�o separa as opera��es de leitura das opera��es de escrita em um sistema e, isso significa que as a��es que alteram o 
	estado do sistema s�o tratadas separadamente das a��es que apenas consultam o estado do sistema.
	
	Essa separa��o de responsabilidades permite otimizar cada caminho de forma independente para atender �s necessidades 
	espec�ficas podendo maximizar o desenpenho, a escalabilidade e a seguran�a.

	- Pontos de A��o do CQRS											
		1- Separa as reponsabilidades: 
			- Separa leituras e grava��es em modelos diferentes, usando comando para atualizar dados e consultas para ler dados

		2- Usa Modelo de dominios distintos
			Com o CQRS, voc^pode criar modelos de dom�nio diferentes para opera��es de leitura e opera��es de escrita.

		3- Favorece a escalabilidade
			As opera��es de leitura e escrita pode ser dimensionadas independentemente umas das outras.
	
		4- Controle de acesso e seguran�a
			Permite um controle mais granular sobre a seguran�a e o acesso aos dados.

		5- Favorece a flexibilidade
			Voc� pode escolher as tecnologias e estrat�gias mais adequadas para manipular comandos e consultas.

Padr�o Mediator
Lida com o desacoplamento, colocando uma camada intermedi�ria entre os componentes, chamada de Mediator, que 
ser� sua �nica fonte de depend�ncias.
Como funciona

				  Query		
		 		  ------>	|-----------| -> QueryHandler    |
API -> Controller			| Mediator  |					 | -> DataStore	
				  ------>	|-----------| -> CommandHandler	 |
				  Command		


- Command
	- � uma classe simples que representa uma solicita��o para modificar o estado do sistema e cont�m informa��es 
	sobre a a��o a ser executada, como os par�metros necess�rios para realizar a opera��o.

	- N�o deve conter l�gica de negocios, seu papel � transportar dados, ouseja funciona como um DTO.

- CommandHandler
	- � uma classe que processa um comandoe contem a l�gica de neg�cios associada � execu��o do comando.
	Ela � respons�vel por receber o comando, validas seus dados, executar a a��o apropriada no dominio 
	e, opcionalmente, atualizar o estado do sistema.


- Query 
	- Representa uma solicita��o de leitura de dados do sistema, sem modificar seu estado.
	
	- � uma classe que contem os par�metros e informa��es necessarias para a consulta e n�o 
	contem logica de neg�cios, Seu objetivo � transportar dados de entrada para a consulta.
	
	- Implementa a classe IRequest<IEnumerable<Customer> >

- QueryHandler
	- � usada para processar uma consulta especifica e cont�m a l�gica para buscar dados no sistemas com 
	  base na consulta. Ela recebe a query como entrada, executa a consulta no banco de dados ou outras 
	  fontes de dados, transforma os dados e um modelo de visualiza��o e retorna o resultado.

- IRequest(MediatR)
	� uma interface que representa uma solicita��o(Como comando de cosnulta).

	Esta interface � implementada pelas classes de comando (Command) para representar a solicita��o 
	de execu��o de um comando e pelas classes de consultas (Queries) para representar a solicita��o 
	de uma consulta.

- IRequesthandler(MediatR)
	� uma interface gen�rica que define a assinatura do metodo handle para processar uma solicital�ao (Irequest)
	e retornar um resultado.

	Implementada pela classe CommandHandler para procesar um comando especifico e contpem a logica de negocios associada 
	� execu��o do comando e recebe a instancia do comando como entrada e executa a a��o correspondente no sistema.

	Ela tamb�m � implementada pela classe QueryHandler por processar uma query espec�fica e retornar os dados solicitados 
	e cont�m a l�gica para executar a consulta no sistema.

	Valida��o Behavior: 
- O comportamento(Behavior) do mediatR � uma caracteristica que permite adicionar l�gica comum a todos ou a alguns manipuladores(handles) 
 de requests na implementa��o do ccqrs com mediatr.

 Ele � usado para encapsular funcionalidades que devem ser executadas antes ou depois do processamento de um request.

 Pipeline Behavior
	- � usado pra adicionar logica de processamento antes e depois de um manipulador de solicita��o e permite adicionar 
	comportamentos globais a todas as solicita��es ou a um subconjunto especifico delas.

Notification Handler
	- N�o retornam valores e s�o usadas para comunicar eventos no sistema. Os notification handlers s�o sado para reagir
	  a essas notifica��es e executar a��es especificas quando eventos ocorrem.




Obs:
Pesquisar sobre records
