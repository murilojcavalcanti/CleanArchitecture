Modelo de maturidade de richardson:
Modelo que classifica as pais com base em sua aderencia e conformidade com cada um dos quatro nivel do modelo
que são:
nivel 0 : Pox - plain old XML -
nivel 1: Recursos -  
Nivel 2: Verbos HTTP - 
Nivel 3: HATEOAS - 

Injeção de dependencia
Tecnica usada para tornar uma classe independente de suas dependencias,ou seja,
Ele é usado para implementar a inversão de controle e  assim reduzir o acoplamento entre objetos.


Inverção de controle: Devemos delegar a tarefa de criação de um objeti a uma outra entidade como uma 
outra classe, interface, componente,etc. de forma a termos um baixo acoplamento e minimizar as dependencias entre os objetos.

Tempo de vida:
Quando resgistramos serviços em um container, precisaos definir o tempo de vida que queremos usar para este serviço

Ele controla por quanto tempo o objeto vai existir após ter sido criado pelo conteiner.

É definido usando o método de extensão apropriado no IserviceCollection ao registrar o serviço


1-Transient: Uma instancia do serviço é criada a cada vez que são solicitados. Sção recomendados para servilços leves e sem estado.
2-Scoped: Neste tempo de vida a instancia é criada a cada request. é indicado para uso web.
3-Singleton:São criados uma vez durante a vida útil do aplicativo que usa a mesma instancia para todo o aplicativo.

As interfaces de repositorio são responsaveis por realizar a conexão do dominio com as outras camadas 
CancellarionToken:É um recurso usado para cancelar determinada operação.

IBaseRepository:
	é uma abstração generica para as operações basicas do crud

IUnitOfWork:
	É um conceito relacionado a coordenação das atividades de percistencia e transações.
	
