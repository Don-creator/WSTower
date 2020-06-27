USE master
GO
DROP DATABASE IF EXISTS Campeonato
GO

-- Cria��o do banco de dados
CREATE DATABASE Campeonato
GO
-- Uso do banco de dados
USE Campeonato
GO
-- Cria��o de tabelas
CREATE TABLE Selecao(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Bandeira IMAGE,
	Uniforme IMAGE,
	Escalacao VARCHAR(10)
)
GO
-- Cria��o da tabela com chave estrangeira
CREATE TABLE Jogador(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Nascimento DATETIME NOT NULL,
	Posicao VARCHAR(255) NOT NULL,
	QTDEFaltas INT NOT NULL DEFAULT(0),
	QTDECartoesAmarelo INT NOT NULL DEFAULT(0),
	QTDECartoesVermelho INT NOT NULL DEFAULT(0),
	QTDEGols INT NOT NULL DEFAULT(0),
	Informacoes TEXT NOT NULL,
	NumeroCamisa INT NOT NULL,
	Foto IMAGE,
	SelecaoID INT FOREIGN KEY REFERENCES Selecao(Id)
)
GO

CREATE TABLE Jogo(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	SelecaoCasa INT FOREIGN KEY REFERENCES Selecao(Id),
	SelecaoVisitante INT FOREIGN KEY REFERENCES Selecao(Id),
	PlacarCasa INT NOT NULL DEFAULT(0),
	PlacarVisitante INT NOT NULL DEFAULT(0),
	PenaltisCasa INT NOT NULL DEFAULT(0),
	PenaltisVisitante INT NOT NULL DEFAULT(0),
	Data DATETIME,
	Estadio VARCHAR(255) NOT NULL,
)
GO

CREATE TABLE Usuario(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Apelido VARCHAR(255) NOT NULL UNIQUE,
	Foto IMAGE,
	Senha VARCHAR(255) NOT NULL
)
GO