
USE T_Rental;
GO

INSERT INTO CLIENTE(nomeCliente, sobrenomeCliente,  CNH)
VALUES ('Matheus', 'Leal', '123'), ('Bruno', 'Paulo', '456'), ('Marcelo', 'Palmuti', '789');
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

INSERT INTO VEICULO(idModelo, idEmpresa, placa)
VALUES (3, '1', 'AAA'), (1, '2', 'BBB'), (3, '3', 'CCC');
GO

	INSERT INTO ALUGUEL(idVeiculo, idCliente, dataRetirada, dataDevolucao)
	VALUES('3','2','11/09','12/09'), ('1','3','13/09','14/09'), ('2','1','15/09','16/09')
	GO
