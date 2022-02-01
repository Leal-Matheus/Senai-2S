-- Define qual banco de dados ser� utilizado
USE inLockGames_tarde;
GO

-- Listar todos os usu�rios
SELECT U.idUsuario, U.email, U.idTipoUsuario, TU.titulo FROM usuario U
INNER JOIN tipoUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario;
GO

-- Listar todos os est�dios
SELECT idEstudio, nomeEstudio FROM estudio; 

-- Listar todos os jogos
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogo;

-- Listar todos os jogos e seus respectivos est�dios
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio;
GO

-- Buscar e trazer na lista todos os est�dios com os respectivos jogos, mesmo que um est�dio n�o tenha jogo
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM estudio E
LEFT JOIN jogo J
ON E.idEstudio = J.idEstudio;
GO

-- Buscar um usu�rio por e-mail e senha
SELECT idUsuario, email, U.idTipoUsuario, TU.titulo FROM usuario U
INNER JOIN tipoUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'admin@admin.com' AND senha = 'admin';
GO

-- Buscar um jogo e seu respectivo est�dio por IdJogo
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio
WHERE J.idJogo = 1;
GO

-- Buscar um est�dio com seus respectivos jogos pelo IdEstudio
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM estudio E
INNER JOIN jogo J
ON E.idEstudio = J.idEstudio
WHERE E.idEstudio = 1;
GO

-- Lista os jogos de um determinado est�dio
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogo J
INNER JOIN estudio E
ON J.idEstudio = E.idEstudio
WHERE E.idEstudio = 1;
GO