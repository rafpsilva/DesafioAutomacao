- Projeto
  
   Realizar a automação de um teste de digitação e salvar o resultado no banco de dados PostgreSql.
  
  Foi desenvolvido uma API que faz integração com a automação e inicia assim que um novo usuário é informado,
  a automação verifica a cada 5 segundos se possui algum caso com status "1"(Aberto) e com valor nulo ou vazio no Robô para que inicie o teste, alterando o status para "2"(EmAndamento) e atribuindo um robô,
  assim que finalizado e o resultado é salvo no banco de dados e o status recebe o valor "3"(Finalizado).
