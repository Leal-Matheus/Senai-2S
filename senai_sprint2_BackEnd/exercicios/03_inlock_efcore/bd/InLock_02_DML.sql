-- Define qual banco de dados ser� utilizado
USE inLockGames_tarde;
GO

-- Insere os tipos de usu�rio
INSERT INTO tipoUsuario(titulo)
VALUES					('Administrador')
					   ,('Cliente');
GO

-- Insere os usu�rios
INSERT INTO usuario(email, senha, idTipoUsuario)
VALUES				('admin@admin.com','admin',1)
				   ,('cliente@cliente.com','cliente',2);
GO

-- Insere os est�dios
INSERT INTO estudio(nomeEstudio)
VALUES				('Blizzard')
				   ,('Rockstar Studios')
				   ,('Square Enix');
GO

-- Insere os jogos
INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','2012-05-15','99.00',1)
				,('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','2018-10-26','120.00',2);
GO