USE Inlock_Games_Tarde

INSERT INTO TipoUsuario(titulo) VALUES ('Comum'),('Administrador')
GO

INSERT INTO Usuario(Email, Senha, idTipoUsuario) VALUES ('admin@admin.com','admin',2),('cliente@cliente.com','cliente',1)
GO

INSERT INTO Estudio(NomeEstudio) VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix')
GO

INSERT INTO Jogo(Nome, Descricao, Valor, DataLancamento, idEstudio) VALUES ('Diablo 3','� um jogo que cont�m bastante ac�o e � viciante, seja voc� um novato ou um f�',99.00,'15/05/2012',1),('Red Dead Redemption II','Jogo eletr�nico de A��o-Aventura Western',120.00,'26/10/2018',2)
GO