USE SENAI_HROADS_TARDE
GO

---6-------
SELECT * FROM Personagem
GO
---7-------
SELECT * FROM Classe
GO

---8-------
SELECT nomeClasse FROM Classe
GO

---9-------
SELECT * FROM Habilidade
GO

---10------
SELECT COUNT(idHabilidade) FROM Habilidade
GO

---11-------
SELECT idHabilidade FROM Habilidade
ORDER BY idHabilidade ASC
GO

---12-------
SELECT * FROM TipoHabilidade
GO

---13-------
SELECT habilidade, nomeTipo FROM Habilidade
INNER JOIN TipoHabilidade
ON	habilidade.idHabilidade = TipoHabilidade.idTipo
GO  

---14-------
SELECT nomePersonagem, nomeClasse FROM Personagem
INNER JOIN Classe
ON Personagem.idPersonagem = Classe.idClasse
GO 

---15-------
SELECT nomePersonagem, nomeClasse FROM Personagem
RIGHT JOIN Classe
ON Personagem.idPersonagem = Classe.idClasse
GO 

---16-------
SELECT nomeCLasse, habilidade FROM QuadroHabilidade
left JOIN Habilidade
ON QuadroHabilidade.idHabilidade = Habilidade.idHabilidade
left JOIN Classe
ON QuadroHabilidade.idClasse = Classe.idClasse
GO

---17-------
SELECT habilidade, nomeCLasse FROM QuadroHabilidade
INNER JOIN Habilidade
ON QuadroHabilidade.idHabilidade = Habilidade.idHabilidade
INNER JOIN Classe
ON QuadroHabilidade.idClasse = Classe.idClasse
GO

---18-------
SELECT habilidade, nomeCLasse FROM QuadroHabilidade
full outer JOIN Habilidade
ON QuadroHabilidade.idHabilidade = Habilidade.idHabilidade
full outer  JOIN Classe
ON QuadroHabilidade.idClasse = Classe.idClasse
GO


SELECT * FROM Usuario