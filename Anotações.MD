Modelo de maturidade de richardson:
Modelo que classifica as pais com base em sua aderencia e conformidade com cada um dos quatro nivel do modelo
que são:
nivel 0 : Pox - plain old XML -
nivel 1: Recursos -  
Nivel 2: Verbos HTTP - 
Nivel 3: HATEOAS - 

- Injeção de dependencia
	Tecnica usada para tornar uma classe independente de suas dependencias,ou seja,
	Ele é usado para implementar a inversão de controle e  assim reduzir o acoplamento entre objetos.


- Inverção de controle: 
	Devemos delegar a tarefa de criação de um objeti a uma outra entidade como uma outra classe, interface, 
	componente,etc. de forma a termos um baixo acoplamento e minimizar as dependencias entre os objetos.

- Tempo de vida:
	Quando resgistramos serviços em um container, precisaos definir o tempo de vida que queremos usar para este serviço

	Ele controla por quanto tempo o objeto vai existir após ter sido criado pelo conteiner.

	É definido usando o método de extensão apropriado no IserviceCollection ao registrar o serviço
				
	1-Transient: Uma instancia do serviço é criada a cada vez que são solicitados. Sção recomendados para servilços leves e sem estado.
	2-Scoped: Neste tempo de vida a instancia é criada a cada request. é indicado para uso web.
	3-Singleton:São criados uma vez durante a vida útil do aplicativo que usa a mesma instancia para todo o aplicativo.


- As interfaces de repositorio são responsaveis por realizar a conexão do dominio com as outras camadas 

- CancellarionToken:É um recurso usado para cancelar determinada operação.

- IBaseRepository:
	é uma abstração generica para as operações basicas do crud

= IUnitOfWork:
	É um conceito relacionado a coordenação das atividades de percistencia e transações.
	
- Padrão Repositorio + Unit Of Work
	É um padrão que tem como objetivo gerenciar todas as transações dos repositorios entando a ocorencia de atualizações 
	parciais ou erros, assim garantindo a concistencia de dados.

- A classe application atua como uma ponte entre a camada de dominio e as interfaces externas da aplicação

- Services: Configurar diversos serviços e comportamentos relacionados à aplicação.

- Behavior: Comportamento personalizado do Mediator, um padrão que permite a execução de lógica antes ou depois 
		  do processo da solicitação por um manipulador.

- Exceptions:Exceções personalizadas.

- useCases: Padrão CQRS para criar os casos de uso realcionados com as operações CRUD

Pacotes usados na camada Application
1-Mediator:
	- É uma lib usada para auxiliar a implementação do padrão mediator em aplicações. Este padrão 
	  fornece um local centralizado para gerenciar a cominicação entre diferentes componentes em um aplicativo.
2-AutoMapper:
	- É uma lib que fornece uma maneira simples de mapear objetos de diferentes tipos. É usada em aplicativos 
	  que precisam converter dados de um formato para outro, como objetos de dominio para objtos de transferencia de dados(DTOs)
3-FluentValidation:
	-É uma lib usada para validar objetos e garantir que eles estejam em conformidade com um conjunto de regras especificadas.

- Padrão CQRS - Command Query Responsability Segregation
	Esse padrão separa as operações de leitura das operações de escrita em um sistema e, isso significa que as ações que alteram o 
	estado do sistema são tratadas separadamente das ações que apenas consultam o estado do sistema.
	
	Essa separação de responsabilidades permite otimizar cada caminho de forma independente para atender às necessidades 
	específicas podendo maximizar o desenpenho, a escalabilidade e a segurança.

	- Pontos de Ação do CQRS											
		1- Separa as reponsabilidades: 
			- Separa leituras e gravações em modelos diferentes, usando comando para atualizar dados e consultas para ler dados

		2- Usa Modelo de dominios distintos
			Com o CQRS, voc^pode criar modelos de domínio diferentes para operações de leitura e operações de escrita.

		3- Favorece a escalabilidade
			As operações de leitura e escrita pode ser dimensionadas independentemente umas das outras.
	
		4- Controle de acesso e segurança
			Permite um controle mais granular sobre a segurança e o acesso aos dados.

		5- Favorece a flexibilidade
			Você pode escolher as tecnologias e estratégias mais adequadas para manipular comandos e consultas.

Padrão Mediator
Lida com o desacoplamento, colocando uma camada intermediária entre os componentes, chamada de Mediator, que 
será sua única fonte de dependências.
Como funciona

				  Query		
		 		  ------>	|-----------| -> QueryHandler    |
API -> Controller			| Mediator  |					 | -> DataStore	
				  ------>	|-----------| -> CommandHandler	 |
				  Command		


- Command
	- É uma classe simples que representa uma solicitação para modificar o estado do sistema e contém informações 
	sobre a ação a ser executada, como os parâmetros necessários para realizar a operação.

	- Não deve conter lógica de negocios, seu papel é transportar dados, ouseja funciona como um DTO.

- CommandHandler
	- É uma classe que processa um comandoe contem a lógica de negócios associada à execução do comando.
	Ela é responsável por receber o comando, validas seus dados, executar a ação apropriada no dominio 
	e, opcionalmente, atualizar o estado do sistema.


- Query 
	- Representa uma solicitação de leitura de dados do sistema, sem modificar seu estado.
	
	- É uma classe que contem os parâmetros e informações necessarias para a consulta e não 
	contem logica de negócios, Seu objetivo é transportar dados de entrada para a consulta.
	
	- Implementa a classe IRequest<IEnumerable<Customer> >

- QueryHandler
	- É usada para processar uma consulta especifica e contém a lógica para buscar dados no sistemas com 
	  base na consulta. Ela recebe a query como entrada, executa a consulta no banco de dados ou outras 
	  fontes de dados, transforma os dados e um modelo de visualização e retorna o resultado.

- IRequest(MediatR)
	É uma interface que representa uma solicitação(Como comando de cosnulta).

	Esta interface é implementada pelas classes de comando (Command) para representar a solicitação 
	de execução de um comando e pelas classes de consultas (Queries) para representar a solicitação 
	de uma consulta.

- IRequesthandler(MediatR)
	É uma interface genérica que define a assinatura do metodo handle para processar uma solicitalçao (Irequest)
	e retornar um resultado.

	Implementada pela classe CommandHandler para procesar um comando especifico e contpem a logica de negocios associada 
	á execução do comando e recebe a instancia do comando como entrada e executa a ação correspondente no sistema.

	Ela também é implementada pela classe QueryHandler por processar uma query específica e retornar os dados solicitados 
	e contém a lógica para executar a consulta no sistema.

