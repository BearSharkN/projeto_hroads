USE SENAI_HROADS;


INSERT INTO TipoUsuarios		(tipoUsuario)
VALUES							('Administrador')
								,('Usuario');
GO

INSERT INTO	Usuarios			(email,senha)
VALUES							('admin@admin.com','admin')
								,('cliente@cliente.com','cliente');
GO

INSERT INTO TipoHabilidade		(Tipo)
VALUES							('Ataque')
								,('Defesa')
								,('Cura')
								,('Magia');
GO

INSERT INTO Habilidades			(Habilidade, idTipo)
VALUES							('Lança Mortal', 1)
								,('Escudo Supremo', 2)
								,('Recuperar Vida', 3);
GO

INSERT INTO Classes				(Nome)
VALUES							('Bárbaro')
								,('Cruzado')
								,('Caçadora de Demônios')
								,('Monge')
								,('Necromante')
								,('Feiticeiro')
								,('Arcanista');
GO

INSERT INTO ClassHab			(idClasse, idHabilidade)
VALUES							(1, 1)
								,(1, 2)
								,(2, 2)
								,(3, 1)
								,(4, 2)
								,(4, 3)
								,(6, 3);
GO

INSERT INTO Personagens			(Nome, CapacidadeMaxVida, CapacidadeMaxMana, DataAtualizacao, DataCriacao, idClasse)
VALUES							('DeuBug', '100', '80', '2021/04/29', '2019/01/18', 1)
								,('BitBug', '70', '100', '2021/04/29', '2016/03/17', 4)
								,('Fer8', '75', '60', '2021/04/29', '2018/03/17', 7);
GO

