SELECT * FROM CARGO
SELECT * FROM CLIENTE
SELECT * FROM PLATAFORMA
SELECT * FROM ALBUM
SELECT * FROM GENERO


SELECT nomeCliente, tipoCargo FROM CLIENTE
INNER JOIN CARGO
ON CLIENTE.idCliente = CARGO.idCargo
WHERE tipoCargo LIKE 'administrador'

SELECT nomeAlbum, dataLancamento FROM ALBUM
WHERE dataLancamento < '12.09. 2005'


SELECT nomeCliente, tipoCargo FROM CLIENTE
INNER JOIN CARGO
ON CLIENTE.idCliente = CARGO.idCargo
WHERE senhaCliente = 'def'

SELECT nomeAlbum, artista, nomeGenero, atividade FROM ALBUM
INNER JOIN GENERO
ON ALBUM.idAlbum = GENERO.idGenero
WHERE atividade = 'ativo'
