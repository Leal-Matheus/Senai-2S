USE Inlock_Games_Tarde
GO

--Lista todos usuarios
SELECT * FROM Usuario

--Lista todos Estudios
SELECT * FROM Estudio

--Lista todos jogos
SELECT * FROM Jogo


--Lista todos jogos e seus estudios
SELECT Nome, Descricao, Valor, DataLancamento, NomeEstudio FROM Jogo
INNER JOIN Estudio
ON Jogo.idEstudio = Estudio.idEstudio


--Lista todos jogos e todos estudios, mesmo que não tenham jogos
SELECT NomeEstudio, Nome Jogo, Descricao, Valor, DataLancamento FROM Jogo
RIGHT JOIN Estudio
ON Jogo.idEstudio = Estudio.idEstudio


--Lista um usuario atraves de um email e senha
SELECT * FROM USUARIO
WHERE Email ='admin@admin.com' and Senha ='admin'

--Lista um jogo atraves do ID
SELECT idJogo, Nome, Descricao, Valor, DataLancamento, NomeEstudio FROM Jogo
INNER JOIN Estudio ON Estudio.idEstudio = Jogo.idEstudio
WHERE idJogo = 2

--Lista um estudio atraves do ID
SELECT * FROM Estudio 
WHERE idEstudio = 2
