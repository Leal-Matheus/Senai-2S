USE T_Rental
GO

SELECT * FROM ALUGUEL;
GO

SELECT nomeCliente, nomeModelo, dataRetirada, dataDevolucao FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN MODELO
ON ALUGUEL.idVeiculo = MODELO.idModelo
GO

SELECT * FROM CLIENTE;
GO
