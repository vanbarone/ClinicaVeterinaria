USE master
GO

DROP DATABASE IF EXISTS ClinicaVeterinaria
GO

CREATE DATABASE ClinicaVeterinaria
GO

USE ClinicaVeterinaria
GO

DROP TABLE IF EXISTS Clientes
GO
CREATE TABLE Clientes (
				id				INT				NOT NULL	PRIMARY KEY		IDENTITY,
				nome			NVARCHAR(100)	NOT NULL,
				cpf				NVARCHAR(11)	NOT NULL,
				email			NVARCHAR(100)	NULL,
				celular			NVARCHAR(15)	NULL
)
GO

DROP TABLE IF EXISTS Veterinarios
GO
CREATE TABLE Veterinarios (
				id				INT				NOT NULL	PRIMARY KEY		IDENTITY,
				nome			NVARCHAR(100)	NOT NULL,
				crv				NVARCHAR(10)	NOT NULL,
				cpf				NVARCHAR(14)	NOT NULL,
				email			NVARCHAR(100)	NULL,
				celular			NVARCHAR(15)	NULL
)
GO


DROP TABLE IF EXISTS TipoAnimais
GO
CREATE TABLE TipoAnimais (
				id				INT				NOT NULL	PRIMARY KEY		IDENTITY,
				tipo			NVARCHAR(15)	NOT NULL,
				imagem			NVARCHAR(MAX)	NULL
)
GO


DROP TABLE IF EXISTS Animais
GO
CREATE TABLE Animais (
				id				INT				NOT NULL	PRIMARY KEY		IDENTITY,
				nome			NVARCHAR(50)	NOT NULL,
				raca			NVARCHAR(30)	NOT NULL,
				dtNasc			DATETIME		NOT NULL,
				idCliente		INT				NOT NULL	FOREIGN KEY REFERENCES Clientes(id), 
				idTipoAnimal	INT				NOT NULL	FOREIGN KEY REFERENCES Clientes(id) 
)
GO

DROP TABLE IF EXISTS Consultas
GO
CREATE TABLE Consultas (
				id				INT				NOT NULL	PRIMARY KEY		IDENTITY,
				idAnimal		INT				NOT NULL	FOREIGN KEY REFERENCES Animais(id),
				idVeterinario	INT				NOT NULL	FOREIGN KEY REFERENCES Veterinarios(id),
				dtConsulta		DATETIME		NOT NULL,
				peso			FLOAT			NULL,
				sintomas		NVARCHAR(MAX)	NULL,
				diagnostico		NVARCHAR(MAX)	NULL,
				valor			DECIMAL(6,2)	NULL
)

	