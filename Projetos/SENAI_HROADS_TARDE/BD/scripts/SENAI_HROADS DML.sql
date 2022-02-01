USE SENAI_HROADS_TARDE;
	GO

	INSERT INTO TipoHabilidade(nometipo)
	VALUES ('Ataque'), ('Defesa' ), ('Cura'), ('Magia' );
	GO

	INSERT INTO Classe(nomeClasse)
	VALUES ('Barbaro'), ('Monge'), ('Arcanista'), ('Feiticeiro'), ('Necromante'), ('Caçadora de demonios'), ('Cruzado');
	GO

	INSERT INTO Personagem(idClasse, nomePersonagem, vidaMax, manaMax, dataAtualizacao, dataCriacao)
	VALUES (1,'DeuBug', '100', '80', '10/08/2021', '18/01/2019'), (2,'BitBug', '70', '100', '10/08/2021', '17/03/2016'), (3,'Fer8', '75', '60', '10/08/2021', '18/03/2018');
	GO

	INSERT INTO Habilidade (habilidade, idTipo)
	VALUES ('Lança Mortal', 1), ('Escudo Supremo', 2), ('Recuperar Vida', 3);
	GO


	INSERT INTO QuadroHabilidade(idHabilidade, idClasse)
	VALUES (1, 1), (2, 1), (2, 2), (3, 2), (null, 3), (3, 4), (null, 5), (1, 6), (2, 7);
	GO

	UPDATE Personagem
	SET nomePersonagem = 'Fer7'
	where idPersonagem = 3
	go

	UPDATE Classe
	SET nomeClasse = 'Necromancer'
	WHERE idClasse = 5
	go

	INSERT INTO TipoUsuario(Tipo) VALUES ('Administrador'),('Jogador')


	INSERT INTO Usuario(nome, Email, Senha)
	VALUES ('Admin', 'admin@admin.com', '123'), ('Jogador', 'jogador@jogador.com', '123');
	GO

	UPDATE Usuario 
	SET idTipoUsuario = 2
	WHERE idUsuario = 2