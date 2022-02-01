CREATE DATABASE ALUGUEIS;
GO 

USE ALUGUEIS;
GO

INSERT INTO CLIENTE(nomeCliente)
VALUES ('Matheus'), ('Bruno'), ('Marcelo');
GO

INSERT INTO EMPRESA(nomeEmpresa)
VALUES ('unidas'), ('hertz'), ('localiza');
GO

INSERT INTO MARCA(nomeMarca)
VALUES ('hyundai'), ('honda'), ('toyota');
GO

INSERT INTO MODELO(nomeModelo, idMarca)
VALUES ('IX35', 1), ('Civic', 2), ('Prius', 3);
GO

INSERT INTO VEICULO(idModelo, placa)
VALUES (3, 'AAA'), (1, 'BBB'), (3, 'CCC');
GO

INSERT INTO ALUGUEL(idVeiculo, idCliente, dataRetirada, dataDevolucao)
VALUES('3','2','11/09','12/09'), ('1','3','13/09','14/09'), ('2','1','15/09','16/09')
GO



UPDATE VEICULO
SET idModelo = 2
WHERE idVeiculo = 3
go



