INSERT INTO GENERO(nomeGenero)
VALUES ('Indie'), ('FOLK'), ('ROCK');
GO

INSERT INTO CARGO(tipoCargo)
VALUES ('comum'), ('administrador');
GO


INSERT INTO CLIENTE(idCargo, nomeCliente, senhaCliente)
VALUES (2,'matheus', 'def'), (1, 'Bruno', 'abc'), (2, 'Marcelo', 'poo');
GO

INSERT INTO ALBUM(idGenero, nomeAlbum, localizacao, tempo, atividade, artista)
VALUES (2, 'album1',  'sao paulo',  '53min', 'Ativo', 'aaa'), (3, 'album2',  'Nova York',  '40min', 'Ativo', 'bbb'), (1, 'album3', 'Rio de Janeiro',  '1h3min', 'Desativado', 'xxx');
GO

INSERT INTO ALBUM(dataLancamento)
VALUES ('11/09'), ('12/09'), ('13/09');
GO

UPDATE ALBUM
SET dataLancamento = '13.01.2001'
WHERE idAlbum = 3



INSERT INTO PLATAFORMA(idAlbum, idCliente, nomePlataforma)
VALUES (1, 1, 'www'),  (2, 2, 'www'), (3, 3, 'zzz');
GO
