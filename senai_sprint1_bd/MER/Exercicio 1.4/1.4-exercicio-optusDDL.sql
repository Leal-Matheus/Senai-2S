CREATE DATABASE PLATAFORMA;
GO

USE PLATAFORMA;
GO

CREATE TABLE GENERO(
	idGenero TINYINT PRIMARY KEY IDENTITY(1,1),
		nomeGenero VARCHAR(20)
);
GO

CREATE TABLE CARGO(
	idCargo TINYINT PRIMARY KEY IDENTITY(1,1),
		tipoCargo VARCHAR(13)
);
GO

CREATE TABLE CLIENTE(
	idCliente INT PRIMARY KEY IDENTITY(1,1),
	idCargo TINYINT FOREIGN KEY REFERENCES CARGO(idCargo),
		nomeCliente VARCHAR(20),
		senhaCliente VARCHAR (20)
);
GO

CREATE TABLE ALBUM(
	idAlbum INT PRIMARY KEY IDENTITY(1,1),
	idGenero TINYINT FOREIGN KEY REFERENCES GENERO(idGenero),
		nomeAlbum VARCHAR(20),
		localizacao VARCHAR(20),
		dataLancamento VARCHAR(20),
		Tempo VARCHAR(20),
		atividade VARCHAR(20),
		artista VARCHAR(20),
);
GO

CREATE TABLE PLATAFORMA(
	idPlataforma TINYINT PRIMARY KEY IDENTITY(1,1),
	idAlbum INT FOREIGN KEY REFERENCES ALBUM(idAlbum),
	idCliente INT FOREIGN KEY REFERENCES CLIENTE(idCliente),
		nomePlataforma VARCHAR(20)
);
GO
