USE SENAI_HROADS;

SELECT * FROM Personagens;

SELECT * FROM Classes;

SELECT Classes.Nome FROM Classes;

SELECT * FROM Habilidades;

SELECT COUNT(idHabilidade) AS Habilidades_Cadastradas FROM Habilidades

SELECT idHabilidade FROM Habilidades
ORDER BY idHabilidade ASC

SELECT * FROM TipoHabilidade

SELECT Habilidades.Habilidade, TipoHabilidade.Tipo FROM Habilidades
LEFT JOIN TipoHabilidade
ON Habilidades.idTipo = TipoHabilidade.idTipo

SELECT Personagens.Nome, Classes.Nome FROM Personagens
INNER JOIN Classes
ON Personagens.idClasse = Classes.idClasse

SELECT Personagens.Nome, Classes.Nome FROM Personagens
RIGHT JOIN Classes
ON Personagens.idClasse = Classes.idClasse

SELECT Classes.Nome AS Classe, Habilidades.Habilidade FROM ClassHab
RIGHT JOIN Classes
ON ClassHab.idClasse = Classes.idClasse
LEFT JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade

SELECT Habilidades.Habilidade,  Classes.Nome AS Classe FROM ClassHab
INNER JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade
INNER JOIN Classes
ON ClassHab.idClasse = Classes.idClasse

SELECT Habilidades.Habilidade,  Classes.Nome AS Classe FROM ClassHab
LEFT JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade
RIGHT JOIN Classes
ON ClassHab.idClasse = Classes.idClasse