USE Inlock_Games_Tarde

INSERT INTO TipoUsuario(titulo) VALUES ('Comum'),('Administrador')
GO

INSERT INTO Usuario(Email, Senha, idTipoUsuario) VALUES ('admin@admin.com','admin',2),('cliente@cliente.com','cliente',1)
GO

INSERT INTO Estudio(NomeEstudio) VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix')
GO

INSERT INTO Jogo(Nome, Descricao, Valor, DataLancamento, idEstudio) VALUES ('Diablo 3','é um jogo que contém bastante acão e é viciante, seja você um novato ou um fã',99.00,'15/05/2012',1),('Red Dead Redemption II','Jogo eletrônico de Ação-Aventura Western',120.00,'26/10/2018',2)
GO