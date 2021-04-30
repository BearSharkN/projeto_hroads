CREATE DATABASE SENAI_HROADS;

USE SENAI_HROADS;

CREATE TABLE TipoUsuarios
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	,tipoUsuario VARCHAR (50) NOT NULL
);
GO
CREATE TABLE Usuarios
(
	idUsuario INT PRIMARY KEY IDENTITY
	,email  VARCHAR (200) NOT NULL
	,senha VARCHAR (200) NOT NULL
	,idTipoUsuario  INT FOREIGN KEY REFERENCES TipoUsuarios(idTipoUsuario)
);
GO
 CREATE TABLE TipoHabilidade
(
    idTipo    INT PRIMARY KEY IDENTITY
    ,Tipo    VARCHAR (50) NOT NULL
);
GO

CREATE TABLE Habilidades
(
    idHabilidade    INT PRIMARY KEY IDENTITY
    ,idTipo            INT FOREIGN    KEY REFERENCES TipoHabilidade(idTipo)
    ,Habilidade        VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Classes
(
    idClasse            INT PRIMARY KEY IDENTITY
    ,Nome                VARCHAR(50)
);
GO

CREATE TABLE ClassHab
(
    idClassHab        INT PRIMARY KEY IDENTITY
    ,idClasse        INT FOREIGN KEY REFERENCES Classes(idClasse)
    ,idHabilidade    INT FOREIGN KEY REFERENCES Habilidades(idHabilidade)
);
GO 

CREATE TABLE Personagens
(
    idPersonagem			INT PRIMARY KEY IDENTITY
    ,Nome					VARCHAR (20) NOT NULL
    ,CapacidadeMaxVida		INT
    ,CapacidadeMaxMana		INT
    ,DataAtualizacao		DATE
    ,DataCriacao			DATE
    ,idClasse				INT FOREIGN KEY REFERENCES Classes(idClasse)
);
GO

